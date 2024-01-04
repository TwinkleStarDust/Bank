partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.TextBox usernameTextBox;
    private System.Windows.Forms.TextBox passwordTextBox;
    private System.Windows.Forms.Button loginBtn;
    private System.Windows.Forms.Label usernameLabel;
    private System.Windows.Forms.Label passwordLabel;
    private System.Windows.Forms.Button registerBtn;
    private System.Windows.Forms.Button adminLoginButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        usernameTextBox = new TextBox();
        passwordTextBox = new TextBox();
        loginBtn = new Button();
        usernameLabel = new Label();
        passwordLabel = new Label();
        registerBtn = new Button();
        adminLoginButton = new Button();
        SuspendLayout();
        // 
        // usernameTextBox
        // 
        usernameTextBox.Location = new Point(117, 95);
        usernameTextBox.Margin = new Padding(7);
        usernameTextBox.Name = "usernameTextBox";
        usernameTextBox.Size = new Size(461, 38);
        usernameTextBox.TabIndex = 1;
        // 
        // passwordTextBox
        // 
        passwordTextBox.Location = new Point(117, 215);
        passwordTextBox.Margin = new Padding(7);
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.PasswordChar = '*';
        passwordTextBox.Size = new Size(461, 38);
        passwordTextBox.TabIndex = 3;
        // 
        // loginBtn
        // 
        loginBtn.Location = new Point(117, 286);
        loginBtn.Margin = new Padding(7);
        loginBtn.Name = "loginBtn";
        loginBtn.Size = new Size(467, 55);
        loginBtn.TabIndex = 4;
        loginBtn.Text = "登录";
        loginBtn.UseVisualStyleBackColor = true;
        loginBtn.Click += loginButton_Click;
        // 
        // adminLoginButton
        // 
        adminLoginButton.Location = new Point(117, 415); 
        adminLoginButton.Name = "adminLoginButton";
        adminLoginButton.Size = new Size(467, 55);
        adminLoginButton.TabIndex = 6;
        adminLoginButton.Text = "管理员登录";
        adminLoginButton.UseVisualStyleBackColor = true;
        adminLoginButton.Click += adminLoginButton_Click;
        // 
        // usernameLabel
        // 
        usernameLabel.AutoSize = true;
        usernameLabel.Location = new Point(117, 48);
        usernameLabel.Margin = new Padding(7, 0, 7, 0);
        usernameLabel.Name = "usernameLabel";
        usernameLabel.Size = new Size(86, 31);
        usernameLabel.TabIndex = 0;
        usernameLabel.Text = "用户名";
        // 
        // passwordLabel
        // 
        passwordLabel.AutoSize = true;
        passwordLabel.Location = new Point(117, 167);
        passwordLabel.Margin = new Padding(7, 0, 7, 0);
        passwordLabel.Name = "passwordLabel";
        passwordLabel.Size = new Size(62, 31);
        passwordLabel.TabIndex = 2;
        passwordLabel.Text = "密码";
        // 
        // registerBtn
        // 
        registerBtn.AutoSize = true;
        registerBtn.Location = new Point(117, 358);
        registerBtn.Margin = new Padding(7, 0, 7, 0);
        registerBtn.Name = "registerBtn";
        registerBtn.Size = new Size(461, 41);
        registerBtn.TabIndex = 5;
        registerBtn.Text = "前往注册";
        registerBtn.Click += registerButton_Click;
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new SizeF(14F, 31F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 477);
        Controls.Add(usernameTextBox);
        Controls.Add(passwordTextBox);
        Controls.Add(loginBtn);
        Controls.Add(usernameLabel);
        Controls.Add(passwordLabel);
        Controls.Add(registerBtn);
        Controls.Add(adminLoginButton);
        Margin = new Padding(7);
        Name = "LoginForm";
        Text = "银行登陆页面";
        Load += LoginForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }
}
