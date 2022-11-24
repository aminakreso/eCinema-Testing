using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;

namespace eCinema.Services.Services
{
    public class RoleService : BaseService<RoleDto, Role, BaseSearchObject>, IRoleService
    {
        public RoleService(CinemaContext cinemaContext, IMapper mapper) : base(cinemaContext, mapper)
        {
        }
    }
}
