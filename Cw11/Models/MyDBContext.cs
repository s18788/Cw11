using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Cw11.Models
{
    public class MyDbContext : DbContext
    {

        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        /*      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
              {
                  if (!optionsBuilder.IsConfigured)
                  {
                      optionsBuilder.UseSqlServer();
                  }
              }*/



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Doctor>(entity =>
           {
               entity.HasKey(k => k.IdDoctor);
               entity.Property(p => p.FirstName).HasMaxLength(100);
               entity.Property(p => p.LastName).HasMaxLength(100);
               entity.Property(p => p.Email).HasMaxLength(100);
           });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(k => k.IdPatient);
                entity.Property(p => p.FirstName).HasMaxLength(100);
                entity.Property(p => p.LastName).HasMaxLength(100);
                entity.Property(p => p.BirthDate).HasColumnType("date");
            });

            modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(k => k.IdPrescription);
            entity.Property(p => p.Date).HasColumnType("date");
            entity.Property(p => p.DueDate).HasColumnType("date");
        });

            modelBuilder.Entity<Medicament>(entity =>
         {
             entity.HasKey(k => k.IdMedicament);
             entity.Property(p => p.Name).HasMaxLength(100);
             entity.Property(p => p.Description).HasMaxLength(100);
             entity.Property(p => p.Type).HasMaxLength(100);
         });


            modelBuilder.Entity<Prescription_Medicament>(entity =>
       {
           entity.HasKey(k => k.IdMedicament);
           entity.HasAlternateKey(ak => ak.IdPrescription);
           entity.Property(p => p.Dose); //??????????????????????????
           entity.Property(p => p.Details).HasMaxLength(100);
       });




        }

    }
}
