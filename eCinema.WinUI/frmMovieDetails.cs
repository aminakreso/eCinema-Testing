using eCinema.Model.Dtos;
using eCinema.Model.Requests;

namespace eCinema.WinUI
{
    public partial class frmMovieDetails : Form
    {
        private APIService _movieService = new APIService("Movie");
        public frmMovieDetails(MovieDto model = null)
        {
            InitializeComponent();
            _model = model;
        }

        private MovieDto _model = null;

        private async void frmMovieDetails_Load(object sender, EventArgs e)
        {
            if (_model is not null)
            {
                txtName.Text = _model.Name;
                txtGenres.Text = _model.Genres;
                txtReleaseYear.Text = _model.ReleaseYear.ToString();
                txtDuration.Text = _model.Duration.ToString();
                txtDirector.Text = _model.Director;
                txtDescription.Text = _model.Description;
                txtCountry.Text = _model.Country;
                txtActors.Text = _model.Actors;
                cbIsActive.Checked = _model.IsActive.GetValueOrDefault(false);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var upsert = new MovieUpsertRequest()
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Actors = txtActors.Text,
                Director = txtDirector.Text,
                Country = txtDirector.Text,
                Genres = txtGenres.Text

            };

            if (!string.IsNullOrWhiteSpace(txtDuration?.Text))
                upsert.Duration = Convert.ToInt32(txtDuration?.Text);

            if (!string.IsNullOrWhiteSpace(txtReleaseYear?.Text))
                upsert.ReleaseYear = Convert.ToInt32(txtReleaseYear?.Text);


            if (_model is null)
            {
                await _movieService.Post<MovieDto>(upsert);
            }
            else
            {
                _model = await _movieService.Put<MovieDto>(_model.Id, upsert);
            }
        }
    }
}
