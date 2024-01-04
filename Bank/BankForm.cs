using Bank;
using System;
using System.Windows.Forms;

public partial class BankForm : Form
{
    private UserManager userManager;
    private AccountManager accountManager;
    private ContactManager contactManager;

    public BankForm(UserManager userManager, AccountManager accountManager, ContactManager contactManager)
    {
        InitializeComponent();
        this.userManager = userManager;
        this.accountManager = accountManager;
        this.contactManager = contactManager;
    }

    private void transferButton_Click(object sender, EventArgs e)
    {
        TransferForm transferForm = new TransferForm();
        if (transferForm.ShowDialog() == DialogResult.OK)
        {
            try
            {
                int fromAccountId = userManager.CurrentUserId; // 设当前用户ID即为转出账户ID
                int toAccountId = transferForm.ToAccountId; // 从 TransferForm 获取对方账户ID
                decimal amount = transferForm.Amount; // 从 TransferForm 获取转账金额

                // 调用 AccountManager 的 Transfer 方法来处理转账
                if (accountManager.Transfer(fromAccountId, toAccountId, amount))
                {
                    MessageBox.Show("转账成功");
                }
                else
                {
                    MessageBox.Show("转账失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("转账失败: " + ex.Message);
            }
        }
    }

    private void balanceButton_Click(object sender, EventArgs e)
    {
        try
        {
            int currentUserId = userManager.CurrentUserId;
            int accountId = accountManager.GetAccountIdByUserId(currentUserId);
            var balanceInfo = accountManager.GetBalance(accountId);
            labelBalance.Text = $"账户余额：{balanceInfo.TotalBalance}元\n（实际可取{balanceInfo.AvailableBalance}元）";
        }
        catch (Exception ex)
        {
            MessageBox.Show("错误余额: " + ex.Message);
        }
    }


    private void depositButton_Click(object sender, EventArgs e)
    {
        DepositForm depositForm = new DepositForm(accountManager, userManager.CurrentUserId);
        depositForm.ShowDialog();
    }

    private void contactsButton_Click(object sender, EventArgs e)
    {
        LoadContacts();
        AddContact(); // 假设这是添加联系人的方法
    }

    private void LoadContacts()
    {
        listBoxContacts.Items.Clear();
        int currentUserId = userManager.CurrentUserId;
        var contacts = contactManager.GetContacts(currentUserId);
        foreach (var contact in contacts)
        {
            // 假设 Contact 类包含 ContactAccountId 和 ContactUsername 属性
            listBoxContacts.Items.Add($"{contact.ContactUsername} (账户ID: {contact.ContactAccountId})");
        }
    }

    private void AddContact()
    {
        AddContactForm addContactForm = new AddContactForm(contactManager, userManager.CurrentUserId);
        if (addContactForm.ShowDialog() == DialogResult.OK)
        {
            LoadContacts();
        }
    }
    private void transferMenuItem_Click(object sender, EventArgs e)
    {
        if (listBoxContacts.SelectedItem == null)
        {
            MessageBox.Show("请先选择一个联系人");
            return;
        }

        string selectedContact = listBoxContacts.SelectedItem.ToString();
        int accountId = ExtractAccountIdFromContact(selectedContact);

        // 打开转账窗口
        TransferForm transferForm = new TransferForm();
        transferForm.SetRecipientAccountId(accountId); // 设置接收方账户ID
        if (transferForm.ShowDialog() == DialogResult.OK)
        {
            // 处理转账逻辑
            PerformTransfer(transferForm.ToAccountId, transferForm.Amount);
        }
    }

    private int ExtractAccountIdFromContact(string contact)
    {
        var match = System.Text.RegularExpressions.Regex.Match(contact, @"账户ID: (\d+)");
        if (match.Success)
        {
            return int.Parse(match.Groups[1].Value);
        }
        return -1; // 其他错误处理
    }

    private void PerformTransfer(int toAccountId, decimal amount)
    {
        int fromAccountId = userManager.CurrentUserId; // 假设当前用户ID即为转出账户ID
        if (accountManager.Transfer(fromAccountId, toAccountId, amount))
        {
            MessageBox.Show("转账成功");
        }
        else
        {
            MessageBox.Show("转账失败");
        }
    }

    private void BankForm_Load(object sender, EventArgs e)
    {
        // 窗体加载时的逻辑（如果有）
    }


    private void transactionHistoryButton_Click(object sender, EventArgs e)
    {
        try
        {
            int currentUserId = userManager.CurrentUserId;
            int accountId = accountManager.GetAccountIdByUserId(currentUserId);
            var transactions = accountManager.GetTransactionHistory(accountId);

            TransactionHistoryForm historyForm = new TransactionHistoryForm();
            historyForm.LoadTransactionData(transactions); // 加载交易数据
            historyForm.ShowDialog(); // 显示交易历史窗口
        }
        catch (Exception ex)
        {
            MessageBox.Show("无法加载交易记录: " + ex.Message);
        }
    }

    private void viewTransactionsButton_Click(object sender, EventArgs e)
    {
        ShowTransactionHistory();
    }

    private void ShowTransactionHistory()
    {
        try
        {
            int currentUserId = userManager.CurrentUserId;
            int accountId = accountManager.GetAccountIdByUserId(currentUserId);
            var transactions = accountManager.GetTransactionHistory(accountId);

            TransactionHistoryForm historyForm = new TransactionHistoryForm();
            historyForm.LoadTransactionData(transactions); // 加载交易数据
            historyForm.ShowDialog(); // 显示交易历史窗口
        }
        catch (Exception ex)
        {
            MessageBox.Show("无法加载交易记录: " + ex.Message);
        }
    }
}
