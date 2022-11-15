using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCinema.WinUI
{
    public partial class frmUsers : Form
    {
        private APIService _userService = new APIService("User");
        private APIService _roleService = new APIService("Role");

        public frmUsers()
        {
            InitializeComponent();
            dgvUsers.AutoGenerateColumns = false;
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            var searchObject = new UserSearchObject();
            searchObject.Name= txtName.Text;
            searchObject.Role= cmbRoles.Text;
            searchObject.IncludeRoles = true;

            switch (cmbIsActive.Text)
            {
                case "Aktivni": searchObject.IsActive = true; break;
                case "Neaktivni": searchObject.IsActive = false; break;
                default: searchObject.IsActive = null;
                    break;
            }

            var list = await _userService.Get<List<UserDto>>(searchObject);
            dgvUsers.DataSource=list;
        }

        private async void frmUsers_Load(object sender, EventArgs e)
        {
            await LoadRoles();
            await LoadIsActive();
            cmbRoles.SelectedItem = null;
            cmbRoles.SelectedText = "Svi";
           
        }

        public async Task LoadRoles()
        {
            var roles = await _roleService.Get<List<RoleDto>>();
            cmbRoles.DataSource = roles;
            cmbRoles.DisplayMember = "Name";
        }

        public async Task LoadIsActive()
        {
            var list = new List<string> { "Svi", "Aktivni", "Neaktivni" };
            cmbIsActive.DataSource = list;
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var user = dgvUsers.SelectedRows[0].DataBoundItem as UserDto;

            var frmUserDetails = new frmUserDetails(user);
            frmUserDetails.ShowDialog();
        }
    }
}
