using eCinema.Model.Constants;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;

namespace eCinema.WinUI
{
    public partial class frmNotificationDetails : Form
    {
        private APIService _notificationService = new APIService("Notification");
        public frmNotificationDetails(NotificationDto model = null)
        {
            InitializeComponent();
            _model = model;
        }

        private NotificationDto _model = null;

        private async void frmNotificationDetails_Load(object sender, EventArgs e)
        {
            if(_model is not null)
            {
                txtTitle.Text = _model.Title;
                txtContent.Text = _model.Content;
                cmbNotificationType.Text = _model.NotificationType;
            }
            await LoadTypes();
        }



        private async Task LoadTypes()
        {
            var typesList = NotificationTypes.ListOfNotificationTypes;
            cmbNotificationType.DataSource = typesList;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(_model is null)
            {
                var insert = new NotificationInsertRequest()
                {
                    Title = txtTitle.Text,
                    Content = txtContent.Text,
                    NotificationType = cmbNotificationType.Text
                };

                await _notificationService.Post<NotificationDto>(insert);
            }
            else
            {
                var update = new NotificationUpdateRequest()
                {
                    Title = txtTitle.Text,
                    Content = txtContent.Text,
                    NotificationType = cmbNotificationType.Text,
                };

                _model = await _notificationService.Put<NotificationDto>(_model.Id,update);
            }
        }
    }
}
