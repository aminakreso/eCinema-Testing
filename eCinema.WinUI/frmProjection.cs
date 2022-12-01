using eCinema.Model.Constants;
using eCinema.Model.Dtos;
using eCinema.Model.SearchObjects;

namespace eCinema.WinUI
{
    public partial class frmProjection : Form
    {
        private APIService _projectionService = new APIService("Projection");
        private APIService _movieService = new APIService("Movie");
        private APIService _hallService = new APIService("Hall");

        public frmProjection()
        {
            InitializeComponent();
            dgvProjection.AutoGenerateColumns = false;
        }

        private void dgvProjection_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var projection = (ProjectionDto)(this.dgvProjection.Rows[e.RowIndex]
                    .DataBoundItem);

               if(projection is not null)
                {
                    if (projection.Movie is not null && e.ColumnIndex == 0)
                    {
                        e.Value = projection.Movie.Name;
                    }

                    if (projection.Hall is not null && e.ColumnIndex == 2)
                    {
                        e.Value = projection.Hall.Name;
                    }

                    if (projection.Price is not null && e.ColumnIndex == 3)
                    {
                        e.Value = projection.Price.Name;
                    }
                }
            }
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            var searchObject = new ProjectionSearchObject
            {
                Name = txtName.Text,
                StartTime = dtpDate.Value.Date,
                Status = cmbStatus.Text,
                IncludeHalls = true,
                IncludeMovies = true,
                IncludePrices = true
            };

            if(cmbHall.Text == "Svi")
            {
                searchObject.HallId = Guid.Empty;
            }

            else
            {
                searchObject.HallId = (Guid)cmbHall.SelectedValue;
            }

            var list = await _projectionService.Get<List<ProjectionDto>>(searchObject);
            dgvProjection.DataSource = list;
        }

        private async void frmProjection_Load(object sender, EventArgs e)
        {
            await LoadHalls();
            await LoadStatus();

            cmbHall.SelectedItem = null;
            cmbHall.SelectedText = "Svi";
            cmbStatus.SelectedItem = null;
            cmbStatus.SelectedText = "Svi";
        }

        private async Task LoadHalls()
        {
            var halls = await _hallService.Get<List<HallDto>>();
            cmbHall.DataSource = halls;
            cmbHall.DisplayMember = "Name";
            cmbHall.ValueMember = "Id";
        }  
        private async Task LoadStatus()
        {
            cmbStatus.DataSource = ProjectionStatus.ListOfStatuses;
        }

        private void dgvProjection_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var projection = dgvProjection.SelectedRows[0].DataBoundItem as ProjectionDto;

            var frmProjectionDetails = new frmProjectionDetails(projection);
            frmProjectionDetails.ShowDialog();
        }
    }
}
