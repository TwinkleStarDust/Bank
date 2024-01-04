using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bank
{
    public partial class TransactionHistoryForm : Form
    {
        public TransactionHistoryForm()
        {
            InitializeComponent();
            SetupDataGridViewColumns();
        }

        private void SetupDataGridViewColumns()
        {
            dataGridViewTransactions.AutoGenerateColumns = false;

            // 添加列
            dataGridViewTransactions.Columns.Add("TransactionId", "操作编号");
            dataGridViewTransactions.Columns.Add("FromAccountId", "付款账户");
            dataGridViewTransactions.Columns.Add("ToAccountId", "接受账户");
            dataGridViewTransactions.Columns.Add("Amount", "金额");
            dataGridViewTransactions.Columns.Add("TransactionType", "操作类型");
            dataGridViewTransactions.Columns.Add("Description", "操作属性");
            dataGridViewTransactions.Columns.Add("Timestamp", "交易时间");

            // 设置数据属性名称，匹配TransactionRecord 类的属性
            dataGridViewTransactions.Columns["TransactionId"].DataPropertyName = "TransactionId";
            dataGridViewTransactions.Columns["FromAccountId"].DataPropertyName = "FromAccountId";
            dataGridViewTransactions.Columns["ToAccountId"].DataPropertyName = "ToAccountId";
            dataGridViewTransactions.Columns["Amount"].DataPropertyName = "Amount";
            dataGridViewTransactions.Columns["TransactionType"].DataPropertyName = "TransactionType";
            dataGridViewTransactions.Columns["Description"].DataPropertyName = "Description";
            dataGridViewTransactions.Columns["Timestamp"].DataPropertyName = "Timestamp";
        }

        public void LoadTransactionData(List<TransactionRecord> transactions)
        {
            dataGridViewTransactions.DataSource = transactions;
        }
    }
}
