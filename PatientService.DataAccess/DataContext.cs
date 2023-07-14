using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

            modelBuilder.Entity<ContactsInfoEntity>().Property(x => x.Email).HasMaxLength(100);
            modelBuilder.Entity<ContactsInfoEntity>().Property(x => x.Phone).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<CardsPatientEntity>().Property(x => x.Snils).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<CardsPatientEntity>().Property(x => x.Insurance).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<PatientEntity>().Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<PatientEntity>().Property(x => x.LastName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<PatientEntity>().Property(x => x.MiddleName).HasMaxLength(50);
            modelBuilder.Entity<PatientEntity>().Property(x => x.Sex).HasMaxLength(1).IsRequired();
            modelBuilder.Entity<PatientEntity>().Property(x => x.BirthDate).IsRequired();


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ///БД подключаем в Program.cs WebHost
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
