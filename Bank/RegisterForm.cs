using System;
using System.Windows.Forms;

public partial class RegisterForm : Form
{
    private UserManager userManager;

    public RegisterForm(UserManager userManager)
    {
        InitializeComponent();
        this.userManager = userManager;
    }

    private void RegisterForm_Load(object sender, EventArgs e)
    {
       
    }

    private void registerButton_Click(object sender, EventArgs e)
    {
        var username = usernameTextBox.Text;
        var password = passwordTextBox.Text;

        userManager.Register(username, password);
        MessageBox.Show("×¢²á³É¹¦");
    }

    private void usernameTextBox_TextChanged(object sender, EventArgs e)
    {

    }
}
