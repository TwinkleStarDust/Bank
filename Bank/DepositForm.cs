using System;
using System.Windows.Forms;

public partial class DepositForm : Form
{
    private AccountManager accountManager;
    private int currentUserId;

    public DepositForm(AccountManager accountManager, int currentUserId)
    {
        InitializeComponent();
        this.accountManager = accountManager;
        this.currentUserId = currentUserId;

        // 初始化存款类型下拉菜单
        depositTypeComboBox.Items.Add("活期");
        depositTypeComboBox.Items.Add("定期");

        // 初始化存款期限下拉菜单
        depositTermComboBox.Items.Add("3个月");
        depositTermComboBox.Items.Add("6个月");
        depositTermComboBox.Items.Add("一年");
        depositTermComboBox.Items.Add("两年");
        depositTermComboBox.Items.Add("三年");
        depositTermComboBox.Items.Add("五年");
    }

    private void depositButton_Click(object sender, EventArgs e)
    {
        try
        {
            decimal amount = decimal.Parse(amountTextBox.Text);
            string depositType = depositTypeComboBox.SelectedItem.ToString();
            string depositTerm = depositType == "定期" ? depositTermComboBox.SelectedItem.ToString() : null; // 仅当选择定期时获取存款期限

            // 调用 AccountManager 来处理存款
            accountManager.ManageDeposit(currentUserId, amount, depositType, depositTerm);

            MessageBox.Show("存款成功");
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("存款失败: " + ex.Message);
        }
    }
}
