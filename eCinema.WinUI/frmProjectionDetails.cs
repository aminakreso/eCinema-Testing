using eCinema.Model.Constants;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
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
    public partial class frmProjectionDetails : Form
    {
        private APIService _projectionService = new APIService("Projection");
        private APIService _movieService = new APIService("Movie");
        private APIService _hallService = new APIService("Hall");
        private APIService _priceService = new APIService("Price");

        public frmProjectionDetails(ProjectionDto model = null)
        {
            InitializeComponent();
            _model = model;
        }

        private async void frmProjectionDetails_Load(object sender, EventArgs e)
        {
            await LoadHalls();
            await LoadMovies();
            await LoadPrices();
            await LoadTypes();

            if(_model is not null)
            {
                cmbHall.SelectedValue = _model.HallId;
                cmbMovieName.SelectedValue = _model.MovieId;
                cmbPrice.SelectedValue = _model.PriceId;
                cmbProjectionType.Text = _model?.ProjectionType;
                dtpProjectionDateTime.Value = _model.DateTime.GetValueOrDefault(DateTime.Now);
            }
            LoadButtons();

        }

        private void LoadButtons()
        {
            if(_model?.StateMachine is null)
            {
                btnActivate.Visible = false;
                btnHide.Visible = false;

            }

            if (_model?.StateMachine == StateMachineConstants.DraftState)
            {
                btnHide.Visible = false;
            }

            if (_model?.StateMachine == StateMachineConstants.ActiveState)
            {
                btnActivate.Visible = false;
                btnSave.Visible = false;
                cmbHall.Enabled = false;
                cmbMovieName.Enabled = false;
                cmbPrice.Enabled = false;
                cmbProjectionType.Enabled = false;
                dtpProjectionDateTime.Enabled = false;
            }
            //za soft delete neki x na vrhu??
            if (_model?.StateMachine == StateMachineConstants.HiddenState)
            {
                btnHide.Visible = false;
            }

            if (_model?.StateMachine == StateMachineConstants.DeletedState)
            {
                btnActivate.Visible = false;
                btnHide.Visible=false;
                btnSave.Visible = false;
                cmbHall.Enabled = false;
                cmbMovieName.Enabled = false;
                cmbPrice.Enabled = false;
                cmbProjectionType.Enabled = false;
                dtpProjectionDateTime.Enabled = false;
            }

        }

        private ProjectionDto _model = null;

        private async Task LoadHalls()
        {
            var halls = await _hallService.Get<List<HallDto>>();
            cmbHall.DataSource = halls;
            cmbHall.DisplayMember = "Name";
            cmbHall.ValueMember = "Id";
        }

        private async Task LoadMovies()
        {
            var movies = await _movieService.Get<List<MovieDto>>();
            cmbMovieName.DataSource = movies;
            cmbMovieName.DisplayMember = "Name";
            cmbMovieName.ValueMember = "Id";
        }

        private async Task LoadPrices()
        {
            var prices = await _priceService.Get<List<PriceDto>>();
            cmbPrice.DataSource = prices;
            cmbPrice.DisplayMember = "Name";
            cmbPrice.ValueMember = "Id";
        }
        private async Task LoadTypes()
        {
            cmbProjectionType.DataSource = ProjectionTypes.ListTypes;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var upsert = new ProjectionUpsertRequest()
            {
                DateTime = dtpProjectionDateTime.Value,
                ProjectionType = cmbProjectionType.Text,
                HallId = (Guid)cmbHall?.SelectedValue,
                PriceId = (Guid)cmbPrice?.SelectedValue,
                MovieId = (Guid?)cmbMovieName?.SelectedValue,
            };

            if (_model is null)
            {
                await _projectionService.Post<ProjectionDto>(upsert);
            }
            else
            {
                _model = await _projectionService.Put<ProjectionDto>(_model.Id, upsert);
            }
        }
    }
}
