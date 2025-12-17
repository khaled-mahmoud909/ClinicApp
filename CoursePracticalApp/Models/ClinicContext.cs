using CoursePracticalApp.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePracticalApp.Models
{
    public class ClinicContext : IdentityDbContext<IdentityUser>
    {

        public ClinicContext(DbContextOptions options) : base(options) {}

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Receptionist> Receptionists { get; set; }

        public DbSet<Speciality> Specialities { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<IdentityUser>().ToTable("Users", "auth");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "auth");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "auth");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "auth");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "auth");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "auth");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "auth");


            modelBuilder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Id = "afe734b1-e0b1-47bb-9891-2833c77476fe",
                        Name = AppRoles.APP_ADMIN.ToString(),
                        NormalizedName = AppRoles.APP_ADMIN.ToString(),
                        ConcurrencyStamp = "c8499bda-2cbd-4fe0-addf-de3b70d3a3a7"

                    },
                    new IdentityRole
                    {
                        Id = "2dc69b65-46fa-48fb-8187-e0ddacbe1353",
                        Name = AppRoles.DOCTOR.ToString(),
                        NormalizedName = AppRoles.DOCTOR.ToString(),
                        ConcurrencyStamp = "8379348a-b161-47c2-873a-b3f1e62009c8"
                    },
                    new IdentityRole
                    {
                        Id = "3df21187-6d7a-4e55-9833-178f8e424b7e",
                        Name = AppRoles.RECEPTIONEST.ToString(),
                        NormalizedName = AppRoles.RECEPTIONEST.ToString(),
                        ConcurrencyStamp = "37267b18-d873-48a0-94eb-c836d67b1314"
                    }
                );

            //modelBuilder.Entity<Doctor>()
            //    .Property(d => d.LastName)
            //    .HasDefaultValue("Ahmad");
            //modelBuilder.Entity<Doctor>()
            //    .HasOne(d => d.Speciality)
            //    .WithMany(s => s.Doctors)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<Patient>()
                .Property(a => a.CreatedAt)
                .HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<Patient>()
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Receptionist)
                .WithMany(r => r.Patients)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Speciality>()
                .HasData([
                    new Speciality{Id = 1, Name = "Dental"},
                    new Speciality{Id = 2, Name = "Pediatric"}
                    ]);

        }
    }
}
