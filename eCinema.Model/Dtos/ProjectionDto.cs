namespace eCinema.Model.Dtos
{
    public class ProjectionDto
    {
        public Guid Id { get; set; }

        public DateTime? DateTime { get; set; }

        public Guid HallId { get; set; }

        public virtual HallDto Hall { get; set; }

        public Guid MovieId { get; set; }
        public virtual MovieDto Movie { get; set; }

        public Guid? PriceId { get; set; }

        public virtual PriceDto Price { get; set; }

        public string? ProjectionType { get; set; }
        
        public string? StateMachine { get; set; }

        public string? Status { get; set; }

        public bool? IsActive { get; set; }

    }
}
