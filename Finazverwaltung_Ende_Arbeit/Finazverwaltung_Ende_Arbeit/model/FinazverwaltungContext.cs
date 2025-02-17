using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Finazverwaltung_Ende_Arbeit.model
{
    public partial class FinazverwaltungContext : DbContext
    {
        public FinazverwaltungContext()
        {
        }

        public FinazverwaltungContext(DbContextOptions<FinazverwaltungContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ausgaben> Ausgaben { get; set; } = null!;
        public virtual DbSet<Budgetwert> Budgetwert { get; set; } = null!;
        public virtual DbSet<Einnahmen> Einnahmen { get; set; } = null!;
        public virtual DbSet<Firma> Firma { get; set; } = null!;
        public virtual DbSet<Mitarbeiterprofile> Mitarbeiterprofile { get; set; } = null!;
        public virtual DbSet<Verbleibendesbudget> Verbleibendesbudget { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Finanzverwaltung;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ausgaben>(entity =>
            {
                entity.HasKey(e => e.IdAusgaben)
                    .HasName("PK__Ausgaben__687907BB76B8FA10");

                entity.Property(e => e.IdAusgaben).HasColumnName("ID_Ausgaben");

                entity.Property(e => e.Ausgaben1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Ausgaben");

                entity.HasMany(d => d.IdEinnahmen)
                    .WithMany(p => p.IdAusgaben)
                    .UsingEntity<Dictionary<string, object>>(
                        "Finanzverwaltung",
                        l => l.HasOne<Einnahmen>().WithMany().HasForeignKey("IdEinnahmen").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_Einnahmen"),
                        r => r.HasOne<Ausgaben>().WithMany().HasForeignKey("IdAusgaben").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_Ausgaben"),
                        j =>
                        {
                            j.HasKey("IdAusgaben", "IdEinnahmen").HasName("pk_PersonID");

                            j.ToTable("Finanzverwaltung");

                            j.IndexerProperty<int>("IdAusgaben").HasColumnName("ID_Ausgaben");

                            j.IndexerProperty<int>("IdEinnahmen").HasColumnName("ID_Einnahmen");
                        });
            });

            modelBuilder.Entity<Budgetwert>(entity =>
            {
                entity.HasKey(e => e.IdBudgetwert)
                    .HasName("PK__Budgetwe__5444D4A1E4AC46C9");

                entity.Property(e => e.IdBudgetwert).HasColumnName("ID_Budgetwert");

                entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Einnahmen>(entity =>
            {
                entity.HasKey(e => e.IdEinnahmen)
                    .HasName("PK__Einnahme__F9CF95409D73F0F5");

                entity.Property(e => e.IdEinnahmen).HasColumnName("ID_Einnahmen");

                entity.Property(e => e.Einnahmen1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Einnahmen");
            });

            modelBuilder.Entity<Firma>(entity =>
            {
                entity.Property(e => e.FirmaId).HasColumnName("FirmaID");

                entity.Property(e => e.FinanzverwaltungId).HasColumnName("FinanzverwaltungID");
            });

            modelBuilder.Entity<Mitarbeiterprofile>(entity =>
            {
                entity.HasKey(e => e.MitarbeiterId)
                    .HasName("PK__Mitarbei__6D10A9D1D175E7D2");

                entity.Property(e => e.MitarbeiterId).ValueGeneratedNever();

                entity.Property(e => e.Benutzername).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Mitarbeiternummer).HasMaxLength(100);

                entity.Property(e => e.Nachname).HasMaxLength(50);

                entity.Property(e => e.Passwort).HasMaxLength(50);

                entity.Property(e => e.Vorname).HasMaxLength(50);
            });

            modelBuilder.Entity<Verbleibendesbudget>(entity =>
            {
                entity.HasKey(e => e.IdVerbleibendesbudget)
                    .HasName("PK__Verbleib__D8479ECE7473E45E");

                entity.Property(e => e.IdVerbleibendesbudget).HasColumnName("ID_verbleibendesbudget");

                entity.Property(e => e.Ausgaben).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Einnahmen).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Verbleibendesbudget1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("verbleibendesbudget");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
