using System;
using HNCK.CRM.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HNCK.CRM.Model
{
    public partial class HnckcrmContext : DbContext
    {
        public HnckcrmContext()
        {
        }

        public HnckcrmContext(DbContextOptions<HnckcrmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<LogLevel> LogLevels { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Trace> Traces { get; set; }
        public virtual DbSet<UserEvent> UserEvents { get; set; }

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

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.IdAddress);

                entity.ToTable("Address", "sub");

                entity.HasIndex(e => e.IdAddressType, "IXFK_Address_AddressType");

                entity.HasIndex(e => e.IdCountry, "IXFK_Address_Country");

                entity.HasIndex(e => e.IdSubject, "IXFK_Address_Subject");

                entity.Property(e => e.IdAddress).HasDefaultValueSql("nextval(('sub.\"address_idaddress_seq\"'::text)::regclass)");

                entity.Property(e => e.CityName).HasMaxLength(127);

                entity.Property(e => e.StreetName).HasMaxLength(127);

                entity.Property(e => e.StreetNumber).HasMaxLength(31);

                entity.Property(e => e.Zip).HasMaxLength(15);

                entity.HasOne(d => d.IdAddressTypeNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.IdAddressType)
                    .HasConstraintName("FK_Address_AddressType");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK_Address_Country");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.IdSubject)
                    .HasConstraintName("FK_Address_Subject");
            });

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.HasKey(e => e.IdAddressType);

                entity.ToTable("AddressType", "sub");

                entity.Property(e => e.IdAddressType).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(63);
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.HasKey(e => e.IdAttachment);

                entity.ToTable("Attachment", "sub");

                entity.HasIndex(e => e.IdSubject, "IXFK_Attachment_Subject");

                entity.Property(e => e.IdAttachment).ValueGeneratedNever();

                entity.Property(e => e.ContentType)
                    .IsRequired()
                    .HasMaxLength(127);

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.RelativePath)
                    .IsRequired()
                    .HasMaxLength(127);

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.Attachment1s)
                    .HasForeignKey(d => d.IdSubject)
                    .HasConstraintName("FK_Attachment_Subject");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry);

                entity.ToTable("Country", "sub");

                entity.Property(e => e.IdCountry).ValueGeneratedNever();

                entity.Property(e => e.Acronym2)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Acronym3)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.IsValid)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(127)
                    .HasColumnName("NameEN");

                entity.Property(e => e.NameEnshort)
                    .IsRequired()
                    .HasMaxLength(127)
                    .HasColumnName("NameENShort");

                entity.Property(e => e.NameSk)
                    .IsRequired()
                    .HasMaxLength(127)
                    .HasColumnName("NameSK");

                entity.Property(e => e.NameSkshort)
                    .IsRequired()
                    .HasMaxLength(127)
                    .HasColumnName("NameSKShort");
            });

            modelBuilder.Entity<Error>(entity =>
            {
                entity.HasKey(e => e.IdError);

                entity.ToTable("Error", "aud");

                entity.HasIndex(e => e.IdLogLevel, "IXFK_Error_LogLevel");

                entity.Property(e => e.IdError).HasDefaultValueSql("nextval(('aud.\"error_iderror_seq\"'::text)::regclass)");

                entity.Property(e => e.CallerMethodFullName).HasMaxLength(127);

                entity.Property(e => e.ClientAgent).HasMaxLength(255);

                entity.Property(e => e.ClientIp).HasMaxLength(63);

                entity.Property(e => e.Environment).HasMaxLength(127);

                entity.Property(e => e.Level).HasMaxLength(63);

                entity.Property(e => e.MachineName).HasMaxLength(127);

                entity.Property(e => e.ProcesId).HasMaxLength(63);

                entity.Property(e => e.RequestId).HasMaxLength(63);

                entity.Property(e => e.RequestMethod).HasMaxLength(31);

                entity.Property(e => e.RequestPath).HasMaxLength(255);

                entity.Property(e => e.SqlStatement).HasColumnType("jsonb");

                entity.Property(e => e.ThreadId).HasMaxLength(63);

                entity.HasOne(d => d.IdLogLevelNavigation)
                    .WithMany(p => p.Errors)
                    .HasForeignKey(d => d.IdLogLevel)
                    .HasConstraintName("FK_Error_LogLevel");
            });

            modelBuilder.Entity<LogLevel>(entity =>
            {
                entity.HasKey(e => e.IdLogLevel);

                entity.ToTable("LogLevel", "aud");

                entity.Property(e => e.IdLogLevel).ValueGeneratedNever();

                entity.Property(e => e.LogLevel1)
                    .HasMaxLength(63)
                    .HasColumnName("LogLevel");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.IdSubject);

                entity.ToTable("Subject", "sub");

                entity.Property(e => e.IdSubject).HasDefaultValueSql("nextval(('sub.\"subject_idsubject_seq\"'::text)::regclass)");

                entity.Property(e => e.BusinessIdentificationNumber).HasMaxLength(31);

                entity.Property(e => e.Email).HasMaxLength(127);

                entity.Property(e => e.FirstName).HasMaxLength(63);

                entity.Property(e => e.LastName).HasMaxLength(63);

                entity.Property(e => e.PersonalIdentificationNumber).HasMaxLength(31);

                entity.Property(e => e.TelNumber).HasMaxLength(63);
            });

            modelBuilder.Entity<Trace>(entity =>
            {
                entity.HasKey(e => e.IdTrace);

                entity.ToTable("Trace", "aud");

                entity.HasIndex(e => e.IdLogLevel, "IXFK_Trace_LogLevel");

                entity.Property(e => e.IdTrace).HasDefaultValueSql("nextval(('aud.\"trace_idtrace_seq\"'::text)::regclass)");

                entity.Property(e => e.CallerMethodFullName).HasMaxLength(127);

                entity.Property(e => e.ClientAgent).HasMaxLength(255);

                entity.Property(e => e.ClientIp).HasMaxLength(63);

                entity.Property(e => e.Level).HasMaxLength(63);

                entity.Property(e => e.MachineName).HasMaxLength(127);

                entity.Property(e => e.ProcesId).HasMaxLength(63);

                entity.Property(e => e.RequestId).HasMaxLength(63);

                entity.Property(e => e.RequestMethod).HasMaxLength(31);

                entity.Property(e => e.RequestPath).HasMaxLength(255);

                entity.Property(e => e.ThreadId).HasMaxLength(63);

                entity.HasOne(d => d.IdLogLevelNavigation)
                    .WithMany(p => p.Traces)
                    .HasForeignKey(d => d.IdLogLevel)
                    .HasConstraintName("FK_Trace_LogLevel");
            });

            modelBuilder.Entity<UserEvent>(entity =>
            {
                entity.HasKey(e => e.IdUserEvent);

                entity.ToTable("UserEvent", "evn");

                entity.HasIndex(e => e.IdSubject, "IXFK_UserEvent_Subject");

                entity.Property(e => e.IdUserEvent).HasDefaultValueSql("nextval(('evn.\"userevent_iduserevent_seq\"'::text)::regclass)");

                entity.Property(e => e.Decsription).HasMaxLength(1023);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.UserEvents)
                    .HasForeignKey(d => d.IdSubject)
                    .HasConstraintName("FK_UserEvent_Subject");
            });

            modelBuilder.HasSequence("address_idaddress_seq", "sub");

            modelBuilder.HasSequence("error_iderror_seq", "aud");

            modelBuilder.HasSequence("subject_idsubject_seq", "sub");

            modelBuilder.HasSequence("trace_idtrace_seq", "aud");

            modelBuilder.HasSequence("userevent_iduserevent_seq", "evn");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
