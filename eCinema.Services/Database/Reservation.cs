namespace eCinema.Services.Database
{
    public class Reservation
    {
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }

        public User? User { get; set; }

        public Guid? PojectionId { get; set; }

        public Projection? Projection { get; set; }

        public Invoice? Invoice { get; set; }

        public bool? IsActive { get; set; }

        public ICollection<Seat>? Seats { get; set; }
       

    }
}
