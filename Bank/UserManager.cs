using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;

public class UserManager
{
    private DatabaseManager dbManager;
    public int CurrentUserId { get; private set; } // 当前登录用户的ID

    public UserManager(DatabaseManager dbManager)
    {
        this.dbManager = dbManager;
    }

    public void Register(string username, string password)
    {
        using (var connection = dbManager.GetConnection())
        {
            connection.Open();
            var transaction = connection.BeginTransaction();

            try
            {
                // 哈希密码
                string hashedPassword = ComputeSha256Hash(password);

                // 创建新用户
                var userCommand = new MySqlCommand("INSERT INTO Users (Username, Password) VALUES (@username, @hashedPassword)", connection);
                userCommand.Parameters.AddWithValue("@username", username);
                userCommand.Parameters.AddWithValue("@hashedPassword", hashedPassword); // 使用哈希加密密码
                userCommand.ExecuteNonQuery();

                // 获取新创建的用户ID
                var userId = (int)userCommand.LastInsertedId;

                // 为新用户创建账户
                var accountCommand = new MySqlCommand("INSERT INTO Accounts (UserId, Balance) VALUES (@userId, 0.00)", connection);
                accountCommand.Parameters.AddWithValue("@userId", userId);
                accountCommand.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }


    public User Login(string username, string password)
    {
        using (var connection = dbManager.GetConnection())
        {
            connection.Open();
            var command = new MySqlCommand("SELECT UserId, Username, Password, Role FROM Users WHERE Username = @username", connection);
            command.Parameters.AddWithValue("@username", username);

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    string storedHash = reader.GetString("Password");
                    string userRole = reader.GetString("Role");
                    string hashedPassword = ComputeSha256Hash(password);

                    if (hashedPassword == storedHash)
                    {
                        int userId = reader.GetInt32("UserId");
                        CurrentUserId = userId;
                        return new User(userId, reader["Username"].ToString(), storedHash, userRole);
                    }
                }
            }
        }
        return null;
    }

    private static string ComputeSha256Hash(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
