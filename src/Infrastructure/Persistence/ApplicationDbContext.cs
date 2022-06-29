using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Common;
using SkiSchool.Domain.Entities;
using System.Reflection;

namespace SkiSchool.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Client => Set<Client>();
        public DbSet<Equipment> Equipment => Set<Equipment>();
        public DbSet<Rental> Rental => Set<Rental>();
        public DbSet<Report> Report => Set<Report>();
        public DbSet<Reservation> Reservation => Set<Reservation>();
        public DbSet<Schedule> Schedule => Set<Schedule>();
        public DbSet<Timetable> Timetable => Set<Timetable>();
        public DbSet<Payment> Payment => Set<Payment>();
        public DbSet<Trainer> Trainer => Set<Trainer>();



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            builder.Entity<Trainer>()
                .HasOne(a => a.Schedule)
                .WithOne(b => b.Trainer)
                .HasForeignKey<Schedule>(b => b.TrainerId);
        }
    }
}