namespace Bank
{
    partial class TransferForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelToAccountId;
        private System.Windows.Forms.TextBox toAccountIdTextBox;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Button confirmButton;

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
            this.components = new System.ComponentModel.Container();
            this.labelToAccountId = new System.Windows.Forms.Label();
            this.toAccountIdTextBox = new System.Windows.Forms.TextBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();

            // labelToAccountId
            this.labelToAccountId.AutoSize = true;
            this.labelToAccountId.Location = new System.Drawing.Point(20, 20);
            this.labelToAccountId.Name = "labelToAccountId";
            this.labelToAccountId.Size = new System.Drawing.Size(100, 13);
            this.labelToAccountId.TabIndex = 0;
            this.labelToAccountId.Text = "请输入对方账户ID :";

            // toAccountIdTextBox
            this.toAccountIdTextBox.Location = new System.Drawing.Point(130, 17);
            this.toAccountIdTextBox.Name = "toAccountIdTextBox";
            this.toAccountIdTextBox.Size = new System.Drawing.Size(150, 20);
            this.toAccountIdTextBox.TabIndex = 1;

            // labelAmount
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(20, 50);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(100, 13);
            this.labelAmount.TabIndex = 2;
            this.labelAmount.Text = "转账金额:";

            // amountTextBox
            this.amountTextBox.Location = new System.Drawing.Point(130, 47);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(150, 20);
            this.amountTextBox.TabIndex = 3;

            // confirmButton
            this.confirmButton.Location = new System.Drawing.Point(100, 80);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(100, 23);
            this.confirmButton.TabIndex = 4;
            this.confirmButton.Text = "确认转账";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);

            // TransferForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 120);
            this.Controls.Add(this.labelToAccountId);
            this.Controls.Add(this.toAccountIdTextBox);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.confirmButton);
            this.Name = "TransferForm";
            this.Text = "转账页面";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
