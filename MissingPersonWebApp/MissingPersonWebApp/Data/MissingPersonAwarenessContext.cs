using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MissingPersonWebApp.Data
{
    public partial class MissingPersonAwarenessContext : DbContext
    {
        public MissingPersonAwarenessContext()
        {
        }

        public MissingPersonAwarenessContext(DbContextOptions<MissingPersonAwarenessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactusDetail> ContactusDetails { get; set; }
        public virtual DbSet<FacebookAccount> FacebookAccounts { get; set; }
        public virtual DbSet<MissingPersonDatum> MissingPersonData { get; set; }
        public virtual DbSet<TwitterAccount> TwitterAccounts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HS1BR6H\\SQLEXPRESS01;Database=MissingPersonAwareness;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ContactusDetail>(entity =>
            {
                entity.HasKey(e => e.Contactid);

                entity.ToTable("ContactusDetail");

                entity.Property(e => e.CreatedDatetime).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FacebookAccount>(entity =>
            {
                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AppName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AppSecret)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PageAccessToken).IsRequired();
            });

            modelBuilder.Entity<MissingPersonDatum>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.CreatedDatetime).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FacebookPostId).HasMaxLength(500);

                entity.Property(e => e.FatherName).HasMaxLength(450);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Found).HasDefaultValueSql("((0))");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ImageName).HasMaxLength(450);

                entity.Property(e => e.ImagePath).HasMaxLength(450);

                entity.Property(e => e.LastName).HasMaxLength(450);

                entity.Property(e => e.MissingDate).HasColumnType("datetime");

                entity.Property(e => e.MotherName).HasMaxLength(450);

                entity.Property(e => e.SpouseName).HasMaxLength(450);

                entity.Property(e => e.TwitterPostId).HasMaxLength(500);

                entity.Property(e => e.UpdateDatetime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TwitterAccount>(entity =>
            {
                entity.Property(e => e.AccessToken)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AccessTokenSecret)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AppName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ConsumerKey)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ConsumerSecret)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
