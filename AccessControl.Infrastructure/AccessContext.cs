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
        public DbSet<Service> Service { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Person>().ToTable("Person");
        //}
    }


}
