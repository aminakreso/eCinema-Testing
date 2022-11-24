using eCinema.Model.Requests;
using eCinema.Services.Database;

namespace eCInema.Test.Data
{
    public static class UserData
    {
        public static readonly List<Role> Roles = new()
        {
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "User",
            }
        };
        public static readonly List<User> Users = new()
        {
            new User
            {
                Id = Guid.NewGuid(),
                Username = "UserName",
                FirstName = "FirstName",
                LastName = "LastName",
                IsActive = true,
                Email = "user@gmail.com",
                PhoneNumber = "23426-2345",
                RoleId = Roles[0].Id
            },
            new User
            {
                Id = Guid.NewGuid(),
                Username = "UserName2",
                FirstName = "FirstName2",
                LastName = "LastName2",
                IsActive = true,
                Email = "user@gmail.com",
                PhoneNumber = "23426-2345",
                RoleId = Roles[1].Id
            }

        };

        public static readonly UserInsertRequest userInsertRequestValid = new UserInsertRequest()
        {
            Username = "UserName3",
            FirstName = "FirstName3",
            LastName = "LastName3",
            IsActive = true,
            Email = "user@gmail.com",
            PhoneNumber = "23426-2345",
            RoleId = Roles[1].Id,
            Password = "ysss",
            ConfirmPassword = "ysss"
        };

        public static readonly UserInsertRequest userInsertRequestInvalidRole = new UserInsertRequest()
        {
            Username = "UserName3",
            FirstName = "FirstName3",
            LastName = "LastName3",
            IsActive = true,
            Email = "user@gmail.com",
            PhoneNumber = "23426-2345",
            RoleId = Guid.NewGuid(),
            Password = "ysss",
            ConfirmPassword = "ysss"
        };

        public static readonly UserInsertRequest userInsertRequestWrongConfirmPassword = new UserInsertRequest()
        {
            Username = "UserName3",
            FirstName = "FirstName3",
            LastName = "LastName3",
            IsActive = true,
            Email = "user@gmail.com",
            PhoneNumber = "23426-2345",
            RoleId = Guid.NewGuid(),
            Password = "Password",
            ConfirmPassword = "WorngConfirmPassword"
        };

        public static readonly UserUpdateRequest userUpdateRequestValid = new UserUpdateRequest()
        {
            FirstName = "UpdatedFirstName",
            LastName = "LastName3",
            IsActive = true,
            Email = "user@gmail.com",
            PhoneNumber = "23426-2345",
            RoleId = Roles[1].Id,
            Password = "ysss",
            ConfirmPassword = "ysss"
        };
    }
}
