namespace eCinema.Model.SearchObjects
{
    public class ProjectionSearchObject : BaseSearchObject
    {
        public DateTime? DateTime { get; set; }

        public Guid? HallId { get; set; }

        public string? Name { get; set; }

        public string? Status { get; set; }

        public bool? IncludeMovies { get; set; }

        public bool? IncludeHalls { get; set; }

        public bool? IncludePrices { get; set; }
    }
}
