using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace AltairCodex.Models
{
    public class ExtendedUserDbContext : IdentityDbContext<ExtendedUser>
    {
        public DbSet<Address> Addresses { get; set; }

        public ExtendedUserDbContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var address = modelBuilder.Entity<Address>();
            address.ToTable("UsersAddressLocation");
            address.HasKey(x => x.UserId);
            address.Property(x => x.Location).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute( "LocationIndex")));

            var user = modelBuilder.Entity<ExtendedUser>();
            user.Property(x => x.FullName).IsRequired().HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("FullNameIndex")));
            user.
            user.HasMany(x => x.Addresses).WithRequired().HasForeignKey(x => x.UserId);
        }
    }
}