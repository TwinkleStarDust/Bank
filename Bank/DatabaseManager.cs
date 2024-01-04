using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;


public class DatabaseManager
{
    private string connectionString;

    public DatabaseManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public DatabaseManager()
    {
        connectionString = "server=localhost;port=3306;user=root;password=root;database=bank";
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }

    public void TestConnection()
    {
        try
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                Console.WriteLine("银行数据库连接成功");

                // 示例查询
                string query = "SELECT COUNT(*) FROM users";
                using (var command = new MySqlCommand(query, connection))
                {
                    var count = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine($"操作次数: {count}");
                }

                connection.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("数据库连接发生错误: " + ex.Message);
        }
    }
}
