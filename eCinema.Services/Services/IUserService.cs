using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;

namespace eCinema.Services.Services
{
    public interface IUserService : ICRUDService<UserDto, UserSearchObject,
       UserInsertRequest, UserUpdateRequest>
    {
        Task<UserDto> Login(string username, string password);
    }
}
