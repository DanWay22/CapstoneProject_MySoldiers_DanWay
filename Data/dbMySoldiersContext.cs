using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CapstoneProject_MySoldiers_DanWay;

#nullable disable

namespace CapstoneProject_MySoldiers_DanWay
{
    public partial class dbMySoldiersContext : DbContext
    {
        public dbMySoldiersContext()
        {
        }

        public dbMySoldiersContext(DbContextOptions<dbMySoldiersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbSoldier> TbSoldiers { get; set; }
        //public virtual DbSet<Usstate> Usstates { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("cnStrMySoldiers");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbSoldier>(entity =>
            {
                entity.HasKey(e => e.SoldierId)
                    .HasName("PK__tbSoldie__FC3C500295173598");

                entity.Property(e => e.SoldierAddress).IsFixedLength(true);

                entity.Property(e => e.SoldierCity).IsFixedLength(true);

                entity.Property(e => e.SoldierCurrRank).IsUnicode(false);

                entity.Property(e => e.SoldierEyeColor).IsUnicode(false);

                entity.Property(e => e.SoldierFname)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SoldierHairColor).IsUnicode(false);

                entity.Property(e => e.SoldierLname)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SoldierMname)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SoldierRole).IsUnicode(false);

                entity.Property(e => e.SoldierSsn).IsUnicode(false);

                entity.Property(e => e.SoldierState).IsFixedLength(true);

                entity.Property(e => e.SoldierSuffix)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            //modelBuilder.Entity<Usstate>(entity =>
            //{
            //    entity.ToTable("USStates");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.StateAbbrev)
            //        .HasMaxLength(10)
            //        .IsFixedLength(true);

            //    entity.Property(e => e.StateName)
            //        .HasMaxLength(50)
            //        .IsFixedLength(true);
            //});


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<CapstoneProject_MySoldiers_DanWay.TbEnlistedRank> TbEnlistedRank { get; set; }

        public DbSet<CapstoneProject_MySoldiers_DanWay.TbOfficerRank> TbOfficerRank { get; set; }

        public DbSet<CapstoneProject_MySoldiers_DanWay.TbRole> TbRole { get; set; }
    }
}
