using eCinema.Model.Dtos;
using eCinema.Model.Requests;

namespace eCinema.WinUI
{
    public partial class frmUserDetails : Form
    {
        private APIService _userService = new APIService("User");
        private readonly APIService _roleService = new APIService("Role");
        public frmUserDetails(UserDto model = null)
        {
            InitializeComponent();
            _model = model;
        }

        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            await LoadRoles();

            if (_model is not null)
            {
                txtFirstName.Text = _model.FirstName;
                txtLastName.Text = _model.LastName;
                txtEmail.Text = _model.Email;
                txtPhoneNumber.Text = _model.PhoneNumber;
                txtUsername.Text = _model.Username;
                txtPassword.Text = _model.Password;
                txtConfirmPassword.Text = _model.ConfirmPassword;
                cmbRole.Text = _model.Role?.Name;
                cbIsActive.Checked = _model.IsActive.GetValueOrDefault(false);
            }
        }

        private UserDto _model = null;


        public async Task LoadRoles()
        {
            var roles = await _roleService.Get<List<RoleDto>>();
            cmbRole.DataSource = roles;
            cmbRole.DisplayMember = "Name";
            cmbRole.ValueMember = "Id";
            
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                throw new Exception("Validation failed!");

            var roleId = (Guid)cmbRole.SelectedValue;

            if(_model is null)
            {
                var insert = new UserInsertRequest
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    ConfirmPassword = txtConfirmPassword.Text,
                    RoleId = roleId,
                    IsActive = cbIsActive.Checked,
                };

                var user = await _userService.Post<UserDto>(insert);
            }
            else
            {
                var update = new UserUpdateRequest
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Password = txtPassword.Text,
                    ConfirmPassword = txtConfirmPassword.Text,
                    RoleId = roleId,
                    IsActive = cbIsActive.Checked,
                };

                _model = await _userService.Put<UserDto>(_model.Id, update);
            }
        }
    }
}
