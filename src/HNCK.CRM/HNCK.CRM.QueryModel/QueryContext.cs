using HNCK.CRM.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCK.CRM.QueryModel
{
    public class QueryContext : DbContext
    {
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Attachments> Attachments { get; set; }

        public QueryContext()
        {
        }

        public QueryContext(DbContextOptions<QueryContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (String.IsNullOrEmpty(AppSettings.Instance.DbOptions.ConnectionString))
                {
                    throw new ApplicationException($"The {nameof(AppSettings.Instance.DbOptions.ConnectionString)} == NULL. " +
                        $"Please set the {nameof(AppSettings.Instance.DbOptions.ConnectionString)} in appsettings.json.");
                }
                optionsBuilder.UseNpgsql(AppSettings.Instance.DbOptions.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("unaccent")
               .HasPostgresExtension("uuid-ossp")
               .HasAnnotation("Relational:Collation", "Slovak_Slovakia.1250");

            modelBuilder.Entity<Addresses>()
                .ToView("Addresses", "sub")
                .HasNoKey();

            modelBuilder.Entity<Attachments>()
               .ToView("Attachments", "sub")
               .HasNoKey();

            modelBuilder.Entity<Countries>()
               .ToView("Countries", "sub")
               .HasNoKey();

            modelBuilder.Entity<Subjects>()
               .ToView("Subjects", "sub")
               .HasNoKey();

           
        }
    }
}
