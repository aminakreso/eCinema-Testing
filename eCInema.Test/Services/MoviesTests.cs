namespace eCInema.Test.Services
{
    using AutoMapper;
    using eCinema.Model.SearchObjects;
    using eCinema.Services.Database;
    using eCinema.Services.Profiles;
    using eCinema.Services.Services;
    using eCInema.Test.Data;

    public sealed class MoviesTests : IDisposable
    {
        private readonly CinemaContext _databaseContextMock;
        private readonly MovieService _systemUnderTest;

        public MoviesTests()
        {
            _databaseContextMock = InMemoryDatabaseFactory.CreateInMemoryDatabase();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());

            var mapper = new Mapper(config);

            _systemUnderTest = new MovieService(_databaseContextMock, mapper);
        }

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
        Assert.Equal(_databaseContextMock.Movies.Count(), expectedRecordCount);
    }

        [Fact]
        public async Task AddMovie_Async()
        {
            // Arrange
           var listofMovies = MovieData.Movies;
           _databaseContextMock.Movies.AddRange(listofMovies);
           await _databaseContextMock.SaveChangesAsync();

            // Act
           var newMovie = await _systemUnderTest.Insert(MovieData.movieInsertRequestValid);

            // Assert
           var expectedRecordCount = listofMovies.Count + 1;
           Assert.Equal(_databaseContextMock.Movies.Count(), expectedRecordCount);
           Assert.Equal(newMovie.Name, MovieData.movieInsertRequestValid.Name);
        }

        [Fact]
        public async Task EditMovie_Async()
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
            Assert.NotEqual(nameBeforeUpdate, updatedMovie.Name);
            Assert.Equal(editMovie.Name, updatedMovie.Name);
        }

        [Fact]
        public async Task AddMovie_MissingName_ThrowsValidationException_Async()
        {
            // Arrange
            var listofMovies = MovieData.Movies;
            _databaseContextMock.Movies.AddRange(listofMovies);
            await _databaseContextMock.SaveChangesAsync();

            // Assert
            await Assert.ThrowsAsync<Exception>(() =>
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

        public void Dispose()
        {
        }
    }
}
