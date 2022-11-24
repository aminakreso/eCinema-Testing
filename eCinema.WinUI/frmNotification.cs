using eCinema.Model.Constants;
using eCinema.Model.Dtos;
using eCinema.Model.SearchObjects;

namespace eCinema.WinUI
{
    public partial class frmNotification : Form
    {
        private APIService _notificationService = new APIService("Notification");
        private APIService _userService = new APIService("User");

        public frmNotification()
        {
            InitializeComponent();
            dgvNotifications.AutoGenerateColumns = false;

        }

        private async void frmNotification_Load(object sender, EventArgs e)
        {
            await LoadUsers();
            await LoadTypes();

            cmbAuthor.SelectedItem = null;
            cmbAuthor.SelectedText = "Svi";
            cmbNotificationType.SelectedItem = null;
            cmbNotificationType.SelectedText = "Svi";

        }

        private async Task LoadTypes()
        {
            var typesList = NotificationTypes.ListOfNotificationTypes;
            cmbNotificationType.DataSource = typesList;
        }

        private async Task LoadUsers()
        {
            var users = await _userService.Get<List<UserDto>>();
            cmbAuthor.DataSource = users;
            cmbAuthor.DisplayMember = "FullName";
            cmbAuthor.ValueMember = "Id";
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            var searchObject = new NotificationSearchObject();
            searchObject.Title = txtTitle.Text;

            if(cmbAuthor.SelectedItem is not null)
            {
                searchObject.AuthorId = (Guid)cmbAuthor.SelectedValue;
            }
            else
            {
                searchObject.AuthorId = Guid.Empty;
            }

            searchObject.NotificationType = cmbNotificationType.Text;

            var list = await _notificationService.Get<List<NotificationDto>>(searchObject);
            dgvNotifications.DataSource = list;

        }

        private void dgvNotifications_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var notification = dgvNotifications.SelectedRows[0].DataBoundItem as NotificationDto;

            var frmNotificationDetails = new frmNotificationDetails(notification);
            frmNotificationDetails.ShowDialog();
        }
    }
}
