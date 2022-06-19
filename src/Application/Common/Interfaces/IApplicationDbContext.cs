using Microsoft.EntityFrameworkCore;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Client> Client { get; }
        public DbSet<Equipment> Equipment { get; }
        public DbSet<Rental> Rental { get; }
        public DbSet<Report> Report { get; }
        public DbSet<Reservation> Reservation { get; }
        public DbSet<Schedule> Schedule { get; }
        public DbSet<Timetable> Timetable { get; }
        public DbSet<Payment> Payment { get; }
        public DbSet<Trainer> Trainer { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}