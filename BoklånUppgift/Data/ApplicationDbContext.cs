using BoklånUppgift.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoklånUppgift.Data
{
    public class ApplicationDbContext : IdentityDbContext<RentalUser>
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {   //Seedar in roller och användare
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());


        }
    }

    internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<RentalUser>
    {
        public void Configure(EntityTypeBuilder<RentalUser> builder)
        {
            builder.Property(x=>x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
        }
    }
}
