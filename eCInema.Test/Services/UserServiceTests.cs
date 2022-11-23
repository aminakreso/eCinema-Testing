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
            var expectedRecordCount = listOfUsers.Count + 1;
            Assert.Equal(_databaseContextMock.Users.Count(), expectedRecordCount);
            Assert.Equal(newUser.Username, UserData.userInsertRequestValid.Username);
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
            Assert.Equal(updatedUser.FirstName, UserData.userUpdateRequestValid.FirstName);
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
        public async Task GetAllAsync_WhenCalledWithNoFilterParameters_ReturnsListOfAllUsers()
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

            Assert.Equal(searchedUser.FirstOrDefault().FullName, newUser.FullName);
        }

        [Fact]
        public async Task GetAllAsync_WhenCalledFilterParameters_ReturnsEmpty()
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
            Assert.Equal(searchedUser.Count(), 0);

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
            Assert.Equal(getUser.Username, listOfUsers[0].Username);
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
