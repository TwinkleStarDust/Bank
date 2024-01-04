partial class AdminForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.DataGridView usersDataGridView;
    private System.Windows.Forms.Button addButton;
    private System.Windows.Forms.Button editButton;
    private System.Windows.Forms.Button deleteButton;
    private System.Windows.Forms.TextBox searchTextBox;
    private System.Windows.Forms.Button searchButton;

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
        usersDataGridView = new DataGridView();
        addButton = new Button();
        editButton = new Button();
        deleteButton = new Button();
        searchTextBox = new TextBox();
        searchButton = new Button();
        ((System.ComponentModel.ISupportInitialize)usersDataGridView).BeginInit();
        SuspendLayout();
        // 
        // usersDataGridView
        // 
        usersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        usersDataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
        usersDataGridView.Location = new Point(28, 29);
        usersDataGridView.Margin = new Padding(7);
        usersDataGridView.Name = "usersDataGridView";
        usersDataGridView.RowHeadersWidth = 82;
        usersDataGridView.Size = new Size(1307, 596);
        usersDataGridView.TabIndex = 0;
        // addButton
        addButton.Location = new Point(189, 639);
        addButton.Margin = new Padding(7);
        addButton.Name = "addButton";
        addButton.Size = new Size(175, 55);
        addButton.TabIndex = 1;
        addButton.Text = "添加";
        addButton.UseVisualStyleBackColor = true;
        addButton.Click += addButton_Click; 
        // deleteButton
        deleteButton.Location = new Point(394, 639);
        deleteButton.Margin = new Padding(7);
        deleteButton.Name = "deleteButton";
        deleteButton.Size = new Size(175, 55);
        deleteButton.TabIndex = 3;
        deleteButton.Text = "删除";
        deleteButton.UseVisualStyleBackColor = true;
        deleteButton.Click += deleteButton_Click;
        // searchTextBox
        searchTextBox.Location = new Point(595, 644);
        searchTextBox.Margin = new Padding(7);
        searchTextBox.Name = "searchTextBox";
        searchTextBox.Size = new Size(345, 38);
        searchTextBox.TabIndex = 4;
        // searchButton
        searchButton.Location = new Point(959, 639);
        searchButton.Margin = new Padding(7);
        searchButton.Name = "searchButton";
        searchButton.Size = new Size(175, 55);
        searchButton.TabIndex = 5;
        searchButton.Text = "搜索";
        searchButton.UseVisualStyleBackColor = true;
        searchButton.Click += searchButton_Click; 
        // 
        // AdminForm
        // 
        AutoScaleDimensions = new SizeF(14F, 31F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1363, 742);
        Controls.Add(usersDataGridView);
        Controls.Add(addButton);
        Controls.Add(editButton);
        Controls.Add(deleteButton);
        Controls.Add(searchTextBox);
        Controls.Add(searchButton);
        Margin = new Padding(7);
        Name = "AdminForm";
        Text = "管理员页面";
        ((System.ComponentModel.ISupportInitialize)usersDataGridView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
