using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Models.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointment.Data.Data
{
    public class HealthcareDbContext : DbContext
    {
        public HealthcareDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointments");
                entity.HasKey(a => a.Id);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.Id);

                entity.HasMany(e => e.AppointmentPatients)
                .WithOne(e => e.PatientUser)
                .HasForeignKey(e => e.PatientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(e => e.AppointmentDoctors)
                .WithOne(e => e.DoctorUser)
                .HasForeignKey(e => e.DoctorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
