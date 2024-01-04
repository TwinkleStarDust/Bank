using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Transactions;
using System.Data.Common;

public partial class AdminForm : Form
{
    private DatabaseManager dbManager;

    public AdminForm(DatabaseManager dbManager)
    {
        InitializeComponent();
        this.dbManager = dbManager;
        LoadUserData();
    }

    private void LoadUserData()
    {
        using (var connection = dbManager.GetConnection())
        {
            try
            {
                connection.Open();
                var command = new MySqlCommand(
                    @"SELECT 
                    Users.UserId AS '用户ID', 
                    Users.Username AS '用户名',
                    Accounts.AccountId AS '账户ID',  
                    Users.Password AS '密码', 
                    Users.Role AS '角色', 
                    Users.IsActive AS '正常/冻结', 
                    Accounts.Balance AS '余额', 
                    Accounts.CreatedAt AS '创建时间', 
                    Accounts.UpdatedAt AS '更新时间'
                  FROM 
                    Users
                  JOIN 
                    Accounts ON Users.UserId = Accounts.UserId",
                    connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                usersDataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message);
            }
        }
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        UserManager userManager = new UserManager(dbManager);

        // 调用注册的窗口来添加新用户
        RegisterForm RegisterForm = new RegisterForm(userManager);
        if (RegisterForm.ShowDialog() == DialogResult.OK)
        {
            LoadUserData(); // 重新加载用户列表
        }
    }


    private void deleteButton_Click(object sender, EventArgs e)
    {
        int selectedUserId = GetSelectedUserId();
        if (selectedUserId != -1)
        {
            if (MessageBox.Show("确定删除用户吗？", "删除用户", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteUser(selectedUserId);
                LoadUserData(); // 重新加载用户列表
            }
        }
    }

    private void searchButton_Click(object sender, EventArgs e)
    {
        string searchText = searchTextBox.Text;
        SearchUsers(searchText);
    }

    private int GetSelectedUserId()
    {
        if (usersDataGridView.CurrentRow != null)
        {
            return Convert.ToInt32(usersDataGridView.CurrentRow.Cells["用户ID"].Value);
        }
        return -1;
    }

    // 删除用户的逻辑
    private void DeleteUser(int userId)
    {
        using (var connection = dbManager.GetConnection())
        {
            try
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                var deleteAccountsCommand = new MySqlCommand("DELETE FROM Accounts WHERE UserId = @userId", connection);
                deleteAccountsCommand.Parameters.AddWithValue("@userId", userId);
                deleteAccountsCommand.ExecuteNonQuery();

                var deleteUserCommand = new MySqlCommand("DELETE FROM Users WHERE UserId = @userId", connection);
                deleteUserCommand.Parameters.AddWithValue("@userId", userId);
                deleteUserCommand.ExecuteNonQuery();

                // 提交事务
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除用户失败: " + ex.Message);
            }
        }
    }


    // 搜索用户的逻辑
    private void SearchUsers(string searchText)
    {
        using (var connection = dbManager.GetConnection())
        {
            try
            {
                connection.Open();
                var command = new MySqlCommand(
                    @"SELECT 
                Users.UserId AS '用户ID', 
                Users.Username AS '用户名', 
                Users.Password AS '密码', 
                Users.Role AS '角色', 
                Users.IsActive AS '正常/冻结', 
                Accounts.AccountId AS '账户ID', 
                Accounts.Balance AS '余额', 
                Accounts.CreatedAt AS '创建时间', 
                Accounts.UpdatedAt AS '更新时间'
              FROM 
                Users
              JOIN 
                Accounts ON Users.UserId = Accounts.UserId
              WHERE 
                Users.Username LIKE @searchText OR Users.UserId LIKE @searchText",
                    connection);
                command.Parameters.AddWithValue("@searchText", $"%{searchText}%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                usersDataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("搜索用户失败: " + ex.Message);
            }
        }
    }

}
