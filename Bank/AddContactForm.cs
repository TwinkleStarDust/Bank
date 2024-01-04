public partial class AddContactForm : Form
{
    private ContactManager contactManager;
    private int currentUserId;

    public AddContactForm(ContactManager contactManager, int currentUserId)
    {
        InitializeComponent();
        this.contactManager = contactManager;
        this.currentUserId = currentUserId;
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        // 获取用户输入的联系人信息
        int contactAccountId;
        if (!int.TryParse(contactAccountIdTextBox.Text, out contactAccountId))
        {
            MessageBox.Show("请输入联系人账户ID");
            return;
        }
        string contactUsername = contactUsernameTextBox.Text;

        if (string.IsNullOrWhiteSpace(contactUsername))
        {
            MessageBox.Show("备注");
            return;
        }

        // 添加或更新联系人
        try
        {
            contactManager.AddContact(currentUserId, contactAccountId, contactUsername);
            MessageBox.Show("联系人添加或更新成功");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("添加或更新联系人失败: " + ex.Message);
        }
    }


}
