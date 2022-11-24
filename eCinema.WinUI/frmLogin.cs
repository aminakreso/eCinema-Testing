namespace eCinema.WinUI
{
    public partial class frmLogin : Form
    {
        private readonly APIService _userService = new APIService("User");

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.Username = txtUsername.Text;
            APIService.Password = txtPassword.Text;

            await _userService.Get<dynamic>();

            mdiMain frm = new mdiMain();
            frm.Show();
        }
    }
}
