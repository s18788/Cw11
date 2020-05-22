using Microsoft.EntityFrameworkCore;
using System;

namespace Cw11.Models
{
    public class MyDbContext : DbContext
    {

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }


        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(k => k.IdDoctor).HasName("Doctor_PK");
                entity.Property(p => p.IdDoctor).ValueGeneratedNever();
                entity.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(p => p.LastName).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Email).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(k => k.IdPatient).HasName("Patient_PK");
                entity.Property(p => p.IdPatient).ValueGeneratedNever();
                entity.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(p => p.LastName).HasMaxLength(100).IsRequired();
                entity.Property(p => p.BirthDate).HasColumnType("date").IsRequired();
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(k => k.IdPrescription).HasName("Prescription_PK");
                entity.Property(p => p.IdPrescription).ValueGeneratedNever();
                entity.Property(p => p.Date).HasColumnType("date").IsRequired();
                entity.Property(p => p.DueDate).HasColumnType("date").IsRequired();

                entity.HasOne(d => d.IdDoctorNavigation).WithMany(d => d.PrescriptionsNavigation).HasForeignKey(d => d.IdDoctor);
                entity.HasOne(p => p.IdPatientNavigation).WithMany(p => p.PrescriptionsNavigation).HasForeignKey(p => p.IdPatient);

            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(k => k.IdMedicament).HasName("Medicament_PK");
                entity.Property(p => p.IdMedicament).ValueGeneratedNever();
                entity.Property(p => p.Name).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Description).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Type).HasMaxLength(100).IsRequired();
            });


            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.ToTable("Prescription_Medicament");
                entity.HasKey(k => new { k.IdMedicament, k.IdPrescription }).HasName("Prescrption_Medicament_PK");
                entity.Property(p => p.IdMedicament).ValueGeneratedNever();
                entity.Property(p => p.IdPrescription).ValueGeneratedNever();
                entity.Property(p => p.Dose);
                entity.Property(p => p.Details).HasMaxLength(100).IsRequired();

                entity.HasOne(m => m.IdMedicamentNavigation).WithMany(m => m.PrescriptionMedicamentNavigation).HasForeignKey(m => m.IdMedicament);
                entity.HasOne(p => p.IdPrescriptionNavigation).WithMany(p => p.PrescriptionMedicamentNavigation).HasForeignKey(p => p.IdPrescription);
            });


            Seed(modelBuilder);


        }

        private void Seed(ModelBuilder modelBuilder)
        {

            // Doctor

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { IdDoctor = 1, FirstName = "Andrzej", LastName = "Malewski", Email = "malewski@wp.pl" },
                new Doctor
                {
                    IdDoctor = 2,
                    FirstName = "Marcin",
                    LastName = "Malędowski",
                    Email = "moleda@wp.pl"
                }, new Doctor
                {
                    IdDoctor = 3,
                    FirstName = "Krzysztof",
                    LastName = "Kowalewicz",
                    Email = "kowalewicz@wp.pl"
                },
                new Doctor
                {
                    IdDoctor = 4,
                    FirstName = "Anna",
                    LastName = "Kostrzewska",
                    Email = "akostrzew@onet.pl"
                }


                );

            //Patient

            modelBuilder.Entity<Patient>().HasData(
           new Patient
           {
               IdPatient = 1,
               FirstName = "Jan",
               LastName = "Andrzejewski",
               BirthDate = new DateTime(1980 - 02 - 02)
           },

            new Patient
            {
                IdPatient = 2,
                FirstName = "Krzysztof",
                LastName = "Kowalewicz",
                BirthDate = new DateTime(1991 - 01 - 10)
            },

            new Patient
            {
                IdPatient = 3,
                FirstName = "Marcin",
                LastName = "Andrzejewicz",
                BirthDate = new DateTime(1995 - 01 - 02)
            });

            //Medicament

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament
                {
                    IdMedicament = 1,
                    Name = "Xanax",
                    Description = "Lorem ipsum...",
                    Type = "Depression"
                },

           new Medicament
           {
               IdMedicament = 2,
               Name = "Abilify",
               Description = "Lorem.",
               Type = "Tabletki"
           },

            new Medicament
            {
                IdMedicament = 3,
                Name = "Abra",
                Description = "Lorem...",
                Type = "Żel"
            },

            new Medicament
            {
                IdMedicament = 4,
                Name = "Acai",
                Description = "Test",
                Type = "Kapsułki"
            },

           new Medicament
           {
               IdMedicament = 5,
               Name = "ACC",
               Description = "Lorem ipsum...",
               Type = "Tabletki"
           },

           new Medicament
           {
               IdMedicament = 6,
               Name = "Acerin",
               Description = "Lorem...",
               Type = "Płyn"
           });

            //Prescription

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    IdPrescription = 1,
                    Date = new DateTime(2020 - 05 - 10),
                    DueDate = new DateTime(2020 - 10 - 23),
                    IdDoctor = 1,
                    IdPatient = 2
                },

            new Prescription
            {
                IdPrescription = 2,
                Date = new DateTime(2020 - 05 - 20),
                DueDate = new DateTime(2020 - 06 - 10),
                IdDoctor = 1,
                IdPatient = 2
            },

            new Prescription
            {
                IdPrescription = 3,
                Date = new DateTime(2020 - 06 - 05),
                DueDate = new DateTime(2020 - 06 - 20),
                IdDoctor = 2,
                IdPatient = 1
            },

           new Prescription
           {
               IdPrescription = 4,
               Date = new DateTime(2020 - 03 - 01),
               DueDate = new DateTime(2020 - 04 - 25),
               IdDoctor = 3,
               IdPatient = 2
           });

            //PrescriptionMedicament

            modelBuilder.Entity<PrescriptionMedicament>().HasData(
                new PrescriptionMedicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 4,
                    Details = "Take every morning"
                },

            new PrescriptionMedicament
            {
                IdMedicament = 1,
                IdPrescription = 2,
                Dose = 1,
                Details = "Once a week"
            },

            new PrescriptionMedicament
            {
                IdMedicament = 1,
                IdPrescription = 3,
                Dose = 3,
                Details = "Once every two weeks"
            },

            new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 1,
                Dose = 10,
                Details = "Every evening"
            },

            new PrescriptionMedicament
            {
                IdMedicament = 3,
                IdPrescription = 2,
                Dose = 7,
                Details = "Once every day after main meal"
            });

        }

    }
}
