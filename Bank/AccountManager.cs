using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Transactions;

public class AccountManager
{
    private DatabaseManager dbManager;

    public AccountManager(DatabaseManager dbManager)
    {
        this.dbManager = dbManager;
    }

    public int GetAccountIdByUserId(int userId)
    {
        using (var connection = dbManager.GetConnection())
        {
            connection.Open();
            var command = new MySqlCommand("SELECT AccountId FROM Accounts WHERE UserId = @userId", connection);
            command.Parameters.AddWithValue("@userId", userId);
            var result = command.ExecuteScalar();
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return -1; // 抛出异常
        }
    }

    private bool IsBalanceSufficient(int accountId, decimal amount, MySqlConnection connection, MySqlTransaction transaction)
    {
        var balanceCommand = new MySqlCommand("SELECT Balance FROM Accounts WHERE AccountId = @accountId", connection, transaction);
        balanceCommand.Parameters.AddWithValue("@accountId", accountId);

        using (var reader = balanceCommand.ExecuteReader())
        {
            if (reader.Read())
            {
                var currentBalance = reader.GetDecimal(reader.GetOrdinal("Balance"));
                return currentBalance >= amount;
            }
            else
            {
                return false;
            }
        }
    }
    public bool Transfer(int userId, int toAccountId, decimal amount)
    {
        using (var connection = dbManager.GetConnection())
        {
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    int fromAccountId = GetAccountIdByUserId(userId);
                    if (fromAccountId == -1)
                    {
                        transaction.Rollback();
                        return false;
                    }

                    if (!IsBalanceSufficient(fromAccountId, amount, connection, transaction))
                    {
                        transaction.Rollback();
                        return false;
                    }

                    // 从发送方账户扣款
                    var deductCommand = new MySqlCommand("UPDATE Accounts SET Balance = Balance - @amount WHERE AccountId = @fromAccountId", connection, transaction);
                    deductCommand.Parameters.AddWithValue("@amount", amount);
                    deductCommand.Parameters.AddWithValue("@fromAccountId", fromAccountId);
                    deductCommand.ExecuteNonQuery();

                    // 向接收方账户转账
                    var addCommand = new MySqlCommand("UPDATE Accounts SET Balance = Balance + @amount WHERE AccountId = @toAccountId", connection, transaction);
                    addCommand.Parameters.AddWithValue("@amount", amount);
                    addCommand.Parameters.AddWithValue("@toAccountId", toAccountId);
                    addCommand.ExecuteNonQuery();

                    // 记录转账交易
                    RecordTransaction(fromAccountId, toAccountId, amount, "转账", "账户间交易", connection, transaction);

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }

    public void ManageDeposit(int userId, decimal amount, string depositType, string depositTerm)
    {
        using (var connection = dbManager.GetConnection())
        {
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    int accountId = GetAccountIdByUserId(userId);
                    if (accountId == -1)
                    {
                        transaction.Rollback();
                        return;
                    }

                    if (depositType == "活期")
                    {
                        UpdateAccountBalance(accountId, amount, connection, transaction);
                    }
                    else if (depositType == "定期")
                    {
                        DateTime maturityDate = CalculateMaturityDate(depositTerm);
                        CreateTimeDeposit(accountId, amount, maturityDate, connection, transaction);
                    }

                    RecordTransaction(accountId, accountId, amount, "存款", depositType + " 存款", connection, transaction);

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }

    private DateTime CalculateMaturityDate(string depositTerm)
    {
        switch (depositTerm)
        {
            case "3个月":
                return DateTime.Now.AddMonths(3);
            case "6个月":
                return DateTime.Now.AddMonths(6);
            case "一年":
                return DateTime.Now.AddYears(1);
            case "两年":
                return DateTime.Now.AddYears(2);
            case "三年":
                return DateTime.Now.AddYears(3);
            case "五年":
                return DateTime.Now.AddYears(5);
            default:
                throw new ArgumentException("未知的存款期限");
        }
    }
    private void UpdateAccountBalance(int accountId, decimal amount, MySqlConnection connection, MySqlTransaction transaction)
    {
        var command = new MySqlCommand("UPDATE Accounts SET Balance = Balance + @amount WHERE AccountId = @accountId", connection, transaction);
        command.Parameters.AddWithValue("@amount", amount);
        command.Parameters.AddWithValue("@accountId", accountId);
        command.ExecuteNonQuery();
    }

    private void CreateTimeDeposit(int accountId, decimal amount, DateTime maturityDate, MySqlConnection connection, MySqlTransaction transaction)
    {
        var command = new MySqlCommand("INSERT INTO TimeDeposits (AccountId, Amount, MaturityDate) VALUES (@accountId, @amount, @maturityDate)", connection, transaction);
        command.Parameters.AddWithValue("@accountId", accountId);
        command.Parameters.AddWithValue("@amount", amount);
        command.Parameters.AddWithValue("@maturityDate", maturityDate);
        command.ExecuteNonQuery();
    }


    public (decimal TotalBalance, decimal AvailableBalance) GetBalance(int accountId)
    {
        decimal totalBalance = 0;
        decimal availableBalance = 0;

        using (var connection = dbManager.GetConnection())
        {
            connection.Open();

            // 获取活期余额
            var command = new MySqlCommand("SELECT Balance FROM Accounts WHERE AccountId = @accountId", connection);
            command.Parameters.AddWithValue("@accountId", accountId);

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    availableBalance = reader.GetDecimal(reader.GetOrdinal("Balance"));
                    totalBalance += availableBalance;
                }
                else
                {
                    throw new Exception("账户不存在");
                }
            }

            // 获取定期存款总额
            command = new MySqlCommand("SELECT SUM(Amount) FROM TimeDeposits WHERE AccountId = @accountId AND MaturityDate > CURRENT_DATE", connection);
            command.Parameters.AddWithValue("@accountId", accountId);

            var result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                totalBalance += Convert.ToDecimal(result);
            }
        }

        return (totalBalance, availableBalance);
    }



    public List<TransactionRecord> GetTransactionHistory(int accountId)
    {
        var transactions = new List<TransactionRecord>();
        using (var connection = dbManager.GetConnection())
        {
            connection.Open();
            var command = new MySqlCommand("SELECT * FROM Transactions WHERE FromAccountId = @accountId OR ToAccountId = @accountId ORDER BY Timestamp DESC", connection);
            command.Parameters.AddWithValue("@accountId", accountId);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var record = new TransactionRecord
                    {
                        TransactionId = reader.GetInt32("TransactionId"),
                        FromAccountId = reader.GetInt32("FromAccountId"),
                        ToAccountId = reader.GetInt32("ToAccountId"),
                        Amount = reader.GetDecimal("Amount"),
                        TransactionType = reader.GetString("TransactionType"), 
                        Description = reader.GetString("Description"), 
                        Timestamp = reader.GetDateTime("Timestamp")
                    };
                    transactions.Add(record);
                }
            }
        }
        return transactions;
    }

    private void RecordTransaction(int fromAccountId, int toAccountId, decimal amount, string transactionType, string description, MySqlConnection connection, MySqlTransaction transaction)
    {
        var insertCommand = new MySqlCommand("INSERT INTO Transactions (FromAccountId, ToAccountId, Amount, TransactionType, Description) VALUES (@fromAccountId, @toAccountId, @amount, @transactionType, @description)", connection, transaction);
        insertCommand.Parameters.AddWithValue("@fromAccountId", fromAccountId);
        insertCommand.Parameters.AddWithValue("@toAccountId", toAccountId);
        insertCommand.Parameters.AddWithValue("@amount", amount);
        insertCommand.Parameters.AddWithValue("@transactionType", transactionType);
        insertCommand.Parameters.AddWithValue("@description", description);
        insertCommand.ExecuteNonQuery();
    }
}

public class TransactionRecord
{
    public int TransactionId { get; set; }
    public int FromAccountId { get; set; }
    public int ToAccountId { get; set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; set; } 
    public string Description { get; set; } 
    public DateTime Timestamp { get; set; }

}


