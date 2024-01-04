partial class DepositForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.TextBox amountTextBox;
    private System.Windows.Forms.ComboBox depositTypeComboBox;
    private System.Windows.Forms.ComboBox depositTermComboBox;
    private System.Windows.Forms.Button depositButton;
    private System.Windows.Forms.Label amountLabel;
    private System.Windows.Forms.Label depositTypeLabel;
    private System.Windows.Forms.Label depositTermLabel;

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
        amountTextBox = new TextBox();
        depositTypeComboBox = new ComboBox();
        depositTermComboBox = new ComboBox();
        depositButton = new Button();
        amountLabel = new Label();
        depositTypeLabel = new Label();
        depositTermLabel = new Label();
        SuspendLayout();
        // 
        // amountTextBox
        // 
        amountTextBox.Location = new Point(280, 48);
        amountTextBox.Margin = new Padding(7, 7, 7, 7);
        amountTextBox.Name = "amountTextBox";
        amountTextBox.Size = new Size(345, 38);
        amountTextBox.TabIndex = 0;
        // 
        // depositTypeComboBox
        // 
        depositTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        depositTypeComboBox.FormattingEnabled = true;
        depositTypeComboBox.Location = new Point(280, 143);
        depositTypeComboBox.Margin = new Padding(7, 7, 7, 7);
        depositTypeComboBox.Name = "depositTypeComboBox";
        depositTypeComboBox.Size = new Size(345, 39);
        depositTypeComboBox.TabIndex = 1;
        // 
        // depositTermComboBox
        // 
        depositTermComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        depositTermComboBox.FormattingEnabled = true;
        depositTermComboBox.Location = new Point(280, 238);
        depositTermComboBox.Margin = new Padding(7, 7, 7, 7);
        depositTermComboBox.Name = "depositTermComboBox";
        depositTermComboBox.Size = new Size(345, 39);
        depositTermComboBox.TabIndex = 3;
        // 
        // depositButton
        // 
        depositButton.Location = new Point(280, 336);
        depositButton.Margin = new Padding(7, 7, 7, 7);
        depositButton.Name = "depositButton";
        depositButton.Size = new Size(350, 55);
        depositButton.TabIndex = 2;
        depositButton.Text = "确认存款";
        depositButton.UseVisualStyleBackColor = true;
        depositButton.Click += depositButton_Click;
        // 
        // amountLabel
        // 
        amountLabel.AutoSize = true;
        amountLabel.Location = new Point(47, 55);
        amountLabel.Margin = new Padding(7, 0, 7, 0);
        amountLabel.Name = "amountLabel";
        amountLabel.Size = new Size(188, 31);
        amountLabel.TabIndex = 3;
        amountLabel.Text = "请输入存款金额:";
        // 
        // depositTypeLabel
        // 
        depositTypeLabel.AutoSize = true;
        depositTypeLabel.Location = new Point(47, 150);
        depositTypeLabel.Margin = new Padding(7, 0, 7, 0);
        depositTypeLabel.Name = "depositTypeLabel";
        depositTypeLabel.Size = new Size(116, 31);
        depositTypeLabel.TabIndex = 4;
        depositTypeLabel.Text = "存款类型:";
        // 
        // depositTermLabel
        // 
        depositTermLabel.AutoSize = true;
        depositTermLabel.Location = new Point(47, 246);
        depositTermLabel.Margin = new Padding(7, 0, 7, 0);
        depositTermLabel.Name = "depositTermLabel";
        depositTermLabel.Size = new Size(164, 31);
        depositTermLabel.TabIndex = 5;
        depositTermLabel.Text = "选择存款期限:";
        // 
        // DepositForm
        // 
        AutoScaleDimensions = new SizeF(14F, 31F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 429);
        Controls.Add(amountTextBox);
        Controls.Add(depositTypeComboBox);
        Controls.Add(depositButton);
        Controls.Add(amountLabel);
        Controls.Add(depositTypeLabel);
        Controls.Add(depositTermComboBox);
        Controls.Add(depositTermLabel);
        Margin = new Padding(7, 7, 7, 7);
        Name = "DepositForm";
        Text = "存款";
        ResumeLayout(false);
        PerformLayout();
    }
}
