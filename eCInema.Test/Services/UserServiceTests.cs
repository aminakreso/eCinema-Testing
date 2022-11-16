using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Services.Database;
using eCinema.Services.Profiles;
using eCinema.Services.Services;
using eCInema.Test.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Test.Services
{
    public sealed class UserServiceTests : IDisposable
    {
        private readonly CinemaContext _databaseContextMock;
        private readonly UserService _systemUnderTest;
        private readonly IMapper _mapper;


        public UserServiceTests()
        {
            _databaseContextMock = InMemoryDatabaseFactory.CreateInMemoryDatabase();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());

            var mapper = new Mapper(config);

            _systemUnderTest = new UserService(_databaseContextMock, mapper);

        }

        [Fact]
        public async Task AddUserAsync_WhenCalled_AddsNewUser()
        {
            //Arrange
           var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();

            // Act
            await _systemUnderTest.Insert(UserData.userInsertRequest);

            // Assert
            var expectedRecordCount = listOfUsers.Count + 1;
            Assert.Equal(_databaseContextMock.Users.Count(), expectedRecordCount);

        }



        public void Dispose()
        {
            
        }
    }
}
