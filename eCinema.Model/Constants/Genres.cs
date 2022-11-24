namespace eCinema.Model.Constants
{
    public static class Genres
    {
        public const string All = "Svi";

        public const string Action = "Action";

        public const string Fantasy = "Fantasy";

        public const string Comedy = "Comedy";

        public const string Horror = "Horror";

        public const string Adventure = "Adventure";

        public static readonly List<string> ListOfGenres = new()
        {
            All,Action,Fantasy,Comedy,Horror,Adventure
        };

    }
}
