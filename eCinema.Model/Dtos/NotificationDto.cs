namespace eCinema.Model.Dtos
{
    public class NotificationDto
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public DateTime? Date { get; set; }

        public Guid AuthorId { get; set; }
        public UserDto Autor { get; set; }

        public string? AuthorName
        {
            get
            {
                return Autor?.FirstName + " " + Autor?.LastName;
            }
        }

        public string? NotificationType { get; set; }

        public string? Picture { get; set; }
        
        public bool? IsActive { get; set; }

    }
}
