namespace eCinema.Services.Database
{
    public class Projection
    {
        public Guid Id { get; set; }

        public DateTime? DateTime { get; set; }

        public Guid? HallId { get; set; }

        public Hall? Hall { get; set; }

        public Guid? MovieId { get; set; }

        public Movie? Movie { get; set; }

        public Guid? PriceId { get; set; }

        public Price? Price { get; set; }

        public string? ProjectionType { get; set; }

        public string? StateMachine { get; set; }

        public string? Status { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }

        public bool? IsActive { get; set; }
    }
}
