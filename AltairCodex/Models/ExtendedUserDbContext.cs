using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Configuration;

namespace AltairCodex.Models
{
    public class ExtendedUserDbContext : IdentityDbContext<ExtendedUser>
    {

        public DbSet<Address> Addresses { get; set; }

        public ExtendedUserDbContext(string connectionString) : base(connectionString) { }
        public ExtendedUserDbContext() : base(ConfigurationManager.AppSettings["ConnString"].ToString())
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            var user = modelBuilder.Entity<ExtendedUser>();
            user.Property(x => x.FullName).IsRequired().HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("FullNameIndex")));

                     
        }
    }
}