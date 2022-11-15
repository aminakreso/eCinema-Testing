namespace eCinema.Services.Database
{
    public class Invoice
    {
        public Guid Id { get; set; } 

        public DateTime? Created { get; set; }

        public decimal? Price { get; set; }

        public decimal? VAT { get; set; }

        public Guid ReservationId { get; set; }

        public Reservation? Reservation { get; set; }
    }
}
