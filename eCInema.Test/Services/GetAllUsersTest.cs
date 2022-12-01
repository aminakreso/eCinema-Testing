using AutoMapper;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using eCinema.Services.Profiles;
using eCinema.Services.Services;
using eCInema.Test.Data;

namespace eCInema.Test.Services
{
    // Admir Numanović
    public sealed class GetAllUsersTest : IDisposable
    {
        private readonly CinemaContext _databaseContextMock;
        private readonly UserService _systemUnderTest;
        private readonly IMapper _mapper;


        public GetAllUsersTest()
        {
            _databaseContextMock = InMemoryDatabaseFactory.CreateInMemoryDatabase();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());

            var mapper = new Mapper(config);

            _systemUnderTest = new UserService(_databaseContextMock, mapper);

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
            for (int i = 0; i < listOfUsers.Count(); i++)
            {
                Assert.Equal(listOfUsers[i].Username, allUsers.ToList()[i].Username);
            }
            Assert.Equal(listOfUsers.Count, allUsers.ToList().Count);
        }
        public void Dispose()
        {
            
        }
    }
}
