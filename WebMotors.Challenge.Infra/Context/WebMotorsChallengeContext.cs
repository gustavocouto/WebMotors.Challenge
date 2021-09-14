using Microsoft.EntityFrameworkCore;
using WebMotors.Challenge.Domain.Models;

namespace WebMotors.Challenge.Infra.Context
{
    public class WebMotorsChallengeContext : DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }

        public WebMotorsChallengeContext(DbContextOptions<WebMotorsChallengeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigAnnouncement(modelBuilder);
        }

        private void ConfigAnnouncement(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>().ToTable("tb_AnuncioWebmotors").HasKey(_ => _.ID);
            modelBuilder.Entity<Announcement>().Property(_ => _.Make).HasColumnName("marca").HasMaxLength(45).IsRequired();
            modelBuilder.Entity<Announcement>().Property(_ => _.Model).HasColumnName("modelo").HasMaxLength(45).IsRequired();
            modelBuilder.Entity<Announcement>().Property(_ => _.Version).HasColumnName("versao").HasMaxLength(45).IsRequired();
            modelBuilder.Entity<Announcement>().Property(_ => _.Year).HasColumnName("ano").IsRequired();
            modelBuilder.Entity<Announcement>().Property(_ => _.Mileage).HasColumnName("quilometragem").IsRequired();
            modelBuilder.Entity<Announcement>().Property(_ => _.Comments).HasColumnName("observacao").HasMaxLength(45).IsRequired();
        }
    }
}