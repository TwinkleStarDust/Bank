partial class BankForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Button transferButton;
    private System.Windows.Forms.Button balanceButton;
    private System.Windows.Forms.Button depositButton;
    private System.Windows.Forms.Button contactsButton;
    private System.Windows.Forms.Button TransactionHistoryButton;
    private System.Windows.Forms.Label labelBalance;
    private System.Windows.Forms.Label labelAmount;
    private System.Windows.Forms.ListBox listBoxContacts;
    private System.Windows.Forms.ContextMenuStrip contactsContextMenu;
    private System.Windows.Forms.ToolStripMenuItem transferMenuItem;

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
        components = new System.ComponentModel.Container();
        transferButton = new Button();
        balanceButton = new Button();
        depositButton = new Button();
        contactsButton = new Button();
        TransactionHistoryButton = new Button();
        labelBalance = new Label();
        labelAmount = new Label();
        listBoxContacts = new ListBox();
        contactsContextMenu = new ContextMenuStrip(components);
        transferMenuItem = new ToolStripMenuItem();
        contactsContextMenu.SuspendLayout();
        SuspendLayout();
        // 
        // transferButton
        // 
        transferButton.Location = new Point(47, 48);
        transferButton.Name = "transferButton";
        transferButton.Size = new Size(233, 55);
        transferButton.TabIndex = 0;
        transferButton.Text = "转账";
        transferButton.UseVisualStyleBackColor = true;
        transferButton.Click += transferButton_Click;
        // 
        // balanceButton
        // 
        balanceButton.Location = new Point(47, 143);
        balanceButton.Name = "balanceButton";
        balanceButton.Size = new Size(233, 55);
        balanceButton.TabIndex = 1;
        balanceButton.Text = "刷新余额";
        balanceButton.UseVisualStyleBackColor = true;
        balanceButton.Click += balanceButton_Click;
        // 
        // depositButton
        // 
        depositButton.Location = new Point(47, 238);
        depositButton.Name = "depositButton";
        depositButton.Size = new Size(233, 55);
        depositButton.TabIndex = 2;
        depositButton.Text = "存款";
        depositButton.UseVisualStyleBackColor = true;
        depositButton.Click += depositButton_Click;
        // 
        // contactsButton
        // 
        contactsButton.Location = new Point(47, 334);
        contactsButton.Name = "contactsButton";
        contactsButton.Size = new Size(233, 55);
        contactsButton.TabIndex = 3;
        contactsButton.Text = "联系人";
        contactsButton.UseVisualStyleBackColor = true;
        contactsButton.Click += contactsButton_Click;
        // 
        // TransactionHistoryButton
        // 
        TransactionHistoryButton.Location = new Point(47, 430);
        TransactionHistoryButton.Name = "TransactionHistoryButton";
        TransactionHistoryButton.Size = new Size(233, 55);
        TransactionHistoryButton.TabIndex = 4;
        TransactionHistoryButton.Text = "历史操作";
        TransactionHistoryButton.UseVisualStyleBackColor = true;
        TransactionHistoryButton.Click += transactionHistoryButton_Click;
        // 
        // labelBalance
        // 
        labelBalance.AutoSize = true;
        labelBalance.Location = new Point(350, 72);
        labelBalance.Name = "labelBalance";
        labelBalance.Size = new Size(123, 31);
        labelBalance.TabIndex = 5;
        labelBalance.Text = "账户余额: ";
        // 
        // labelAmount
        // 
        labelAmount.Location = new Point(0, 0);
        labelAmount.Name = "labelAmount";
        labelAmount.Size = new Size(100, 23);
        labelAmount.TabIndex = 7;
        // 
        // listBoxContacts
        // 
        listBoxContacts.ContextMenuStrip = contactsContextMenu;
        listBoxContacts.FormattingEnabled = true;
        listBoxContacts.Location = new Point(350, 210);
        listBoxContacts.Name = "listBoxContacts";
        listBoxContacts.Size = new Size(338, 345);
        listBoxContacts.TabIndex = 8;
        // 
        // contactsContextMenu
        // 
        contactsContextMenu.ImageScalingSize = new Size(32, 32);
        contactsContextMenu.Items.AddRange(new ToolStripItem[] { transferMenuItem });
        contactsContextMenu.Name = "contactsContextMenu";
        contactsContextMenu.Size = new Size(137, 42);
        // 
        // transferMenuItem
        // 
        transferMenuItem.Name = "transferMenuItem";
        transferMenuItem.Size = new Size(136, 38);
        transferMenuItem.Text = "转账";
        transferMenuItem.Click += transferMenuItem_Click;
        // 
        // BankForm
        // 
        AutoScaleDimensions = new SizeF(14F, 31F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 596);
        Controls.Add(transferButton);
        Controls.Add(balanceButton);
        Controls.Add(depositButton);
        Controls.Add(contactsButton);
        Controls.Add(TransactionHistoryButton);
        Controls.Add(labelBalance);
        Controls.Add(labelAmount);
        Controls.Add(listBoxContacts);
        Name = "BankForm";
        Text = "欢迎来到银行系统";
        Load += BankForm_Load;
        contactsContextMenu.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }
}
