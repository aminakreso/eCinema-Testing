
using eCinema.Model.Requests;
using eCinema.Services.Database;

namespace eCInema.Test.Data
{
    public static class MovieData
    {
        public static readonly List<Movie> Movies = new()
        {
            new Movie
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Duration = 130,
                ReleaseYear = 2020,
                Country = "USA",
                Actors = "Random Actor",
                Director = "Random Director",
                Genres ="Comedy",
                IsActive = true,
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Name = "Test2",
                Duration = 140,
                ReleaseYear = 2021,
                Country = "USA",
                Actors = "Random Actor2",
                Director = "Random Director2",
                Genres ="Action",
                IsActive = true,
            },

        };

        public static readonly MovieUpsertRequest movieInsertRequestValid = new MovieUpsertRequest()
        {
            Name = "Test3",
            Duration = 140,
            ReleaseYear = 2021,
            Country = "USA",
            Actors = "Random Actor3",
            Director = "Random Director3",
            Genres = "Action",
        };
    }
}
