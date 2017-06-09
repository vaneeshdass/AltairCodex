using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Configuration;

namespace AltairCodex.Models
{
    public class AppUserDbContext : DbContext
    {

        public DbSet<Game> Games { get; set; }
        public DbSet<AppUser> Users{ get; set; }

        public AppUserDbContext(string connectionString) : base(connectionString) { }
        public AppUserDbContext() : base(ConfigurationManager.AppSettings["ConnString"].ToString())
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var game = modelBuilder.Entity<Game>();

            game.HasRequired<AppUser>(x => x.AppUser).WithMany(x => x.Games);

        }
    }
}