using eCinema.Model.Constants;
using eCinema.Model.Dtos;
using eCinema.Model.SearchObjects;

namespace eCinema.WinUI
{
    public partial class frmMovies : Form
    {
        private APIService _movieService = new APIService("Movie");

        public frmMovies()
        {
            InitializeComponent();
            dgvMovies.AutoGenerateColumns = false;
        }

        private async void frmMovies_Load(object sender, EventArgs e)
        {
            await LoadGenres();
            cmbGenre.SelectedItem = null;
            cmbGenre.SelectedText = "Svi";
        }

        private async Task LoadGenres()
        {
            var genresList = Genres.ListOfGenres;
            cmbGenre.DataSource = genresList;
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            var searchObject = new MovieSearchObject();
            searchObject.Name = txtName.Text;
            searchObject.Director = txtDirector.Text;
            searchObject.Genres = cmbGenre.Text;

            var list = await _movieService.Get<List<MovieDto>>(searchObject);
            dgvMovies.DataSource = list;
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var movie = dgvMovies.SelectedRows[0].DataBoundItem as MovieDto;

            var frmMovieDetails = new frmMovieDetails(movie);
            frmMovieDetails.ShowDialog();
        }
    }
}
