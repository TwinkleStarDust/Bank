using System;
using System.Windows.Forms;

public partial class LoginForm : Form
{
    private UserManager userManager;
    private DatabaseManager dbManager; // DatabaseManager 实例

    public LoginForm()
    {
        InitializeComponent();
        dbManager = new DatabaseManager(); // 初始化 DatabaseManager
        userManager = new UserManager(dbManager);
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
      
    }

    private void loginButton_Click(object sender, EventArgs e)
    {
        var username = usernameTextBox.Text;
        var password = passwordTextBox.Text;

        var user = userManager.Login(username, password);
        if (user != null)
        {
            MessageBox.Show("登录成功");

            // 创建并显示 BankForm，传递正确的实例
            BankForm bankForm = new BankForm(userManager, new AccountManager(dbManager), new ContactManager(dbManager));
            bankForm.ShowDialog(); // 启动银行系统

            // 关闭登陆系统
            this.Close();
        }
        else
        {
            MessageBox.Show("登录失败，请检查用户名和密码是否正确");
        }
    }


    private void registerButton_Click(object sender, EventArgs e)
    {
        this.Hide(); // 隐藏当前登录窗口
        RegisterForm registerForm = new RegisterForm(userManager);
        registerForm.ShowDialog(); // 显示注册窗口

        this.Show(); // 关闭注册窗口，重新显示登录窗口
    }

    private void adminLoginButton_Click(object sender, EventArgs e)
    {
        var username = usernameTextBox.Text;
        var password = passwordTextBox.Text;

        var user = userManager.Login(username, password);
        if (user != null)
        {
            if (user.Role == "admin")
            {
                MessageBox.Show("管理员登录成功");

                // 创建并显示 AdminForm
                AdminForm adminForm = new AdminForm(dbManager);
                adminForm.ShowDialog();

                // 关闭登录窗口
                this.Close();
            }
            else
            {
                MessageBox.Show("你不是管理员，无法登录管理员系统！");
            }
        }
        else
        {
            MessageBox.Show("登录失败，请检查用户名和密码是否正确");
        }
    }


}
