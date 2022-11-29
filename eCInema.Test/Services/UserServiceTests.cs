using AutoMapper;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using eCinema.Services.Profiles;
using eCinema.Services.Services;
using eCInema.Test.Data;

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
            Assert.Equal(UserData.userInsertRequestValid.Username, newUser.Username);
            Assert.True(_databaseContextMock.Users.Where(x => x.Username == UserData.userInsertRequestValid.Username).Any());
        }

        [Fact]
        public async Task AddUserAsync_WhenCalled_ThrowsValidationException()
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
        public async Task AddUserAsync_WhenCalled_ThrowsException_WrongConfirmPassword()
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
        public async Task EditUserAsync_WhenCalled_EditUser()
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
            Assert.Equal(UserData.userUpdateRequestValid.FirstName, updatedUser.FirstName);
        }

        [Fact]
        public async Task EditUseAsync_WhenCalled_WrongId_ThrowException()
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
        public async Task LoginUserAsync_WhenCalled_ThrowsException()
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
        public async Task GetAllAsync_WhenCalledFilterParameters_ReturnsUser()
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
                Name = newUser.FirstName
            });

            Assert.Equal(newUser.FullName, searchedUser.FirstOrDefault().FullName);
        }

        [Fact]
        public async Task GetAllAsync_WhenCalledNonExcistingFilterParameters_ReturnsEmpty()
        {
            //Arrange
            var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();


            var searchedUser = await _systemUnderTest.GetAll(new UserSearchObject()
            {
                Name = "InvalidName"
            });
            Assert.Equal(0, searchedUser.Count());

        }

        [Fact]
        public async Task GetByIdAsync_WhenCalled_RetursUser()
        {
            //Arrange
            var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();

            var getUser = await _systemUnderTest.GetById(listOfUsers[0].Id);
            Assert.Equal(listOfUsers[0].Username, getUser.Username);
        }

        [Fact]
        public async Task GetByIdAsync_WhenCalled_RetursNull()
        {
            //Arrange
            var listOfUsers = UserData.Users;
            _databaseContextMock.Users.AddRange(listOfUsers);
            _databaseContextMock.Roles.AddRange(UserData.Roles);
            await _databaseContextMock.SaveChangesAsync();

            //Assert
            await Assert.ThrowsAsync<Exception>(() =>
              _systemUnderTest.GetById(Guid.NewGuid()));
        }

        public void Dispose()
        {
            
        }
    }
}
