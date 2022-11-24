using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;

namespace eCinema.Services.Services
{
    public class HallService : BaseService<HallDto, Hall, BaseSearchObject>, IHallService
    {
        public HallService(CinemaContext cinemaContext, IMapper mapper) : base(cinemaContext, mapper)
        {
        }
    }
}
