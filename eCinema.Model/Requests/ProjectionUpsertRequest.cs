namespace eCinema.Model.Requests
{
    public class ProjectionUpsertRequest
    {
        public DateTime? DateTime { get; set; }

        public Guid? HallId { get; set; }

        public Guid? MovieId { get; set; }

        public Guid? PriceId { get; set; }

        public string? ProjectionType { get; set; }

        public string? Status { get; set; }

        public string? StateMachine { get; set; }
    }
}
