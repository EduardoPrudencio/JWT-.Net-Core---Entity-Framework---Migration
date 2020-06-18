using AccessControl.BusinessRule.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Infrastructure
{
    public class AccessContext : DbContext
    {
        public AccessContext(DbContextOptions<AccessContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        public DbSet<Professional> Professional { get; set; }

        public DbSet<Service> Service { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //UM PARA MUITOS
            //EXEMPLO UM
            //modelBuilder.Entity<Service>()
            //    .HasOne(s => s.Professional)
            //    .WithMany(p => p.Services)
            //    .HasForeignKey(s => s.ProfessionalId);

            //EXEMPLO DOIS
            //modelBuilder.Entity<Service>()
            //    .HasOne<Professional>()
            //    .WithMany()
            //    .HasForeignKey(s => s.ProfessionalId);

            //MUITOS PARA MUITOS
            modelBuilder.Entity<ServiceProfessional>()
            .HasKey(sp => new { sp.ProfessionalId, sp.ServiceId });

            modelBuilder.Entity<ServiceProfessional>()
           .HasOne(sp => sp.Service)
           .WithMany(p => p.ServiceProfessional)
           .HasForeignKey(sp => sp.ServiceId);

            modelBuilder.Entity<ServiceProfessional>()
           .HasOne(sp => sp.Professional)
           .WithMany(s => s.ServiceProfessional)
           .HasForeignKey(sp => sp.ProfessionalId);
        }
    }
}
