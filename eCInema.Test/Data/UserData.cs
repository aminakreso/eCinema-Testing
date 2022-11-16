using eCinema.Model.Requests;
using eCinema.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static readonly UserInsertRequest userInsertRequest = new UserInsertRequest()
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
    }
}
