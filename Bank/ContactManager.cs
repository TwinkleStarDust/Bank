using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

public class ContactManager
{
    private DatabaseManager dbManager;

    public ContactManager(DatabaseManager dbManager)
    {
        this.dbManager = dbManager;
    }

    public void AddContact(int userId, int contactAccountId, string contactUsername)
    {
        using (var connection = dbManager.GetConnection())
        {
            connection.Open();
            var transaction = connection.BeginTransaction();

            try
            {
                // 检查是否已存在该联系人
                var checkCommand = new MySqlCommand("SELECT COUNT(*) FROM Contacts WHERE UserId = @userId AND ContactAccountId = @contactAccountId", connection, transaction);
                checkCommand.Parameters.AddWithValue("@userId", userId);
                checkCommand.Parameters.AddWithValue("@contactAccountId", contactAccountId);

                var exists = (long)checkCommand.ExecuteScalar() > 0;

                MySqlCommand command;
                if (exists)
                {
                    // 更新已存在的联系人
                    command = new MySqlCommand("UPDATE Contacts SET ContactUsername = @contactUsername WHERE UserId = @userId AND ContactAccountId = @contactAccountId", connection, transaction);
                }
                else
                {
                    // 添加新的联系人
                    command = new MySqlCommand("INSERT INTO Contacts (UserId, ContactAccountId, ContactUsername) VALUES (@userId, @contactAccountId, @contactUsername)", connection, transaction);
                }

                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@contactAccountId", contactAccountId);
                command.Parameters.AddWithValue("@contactUsername", contactUsername);
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }

    public List<Contact> GetContacts(int userId)
    {
        var contacts = new List<Contact>();
        using (var connection = dbManager.GetConnection())
        {
            connection.Open();
            var command = new MySqlCommand("SELECT * FROM Contacts WHERE UserId = @userId", connection);
            command.Parameters.AddWithValue("@userId", userId);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    contacts.Add(new Contact
                    {
                        ContactId = reader.GetInt32("ContactId"),
                        UserId = userId,
                        ContactAccountId = reader.GetInt32("ContactAccountId"),
                        ContactUsername = reader.GetString("ContactUsername")
                    });
                }
            }
        }
        return contacts;
    }
}

public class Contact
{
    public int ContactId { get; set; }
    public int UserId { get; set; }
    public int ContactAccountId { get; set; }
    public string ContactUsername { get; set; }
}
