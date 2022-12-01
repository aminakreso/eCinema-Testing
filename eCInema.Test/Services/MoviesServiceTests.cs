namespace eCInema.Test.Services
{
    using AutoMapper;
    using eCinema.Model.SearchObjects;
    using eCinema.Services.Database;
    using eCinema.Services.Profiles;
    using eCinema.Services.Services;
    using eCInema.Test.Data;
    using Microsoft.EntityFrameworkCore;

    public sealed class MoviesServiceTests : IDisposable
    {
        private readonly CinemaContext _databaseContextMock;
        private readonly MovieService _systemUnderTest;

        public MoviesServiceTests()
        {
            _databaseContextMock = InMemoryDatabaseFactory.CreateInMemoryDatabase();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());

            var mapper = new Mapper(config);

            _systemUnderTest = new MovieService(_databaseContextMock, mapper);
        }

        // Amina Kreso
        [Fact]
        public async Task GetAllAsync_WhenCalledWithNoFilterParameters_ReturnsListOfAllMovies()
    {
        // Arrange
        await _databaseContextMock.AddRangeAsync(MovieData.Movies);

        await _databaseContextMock.SaveChangesAsync();

        // Act
        var movieList =
            await _systemUnderTest.GetAll();

        // Assert
        Assert.Equal(MovieData.Movies.Count, movieList.Count());
    }

        [Fact]
        public async Task GetAllAsync_WhenCalledWithFilterParameters_ShouldReturnSpecificMovie()
    {
        await _databaseContextMock.AddRangeAsync(MovieData.Movies);

        await _databaseContextMock.SaveChangesAsync();

        var searchTitle = MovieData.Movies[0].Name;
        var searchDirector = MovieData.Movies[0].Director;

        // Act
        var filteredMovies = await _systemUnderTest.GetAll(
            new MovieSearchObject()
            {
                Name = searchTitle,
                Director = searchDirector,
            });

        // Assert
        Assert.Equal(
            _databaseContextMock.Movies.Count(x => x.Name.Contains(searchTitle!) && x.Director.Contains(searchDirector)),
            filteredMovies.Count());
    }

        [Fact]
        public async Task GetAllAsync_WhenCalledWithNonExistingParameters_ShouldReturnEmpty()
    {
        // Arrange
        await _databaseContextMock.AddRangeAsync(MovieData.Movies);

        await _databaseContextMock.SaveChangesAsync();

        // Act
        var filteredMovies = await _systemUnderTest
            .GetAll(
                new MovieSearchObject()
                {
                    Name = "NonExistingName",
                    Director = "NonExistingName",
                });

        // Assert
        Assert.Empty(filteredMovies);
    }

        [Fact]
        public async Task GetByIdAsync_WhenCalled_ReturnsMovieWithGivenId()
    {
        // Arrange
        var movie = MovieData.Movies[0];
        await _databaseContextMock.AddRangeAsync(MovieData.Movies);

        await _databaseContextMock.SaveChangesAsync();

        // Act
        var movieById = await _systemUnderTest.GetById(movie.Id);

        // Assert
        Assert.Equal(movie.Id, movieById.Id);
    }

        [Fact]
        public async Task GetByIdAsync_WhenCalledWithInvalidMovieId_ThrowsException()
    {
        // Arrange
        _databaseContextMock.AddRange(MovieData.Movies);
        await _databaseContextMock.SaveChangesAsync();

        // Assert
        await Assert.ThrowsAsync<Exception>(() =>
            _systemUnderTest.GetById(Guid.NewGuid()));
    }

        [Fact]
        public async Task InsertMovieAsync_WhenCalled_AddsNewMovie()
    {
        // Arrange
        var listOfMovies = MovieData.Movies;
        _databaseContextMock.AddRange(listOfMovies);

        await _databaseContextMock.SaveChangesAsync();

        // Act
        await _systemUnderTest.Insert(MovieData.movieInsertRequestValid);

        // Assert
        var expectedRecordCount = listOfMovies.Count + 1;
        Assert.Equal(expectedRecordCount, _databaseContextMock.Movies.Count());
    }

        // Admir Numanović
        [Fact]
        public async Task InsertMovie_WhenCalled_InvalidName_ThrowsValidationException_Async()
        {
            // Arrange
            var listofMovies = MovieData.Movies;
            _databaseContextMock.Movies.AddRange(listofMovies);
            await _databaseContextMock.SaveChangesAsync();

            // Assert
            await Assert.ThrowsAsync<DbUpdateException>(() =>
               _systemUnderTest.Insert(new eCinema.Model.Requests.MovieUpsertRequest
               {
                   // Name missing
                   Duration = 140,
                   ReleaseYear = 2021,
                   Country = "USA",
                   Actors = "Random Actor3",
                   Director = "Random Director3",
                   Genres = "Action",
               }));
        }

        [Fact]
        public async Task UpdateMovieAsync_WhenCalled_UpdateMovie()
        {
            // Arrange
            var listofMovies = MovieData.Movies;
            _databaseContextMock.Movies.AddRange(listofMovies);
            await _databaseContextMock.SaveChangesAsync();

            // Act
            var editMovie = new eCinema.Model.Requests.MovieUpsertRequest()
            {
                Name = "TestRandom",
                Duration = 140,
                ReleaseYear = 2021,
                Country = "USA",
                Actors = "Random Actor3",
                Director = "Random Director3",
                Genres = "Action",
            };
            var nameBeforeUpdate = listofMovies[0].Name;
            var updatedMovie = await _systemUnderTest.Update(listofMovies[0].Id, editMovie);

            // Assert
            Assert.NotEqual(nameBeforeUpdate, listofMovies[0].Name);
            Assert.Equal(editMovie.Name, updatedMovie.Name);
        }

        [Fact]
        public async Task UpdateMovieAsync_WhenCalled_InvalidId_ThrowsException()
        {
            // Arrange
            var listofMovies = MovieData.Movies;
            _databaseContextMock.Movies.AddRange(listofMovies);
            await _databaseContextMock.SaveChangesAsync();

            // Act
            var editMovie = new eCinema.Model.Requests.MovieUpsertRequest()
            {
                Name = "TestRandom",
                Duration = 140,
                ReleaseYear = 2021,
                Country = "USA",
                Actors = "Random Actor3",
                Director = "Random Director3",
                Genres = "Action",
            };
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
             _systemUnderTest.Update(Guid.NewGuid(), editMovie));
        }

        [Fact]
        public async Task DeleteMovieAsync_WhenCalled_RemovesMovie()
        {
            // Arrange
            var listofMovies = MovieData.Movies;
            _databaseContextMock.Movies.AddRange(listofMovies);
            await _databaseContextMock.SaveChangesAsync();

            // Act
            await _systemUnderTest.Delete(listofMovies[0].Id);

            // Assert
            Assert.False(listofMovies[0].IsActive);
        }

        [Fact]
        public async Task DeleteMovieAsync_WhenCalledWithInvalidMovieId_ThrowsException()
        {
            // Arrange
            var listofMovies = MovieData.Movies;
            _databaseContextMock.Movies.AddRange(listofMovies);
            await _databaseContextMock.SaveChangesAsync();

            // Assert
            await Assert.ThrowsAsync<Exception>(() =>
                 _systemUnderTest.Delete(Guid.NewGuid()));
        }

        public void Dispose()
        {
        }
    }
}
