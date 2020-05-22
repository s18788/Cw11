using Microsoft.EntityFrameworkCore;

namespace Cw11.Models
{
    public class MyDbContext : DbContext
    {

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }


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
               entity.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
               entity.Property(p => p.LastName).HasMaxLength(100).IsRequired();
               entity.Property(p => p.Email).HasMaxLength(100).IsRequired();
           });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(k => k.IdPatient).HasName("Patient_PK");
                entity.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(p => p.LastName).HasMaxLength(100).IsRequired();
                entity.Property(p => p.BirthDate).HasColumnType("date").IsRequired();
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(k => k.IdPrescription).HasName("Prescription_PK");
                entity.Property(p => p.Date).HasColumnType("date").IsRequired();
                entity.Property(p => p.DueDate).HasColumnType("date").IsRequired();

                entity.HasOne(d => d.IdDoctorNavigation).WithMany(d => d.PrescriptionsNavigation).HasForeignKey(d => d.IdDoctor);
                entity.HasOne(p => p.IdPatientNavigation).WithMany(p => p.PrescriptionsNavigation).HasForeignKey(p => p.IdPatient);

            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(k => k.IdMedicament).HasName("Medicament_PK");
                entity.Property(p => p.Name).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Description).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Type).HasMaxLength(100).IsRequired();
            });


            modelBuilder.Entity<Prescription_Medicament>(entity =>
            {
                entity.HasKey(k => k.IdMedicament).HasName("Medicament_Prescription_Medicament_PK");
                entity.HasAlternateKey(ak => ak.IdPrescription).HasName("Presciption_Prescription_Medicament_PK");
                entity.Property(p => p.Dose);
                entity.Property(p => p.Details).HasMaxLength(100).IsRequired();

                entity.HasOne(m => m.IdMedicamentNavigation).WithMany(m => m.Prescription_MedicamentNavigation).HasForeignKey(m => m.IdMedicament);
                entity.HasOne(p => p.IdPrescriptionNavigation).WithMany(p => p.Prescription_MedicamentNavigation).HasForeignKey(p => p.IdPrescription);
            });




        }

    }
}
