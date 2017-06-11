namespace AltairCodex.Migrations
{
    using AltairCodex.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AltairCodex.Models.AltairCodexDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AltairCodex.Models.AltairCodexDbContext context)
        {
            var DatabaseIntializer = new AltairCodexInitializer(new AltairCodexDbContext());

        }
    }
}
