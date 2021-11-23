using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_123_A.Models
{
    public partial class db_penjualanContext : DbContext
    {
        public db_penjualanContext()
        {
        }

        public db_penjualanContext(DbContextOptions<db_penjualanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBarang> TblBarangs { get; set; }
        public virtual DbSet<TblDetailpenjualan> TblDetailpenjualans { get; set; }
        public virtual DbSet<TblPelanggan> TblPelanggans { get; set; }
        public virtual DbSet<TblPenjualan> TblPenjualans { get; set; }
        public virtual DbSet<VwCetaktransaksi> VwCetaktransaksis { get; set; }
        public virtual DbSet<VwDetail> VwDetails { get; set; }
        public virtual DbSet<VwPenjualan> VwPenjualans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblBarang>(entity =>
            {
                entity.HasKey(e => e.KodeBarang);

                entity.ToTable("tbl_barang");

                entity.Property(e => e.KodeBarang)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NamaBarang)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Satuan)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDetailpenjualan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_detailpenjualan");

                entity.Property(e => e.KodeBarang)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NoKwitansi)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.KodeBarangNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.KodeBarang)
                    .HasConstraintName("relasi_penjualan_barang");

                entity.HasOne(d => d.NoKwitansiNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.NoKwitansi)
                    .HasConstraintName("relasi_penjualan");
            });

            modelBuilder.Entity<TblPelanggan>(entity =>
            {
                entity.HasKey(e => e.IdPelanggan);

                entity.ToTable("tbl_pelanggan");

                entity.Property(e => e.IdPelanggan)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Alamat)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPelanggan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelepon)
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPenjualan>(entity =>
            {
                entity.HasKey(e => e.NoKwitansi);

                entity.ToTable("tbl_penjualan");

                entity.Property(e => e.NoKwitansi)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdPelanggan)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TglKwitansi).HasColumnType("date");

                entity.HasOne(d => d.IdPelangganNavigation)
                    .WithMany(p => p.TblPenjualans)
                    .HasForeignKey(d => d.IdPelanggan)
                    .HasConstraintName("Relasi_Penjualan_Pelanggan");
            });

            modelBuilder.Entity<VwCetaktransaksi>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_cetaktransaksi");

                entity.Property(e => e.IdPelanggan)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.KodeBarang)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NamaBarang)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPelanggan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoKwitansi)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TglKwitansi).HasColumnType("date");
            });

            modelBuilder.Entity<VwDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_detail");

                entity.Property(e => e.KodeBarang)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NamaBarang)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoKwitansi)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Satuan)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwPenjualan>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_penjualan");

                entity.Property(e => e.IdPelanggan)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NamaPelanggan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoKwitansi)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TglKwitansi).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
