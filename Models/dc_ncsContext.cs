using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BSSLNCSApi
{
    public partial class dc_ncsContext : DbContext
    {
        public dc_ncsContext()
        {
        }

        public dc_ncsContext(DbContextOptions<dc_ncsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Revenue> Revenue { get; set; }
        public virtual DbSet<Revenuecat> Revenuecat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2VLJF7J\\SQLEXPRESS;Initial Catalog=dc_ncs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Revenue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("REVENUE");

                entity.Property(e => e.Achead)
                    .HasColumnName("ACHEAD")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Apprv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bencode)
                    .HasColumnName("BENCODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CommDate)
                    .HasColumnName("COMM_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.FrequencyPay).HasDefaultValueSql("((2))");

                entity.Property(e => e.GlCntCde)
                    .HasColumnName("GL_CNT_CDE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GlCntDesc)
                    .HasColumnName("GL_CNT_DESC")
                    .IsUnicode(false);

                entity.Property(e => e.Revcode)
                    .IsRequired()
                    .HasColumnName("REVCODE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Revcode1)
                    .HasColumnName("revcode1")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Revdesc)
                    .IsRequired()
                    .HasColumnName("REVDESC")
                    .IsUnicode(false);

                entity.Property(e => e.Revenuerate)
                    .HasColumnName("REVENUERATE")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Subcode)
                    .IsRequired()
                    .HasColumnName("subcode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Subdesc)
                    .IsRequired()
                    .HasColumnName("SUBDESC")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Subhead)
                    .HasColumnName("SUBHEAD")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Usecomp)
                    .HasColumnName("usecomp")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Usemj)
                    .HasColumnName("usemj")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Whatcode)
                    .HasColumnName("WHATCODE")
                    .HasMaxLength(50);

                entity.Property(e => e.FreqPay)
                    .HasColumnName("freqPay")
                    .HasMaxLength(50);

                entity.Property(e => e.Whatdesc)
                    .HasColumnName("WHATDESC")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Revenuecat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("REVENUECAT");

                entity.Property(e => e.Catcode)
                    .HasColumnName("CATCODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Catrevdesc)
                    .HasColumnName("CATREVDESC")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Groupcode)
                    .HasColumnName("GROUPCODE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Groupdesc)
                    .HasColumnName("GROUPDESC")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
