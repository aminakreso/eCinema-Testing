namespace eCinema.Services.Database
{
    public class Seat
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public int? HallId { get; set; }

        public Hall? Hall { get; set; }

        public bool IsReserved { get; set; }
    }
}
