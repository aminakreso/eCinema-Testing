using Microsoft.EntityFrameworkCore;

namespace eCinema.Services.Database
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
        }

        public DbSet<Hall> Halls { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<Projection> Projections { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
