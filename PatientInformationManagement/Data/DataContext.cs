using Microsoft.EntityFrameworkCore;
using PatientInformationManagement.Models;

namespace PatientInformationManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<PatientInfo> Patients { get; set; }
        public DbSet<DiseaseInfo> Diseases { get; set; }
        public DbSet<NCD> NCDs { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<NCD_Details> NCD_Details { get; set; }
        public DbSet<Allergies_Details> Allergies_Details { get; set; }

        public DbSet<Epilepsy> Epilespsies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Epilepsy>()
                .Property(e => e.Status)
                .HasConversion<string>();

            modelBuilder.Entity<DiseaseInfo>()
                .HasKey(di => di.ID);

            modelBuilder.Entity<PatientInfo>()
                .HasKey(pi => pi.ID);

            // Configure the many-to-many relationship for NCD_Details
            modelBuilder.Entity<NCD_Details>()
                .HasKey(pc => new { pc.PatientID, pc.NCDID });
            modelBuilder.Entity<NCD_Details>()
                .HasOne(nd => nd.Patient)
                .WithMany(p => p.NCD_Details)
                .HasForeignKey(nd => nd.PatientID);
            modelBuilder.Entity<NCD_Details>()
                .HasOne(nd => nd.NCD)
                .WithMany(n => n.NCD_Details)
                .HasForeignKey(nd => nd.NCDID);

            // Configure the many-to-many relationship for Allergies_Details
            modelBuilder.Entity<Allergies_Details>()
                .HasKey(pc => new { pc.PatientID, pc.AllergiesID });
            modelBuilder.Entity<Allergies_Details>()
                .HasOne(ad => ad.Patient)
                .WithMany(p => p.Allergies_Details)
                .HasForeignKey(ad => ad.PatientID);
            modelBuilder.Entity<Allergies_Details>()
                .HasOne(ad => ad.Allergies)
                .WithMany(a => a.Allergies_Details)
                .HasForeignKey(ad => ad.AllergiesID);
        }
    }
}
