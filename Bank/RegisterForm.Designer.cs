partial class RegisterForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.TextBox usernameTextBox;
    private System.Windows.Forms.TextBox passwordTextBox;
    private System.Windows.Forms.Button registerButton;
    private System.Windows.Forms.Label usernameLabel;
    private System.Windows.Forms.Label passwordLabel;

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
        registerButton = new Button();
        usernameLabel = new Label();
        passwordLabel = new Label();
        SuspendLayout();
        // 
        // usernameTextBox
        // 
        usernameTextBox.Location = new Point(117, 95);
        usernameTextBox.Margin = new Padding(7);
        usernameTextBox.Name = "usernameTextBox";
        usernameTextBox.Size = new Size(461, 38);
        usernameTextBox.TabIndex = 1;
        usernameTextBox.TextChanged += usernameTextBox_TextChanged;
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
        // registerButton
        // 
        registerButton.Location = new Point(117, 286);
        registerButton.Margin = new Padding(7);
        registerButton.Name = "registerButton";
        registerButton.Size = new Size(467, 55);
        registerButton.TabIndex = 4;
        registerButton.Text = "确认注册";
        registerButton.UseVisualStyleBackColor = true;
        registerButton.Click += registerButton_Click;
        // 
        // usernameLabel
        // 
        usernameLabel.AutoSize = true;
        usernameLabel.Location = new Point(117, 48);
        usernameLabel.Margin = new Padding(7, 0, 7, 0);
        usernameLabel.Name = "usernameLabel";
        usernameLabel.Size = new Size(130, 31);
        usernameLabel.TabIndex = 0;
        usernameLabel.Text = "请输入用户名";
        // 
        // passwordLabel
        // 
        passwordLabel.AutoSize = true;
        passwordLabel.Location = new Point(117, 167);
        passwordLabel.Margin = new Padding(7, 0, 7, 0);
        passwordLabel.Name = "passwordLabel";
        passwordLabel.Size = new Size(122, 31);
        passwordLabel.TabIndex = 2;
        passwordLabel.Text = "请输入密码";
        // 
        // RegisterForm
        // 
        AutoScaleDimensions = new SizeF(14F, 31F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 477);
        Controls.Add(usernameTextBox);
        Controls.Add(passwordTextBox);
        Controls.Add(registerButton);
        Controls.Add(usernameLabel);
        Controls.Add(passwordLabel);
        Margin = new Padding(7);
        Name = "RegisterForm";
        Text = "银行注册页面";
        Load += RegisterForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }
}
