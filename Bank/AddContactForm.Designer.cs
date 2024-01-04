partial class AddContactForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.TextBox contactAccountIdTextBox;
    private System.Windows.Forms.TextBox contactUsernameTextBox;
    private System.Windows.Forms.Button addButton;
    private System.Windows.Forms.Label contactAccountIdLabel;
    private System.Windows.Forms.Label contactUsernameLabel;

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
        this.contactAccountIdTextBox = new System.Windows.Forms.TextBox();
        this.contactUsernameTextBox = new System.Windows.Forms.TextBox();
        this.addButton = new System.Windows.Forms.Button();
        this.contactAccountIdLabel = new System.Windows.Forms.Label();
        this.contactUsernameLabel = new System.Windows.Forms.Label();

        // 
        // contactAccountIdTextBox
        // 
        this.contactAccountIdTextBox.Location = new System.Drawing.Point(150, 20);
        this.contactAccountIdTextBox.Name = "contactAccountIdTextBox";
        this.contactAccountIdTextBox.Size = new System.Drawing.Size(200, 20);
        this.contactAccountIdTextBox.TabIndex = 0;

        // 
        // contactUsernameTextBox
        // 
        this.contactUsernameTextBox.Location = new System.Drawing.Point(150, 60);
        this.contactUsernameTextBox.Name = "contactUsernameTextBox";
        this.contactUsernameTextBox.Size = new System.Drawing.Size(200, 20);
        this.contactUsernameTextBox.TabIndex = 1;

        // 
        // addButton
        // 
        this.addButton.Location = new System.Drawing.Point(150, 100);
        this.addButton.Name = "addButton";
        this.addButton.Size = new System.Drawing.Size(100, 23);
        this.addButton.TabIndex = 2;
        this.addButton.Text = "添加联系人";
        this.addButton.UseVisualStyleBackColor = true;
        this.addButton.Click += new System.EventHandler(this.addButton_Click);

        // 
        // contactAccountIdLabel
        // 
        this.contactAccountIdLabel.AutoSize = true;
        this.contactAccountIdLabel.Location = new System.Drawing.Point(30, 23);
        this.contactAccountIdLabel.Name = "contactAccountIdLabel";
        this.contactAccountIdLabel.Size = new System.Drawing.Size(115, 13);
        this.contactAccountIdLabel.Text = "联系人账户ID:";

        // 
        // contactUsernameLabel
        // 
        this.contactUsernameLabel.AutoSize = true;
        this.contactUsernameLabel.Location = new System.Drawing.Point(30, 63);
        this.contactUsernameLabel.Name = "contactUsernameLabel";
        this.contactUsernameLabel.Size = new System.Drawing.Size(115, 13);
        this.contactUsernameLabel.Text = "联系人用户名:";

        // 
        // AddContactForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 150);
        this.Controls.Add(this.contactAccountIdTextBox);
        this.Controls.Add(this.contactUsernameTextBox);
        this.Controls.Add(this.addButton);
        this.Controls.Add(this.contactAccountIdLabel);
        this.Controls.Add(this.contactUsernameLabel);
        this.Name = "AddContactForm";
        this.Text = "添加联系人";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
