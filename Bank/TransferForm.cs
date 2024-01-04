using System;
using System.Windows.Forms;

namespace Bank
{
    public partial class TransferForm : Form
    {
        public int ToAccountId { get; private set; }
        public decimal Amount { get; private set; }

        public TransferForm()
        {
            InitializeComponent();
        }

        // 设置接收方账户ID
        public void SetRecipientAccountId(int accountId)
        {
            ToAccountId = accountId;
            toAccountIdTextBox.Text = accountId.ToString();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                ToAccountId = int.Parse(toAccountIdTextBox.Text);
                Amount = decimal.Parse(amountTextBox.Text);

                if (ToAccountId <= 0 || Amount <= 0)
                {
                    MessageBox.Show("请输入正确地账户和金额");
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("请输入合理的数值");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
