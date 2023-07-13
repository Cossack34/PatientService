using Microsoft.EntityFrameworkCore;
using PatientService.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientService.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();

        }
        /// <summary>
        /// Пациенты
        /// </summary>
        public DbSet<PatientEntity> Patients { get; set; }
        
        /// <summary>
        /// Контактные данные
        /// </summary>
        public DbSet<ContactsInfoEntity> ContactsInfo { get; set; }
        
        /// <summary>
        /// Медкарты
        /// </summary>
        public DbSet<CardsPatientEntity> CardsPatients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ///Foreign keys
            modelBuilder.Entity<ContactsInfoEntity>().Navigation(x => x.Patient);
            modelBuilder.Entity<CardsPatientEntity>().Navigation(x => x.Patient);



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("data source=localhost;initial catalog=Patients;" +
                "user=sa;password=23011986;App=EntityFramework;TrustServerCertificate=True")
                ;
        }
    }
}
