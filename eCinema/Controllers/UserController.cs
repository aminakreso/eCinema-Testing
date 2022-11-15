using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Services;
using Microsoft.AspNetCore.Authorization;

namespace eCinema.Controllers
{
    public class UserController : BaseCRUDController<UserDto, UserSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        public UserController(IUserService userService)
            : base(userService)
        {
        }

        [Authorize(Roles = "Admin")]
        public override async Task<UserDto> Insert(UserInsertRequest insert)
        {
            return await base.Insert(insert);
        }
    }
}
