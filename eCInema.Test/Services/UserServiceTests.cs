using AutoMapper;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using eCinema.Services.Profiles;
using eCinema.Services.Services;
using eCInema.Test.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            var newUser = await _systemUnderTest.Insert(UserData.userInsertRequestValid);

            // Assert
            var expectedRecordCount = listOfUsers.Count + 1;
            Assert.Equal(_databaseContextMock.Users.Count(), expectedRecordCount);
            Assert.Equal(newUser.Username, UserData.userInsertRequestValid.Username);
        }

        [Fact]
        public async Task AddUserAsync_WhenCalled_AddsNewUser_ThrowsValidationException()
        {
            //Arrange
            var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();

            // Assert
            await Assert.ThrowsAsync<Exception>(() =>
                _systemUnderTest.Insert(UserData.userInsertRequestInvalidRole));
        }

        [Fact]
        public async Task AddUserUserAsync_WhenCalled_AddNewUser_ThrowsException_WrongConfirmPassword()
        {
            //Arrange
            var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();

            // Assert
            await Assert.ThrowsAsync<Exception>(() =>
                _systemUnderTest.Insert(UserData.userInsertRequestWrongConfirmPassword));
        }

        [Fact]
        public async Task EditUserUserAsync_WhenCalled_EditUser()
        {
            //Arrange
            var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();

            var newUser = await _systemUnderTest.Insert(UserData.userInsertRequestValid);
            var updatedUser = await _systemUnderTest.Update(newUser.Id, UserData.userUpdateRequestValid);
            // Assert
            Assert.NotEqual(newUser.FirstName, updatedUser.FirstName);
            Assert.Equal(updatedUser.FirstName, UserData.userUpdateRequestValid.FirstName);
        }

        [Fact]
        public async Task EditUserUserAsync_WhenCalled_EditUser_WrongId_ThrowException()
        {
            //Arrange
            var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();

            var newUser = await _systemUnderTest.Insert(UserData.userInsertRequestValid);
            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                         _systemUnderTest.Update(Guid.NewGuid(), UserData.userUpdateRequestValid));
        }

        [Fact]
        public async Task LoginUserAsync_WhenCalled_Login()
        {
            //Arrange
            var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();

            var newUser = await _systemUnderTest.Insert(UserData.userInsertRequestValid);

            // Assert
            Assert.NotNull(_systemUnderTest.Login(newUser.Username, UserData.userInsertRequestValid.Password));
        }

        [Fact]
        public async Task LoginUserAsync_WhenCalled_Login_ThrowsException()
        {
            //Arrange
            var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();

            var newUser = await _systemUnderTest.Insert(UserData.userInsertRequestValid);

            // Assert
            await Assert.ThrowsAsync<Exception>(() =>
                _systemUnderTest.Login(newUser.Username, "wrongPassword"));
        }

        [Fact]
        public async Task GetAllUsersAsync()
        {
            //Arrange
            var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();

            // Assert
            var allUsers = await _systemUnderTest.GetAll();
            for (int i = 0; i < allUsers.Count(); i++)
            {
                Assert.Equal(listOfUsers[i].Username, allUsers.ToList()[i].Username);
            }
            Assert.Equal(allUsers.ToList().Count, listOfUsers.Count);
        }

        [Fact]
        public async Task GetAllUsers_Filter_Async()
        {
            //Arrange
            var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();

            var newUser = await _systemUnderTest.Insert(UserData.userInsertRequestValid);

            // Assert
            var searchedUser = await _systemUnderTest.GetAll(new UserSearchObject()
            {
                Name = newUser.FullName
            });

            Assert.Equal(searchedUser.FirstOrDefault().FullName, newUser.FullName);
        }

        [Fact]
        public async Task GetAllUsers_Filter_ReturnsEmpty_Async()
        {
            //Arrange
            var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();

            Assert.Equal(0,1);
        }

        [Fact]
        public async Task GetById_Async()
        {
            //Arrange
            var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();

            var getUser = await _systemUnderTest.GetById(listOfUsers[0].Id);
            Assert.Equal(getUser.Username, listOfUsers[0].Username);
        }

        [Fact]
        public async Task GetById_WrongId_Async()
        {
            //Arrange
            var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();

            var getUser = await _systemUnderTest.GetById(Guid.NewGuid());
            Assert.Null(getUser);
        }

        public void Dispose()
        {
            
        }
    }
}
