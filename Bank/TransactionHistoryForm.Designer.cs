namespace Bank
{
    partial class TransactionHistoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewTransactions;

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
            dataGridViewTransactions = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransactions).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTransactions
            // 
            dataGridViewTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTransactions.Location = new Point(19, 19);
            dataGridViewTransactions.Margin = new Padding(5);
            dataGridViewTransactions.Name = "dataGridViewTransactions";
            dataGridViewTransactions.RowHeadersWidth = 4;
            dataGridViewTransactions.RowTemplate.Height = 28;
            dataGridViewTransactions.Size = new Size(2054, 800);
            dataGridViewTransactions.TabIndex = 0;
            // 
            // TransactionHistoryForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2106, 800);
            Controls.Add(dataGridViewTransactions);
            Margin = new Padding(5);
            Name = "TransactionHistoryForm";
            Text = "资金交易记录";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransactions).EndInit();
            ResumeLayout(false);
        }
    }
}
