using eCinema.Model.Dtos;
using eCinema.Model.SearchObjects;
using eCinema.Services.Services;

namespace eCinema.Controllers
{
    public class RoleController : BaseController<RoleDto, BaseSearchObject>
    {
        public RoleController(IRoleService roleService) : base(roleService)
        {
        }
    }
}
