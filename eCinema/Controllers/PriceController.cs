using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Services;

namespace eCinema.Controllers
{
    public class PriceController : BaseCRUDController<PriceDto, BaseSearchObject, PriceUpsertRequest, PriceUpsertRequest>
    {
        public PriceController(IPriceService priceService)
            : base(priceService)
        {
        }

    }
}
