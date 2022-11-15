using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;

namespace eCinema.Services.Services
{
    public class PriceService : BaseCRUDService<PriceDto, Price, BaseSearchObject, PriceUpsertRequest, PriceUpsertRequest>,
        IPriceService
    {
        public PriceService(CinemaContext cinemaContext, IMapper mapper) : base(cinemaContext, mapper)
        {
        }

    }
}
