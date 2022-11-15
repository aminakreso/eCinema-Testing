using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Services;

namespace eCinema.Controllers
{
    public class MovieController : BaseCRUDController<MovieDto, MovieSearchObject, MovieUpsertRequest, MovieUpsertRequest>
    {
        public MovieController(IMovieService movieService)
            : base(movieService)
        {
        }

    }
}
