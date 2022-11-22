using AutoMapper;
using eCinema.Model.Constants;
using eCinema.Model.SearchObjects;
using eCinema.Services.Database;
using eCinema.Services.Profiles;
using eCinema.Services.Services;
using eCInema.Test.Data;
using System.Diagnostics.Metrics;
using System.IO;

namespace eCInema.Test.Services
{
    public sealed class MoviesTests : IDisposable
    {
        private readonly CinemaContext _databaseContextMock;
        private readonly MovieService _systemUnderTest;
        private readonly IMapper _mapper;


        public MoviesTests()
        {
            _databaseContextMock = InMemoryDatabaseFactory.CreateInMemoryDatabase();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());

            var mapper = new Mapper(config);

            _systemUnderTest = new MovieService(_databaseContextMock, mapper);

        }

        [Fact]
        public async Task AddMovie_Async()
        {
            //Arrange
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
            //Arrange
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
                Genres = "Action"
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
            //Arrange
            var listofMovies = MovieData.Movies;
            _databaseContextMock.Movies.AddRange(listofMovies);
            await _databaseContextMock.SaveChangesAsync();

            // Assert
            await Assert.ThrowsAsync<Exception>(() =>
               _systemUnderTest.Insert(new eCinema.Model.Requests.MovieUpsertRequest
               {
                   //Name missing
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
