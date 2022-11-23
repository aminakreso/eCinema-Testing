namespace eCInema.Test.Services
{
    using AutoMapper;
    using eCinema.Model.SearchObjects;
    using eCinema.Services.Database;
    using eCinema.Services.Profiles;
    using eCinema.Services.ProjectionStateMachine;
    using eCinema.Services.Services;
    using eCInema.Test.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;

    public sealed class ProjectionServiceTests : IDisposable
    {
        private readonly CinemaContext _databaseContextMock;
        private readonly ProjectionService _systemUnderTest;
        private readonly IServiceProvider _serviceProvider;


        public ProjectionServiceTests()
        {
            _databaseContextMock = InMemoryDatabaseFactory.CreateInMemoryDatabase();

            var serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());

            var mapper = new Mapper(config);
            var baseProjectionState = new BaseProjectionState(mapper, serviceProvider, _databaseContextMock);

            _systemUnderTest = new ProjectionService(_databaseContextMock, mapper, baseProjectionState);
        }

        [Fact]
        public async Task GetAllAsync_WhenCalledWithNoFilterParameters_ReturnsListOfAllProjections()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            var projectionList =
                await _systemUnderTest.GetAll();

            // Assert
            Assert.Equal(ProjectionData.Projections.Count, projectionList.Count());
        }

        [Fact]
        public async Task GetAllAsync_WhenCalledWithOneFilterParameter_ShouldReturnSpecificProjection()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            var dateTime = ProjectionData.Projections[2].DateTime;
            var hall = ProjectionData.Projections[2].HallId;

            // Act
            var filteredProjections = await _systemUnderTest.GetAll(
                new ProjectionSearchObject()
                {
                    DateTime = dateTime
                });

            // Assert
            Assert.Equal(
                _databaseContextMock.Projections.Count(x => x.DateTime.Value == dateTime),
                filteredProjections.Count());
        }

        [Fact]
        public async Task GetAllAsync_WhenCalledWithMultipleFilterParameter_ShouldReturnSpecificProjection()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            var dateTime = ProjectionData.Projections[2].DateTime;
            var hall = ProjectionData.Projections[2].HallId;

            // Act
            var filteredProjections = await _systemUnderTest.GetAll(
                new ProjectionSearchObject()
                {
                    DateTime = dateTime,
                    HallId = hall
                });

            // Assert
            Assert.Equal(
                _databaseContextMock.Projections.Count(x => x.DateTime.Value == dateTime && x.HallId == hall),
                filteredProjections.Count());
        }

        [Fact]
        public async Task GetAllAsync_WhenCalledWithFilterParameter_ShouldReturnEmpty()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            var filteredProjections = await _systemUnderTest.GetAll(
                new ProjectionSearchObject()
                {
                    DateTime = DateTime.Now
                });

            // Assert
            Assert.Equal(filteredProjections.Count(), 0);
        }

        [Fact]
        public async Task InsertProjectionsAsync_WhenCalled_Insert()
        {
            // Arrange
            await _databaseContextMock.AddRangeAsync(ProjectionData.Projections);

            await _databaseContextMock.SaveChangesAsync();

            // Act
            _systemUnderTest.Insert(ProjectionData.ProjectionUpsertRequest);
            // Assert
            Assert.Equal(_databaseContextMock.Projections.Count(), ProjectionData.Projections.Count() + 1);
        }

        //[Fact]
        //public async Task GetAllAsync_WhenCalledWithNonExistingParameters_ShouldReturnEmpty()
        //{
        //    // Arrange
        //    await _databaseContextMock.AddRangeAsync(MovieData.Movies);

        //    await _databaseContextMock.SaveChangesAsync();

        //    // Act
        //    var filteredMovies = await _systemUnderTest
        //        .GetAll(
        //            new MovieSearchObject()
        //            {
        //                Name = "NonExistingName",
        //                Director = "NonExistingName",
        //            });

        //    // Assert
        //    Assert.Empty(filteredMovies);
        //}

        //[Fact]
        //public async Task GetByIdAsync_WhenCalled_ReturnsMovieWithGivenId()
        //{
        //    // Arrange
        //    var movie = MovieData.Movies[0];
        //    await _databaseContextMock.AddRangeAsync(MovieData.Movies);

        //    await _databaseContextMock.SaveChangesAsync();

        //    // Act
        //    var movieById = await _systemUnderTest.GetById(movie.Id);

        //    // Assert
        //    Assert.Equal(movie.Id, movieById.Id);
        //}

        //[Fact]
        //public async Task GetByIdAsync_WhenCalledWithInvalidMovieId_ThrowsException()
        //{
        //    // Arrange
        //    _databaseContextMock.AddRange(MovieData.Movies);
        //    await _databaseContextMock.SaveChangesAsync();

        //    // Assert
        //    await Assert.ThrowsAsync<Exception>(() =>
        //        _systemUnderTest.GetById(Guid.NewGuid()));
        //}

        //[Fact]
        //public async Task InsertMovieAsync_WhenCalled_AddsNewMovie()
        //{
        //    // Arrange
        //    var listOfMovies = MovieData.Movies;
        //    _databaseContextMock.AddRange(listOfMovies);

        //    await _databaseContextMock.SaveChangesAsync();

        //    // Act
        //    await _systemUnderTest.Insert(MovieData.movieInsertRequestValid);

        //    // Assert
        //    var expectedRecordCount = listOfMovies.Count + 1;
        //    Assert.Equal(_databaseContextMock.Movies.Count(), expectedRecordCount);
        //}

        //[Fact]
        //public async Task InsertMovie_WhenCalled_InvalidName_ThrowsValidationException_Async()
        //{
        //    // Arrange
        //    var listofMovies = MovieData.Movies;
        //    _databaseContextMock.Movies.AddRange(listofMovies);
        //    await _databaseContextMock.SaveChangesAsync();

        //    // Assert
        //    await Assert.ThrowsAsync<DbUpdateException>(() =>
        //       _systemUnderTest.Insert(new eCinema.Model.Requests.MovieUpsertRequest
        //       {
        //           // Name missing
        //           Duration = 140,
        //           ReleaseYear = 2021,
        //           Country = "USA",
        //           Actors = "Random Actor3",
        //           Director = "Random Director3",
        //           Genres = "Action",
        //       }));
        //}

        //[Fact]
        //public async Task UpdateMovieAsync_WhenCalled_UpdateMovie()
        //{
        //    // Arrange
        //    var listofMovies = MovieData.Movies;
        //    _databaseContextMock.Movies.AddRange(listofMovies);
        //    await _databaseContextMock.SaveChangesAsync();

        //    // Act
        //    var editMovie = new eCinema.Model.Requests.MovieUpsertRequest()
        //    {
        //        Name = "TestRandom",
        //        Duration = 140,
        //        ReleaseYear = 2021,
        //        Country = "USA",
        //        Actors = "Random Actor3",
        //        Director = "Random Director3",
        //        Genres = "Action",
        //    };
        //    var nameBeforeUpdate = listofMovies[0].Name;
        //    var updatedMovie = await _systemUnderTest.Update(listofMovies[0].Id, editMovie);

        //    // Assert
        //    Assert.NotEqual(nameBeforeUpdate, listofMovies[0].Name);
        //    Assert.Equal(editMovie.Name, updatedMovie.Name);
        //}

        //[Fact]
        //public async Task UpdateMovieAsync_WhenCalled_InvalidId_ThrowsException()
        //{
        //    // Arrange
        //    var listofMovies = MovieData.Movies;
        //    _databaseContextMock.Movies.AddRange(listofMovies);
        //    await _databaseContextMock.SaveChangesAsync();

        //    // Act
        //    var editMovie = new eCinema.Model.Requests.MovieUpsertRequest()
        //    {
        //        Name = "TestRandom",
        //        Duration = 140,
        //        ReleaseYear = 2021,
        //        Country = "USA",
        //        Actors = "Random Actor3",
        //        Director = "Random Director3",
        //        Genres = "Action",
        //    };
        //    await Assert.ThrowsAsync<InvalidOperationException>(() =>
        //     _systemUnderTest.Update(Guid.NewGuid(),
        //                             editMovie));
        //}

        //[Fact]
        //public async Task DeleteMovieAsync_WhenCalled_RemovesMovie()
        //{
        //    // Arrange
        //    var listofMovies = MovieData.Movies;
        //    _databaseContextMock.Movies.AddRange(listofMovies);
        //    await _databaseContextMock.SaveChangesAsync();

        //    // Act
        //    await _systemUnderTest.Delete(listofMovies[0].Id);

        //    // Assert
        //    var expectedRecordCount = listofMovies.Count - 1;
        //    Assert.Equal(_databaseContextMock.Movies.Count(), expectedRecordCount);
        //}

        //[Fact]
        //public async Task DeleteMovieAsync_WhenCalledWithInvalidMovieId_ThrowsException()
        //{
        //    // Arrange
        //    var listofMovies = MovieData.Movies;
        //    _databaseContextMock.Movies.AddRange(listofMovies);
        //    await _databaseContextMock.SaveChangesAsync();

        //    // Assert
        //    await Assert.ThrowsAsync<Exception>(() =>
        //        _systemUnderTest.Delete(Guid.NewGuid()));
        //}
        public void Dispose()
        {
        }
    }
}
