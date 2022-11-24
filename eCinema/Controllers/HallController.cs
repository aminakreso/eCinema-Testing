using eCinema.Model.Dtos;
using eCinema.Model.SearchObjects;
using eCinema.Services.Services;

namespace eCinema.Controllers
{
    public class HallController : BaseController<HallDto, BaseSearchObject>
    {
        public HallController(IHallService service) : base(service)
        {
        }
    }
}
