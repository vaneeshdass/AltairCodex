using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Configuration;

namespace AltairCodex.Models
{
    public class AltairCodexDbContext : DbContext
    {

        public DbSet<Game> Games { get; set; }
        public DbSet<AppUser> Users { get; set; }

        public AltairCodexDbContext(string connectionString) : base(connectionString) { }
        public AltairCodexDbContext() : base(ConfigurationManager.AppSettings["ConnString"].ToString())
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var game = modelBuilder.Entity<Game>();

            game.HasRequired<AppUser>(x => x.AppUser).WithMany(x => x.Games);

            var appUser = modelBuilder.Entity<AppUser>();
            appUser.Property(x => x.AppUserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}