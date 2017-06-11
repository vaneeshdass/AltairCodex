using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace AltairCodex.Models
{
    public class AltairCodexInitializer : DropCreateDatabaseAlways<AltairCodexDbContext>
    {
        public AltairCodexInitializer(AltairCodexDbContext context)
        {
            Seed(context);
        }
        protected override void Seed(AltairCodexDbContext context)
        {
            var AppUsers = new List<AppUser>
            {
                new AppUser{AppUserId=1, FullName="Vaneesh Dass", AddressLine ="B409 Sri Amethyst Apt",Country="India",PinCode=560036,Location=DbGeography.FromText("POINT(13.0046949 77.7126473)"),DateCreated=DateTime.Now},
                new AppUser{AppUserId=2, FullName="Sawyer Ford", AddressLine ="A78 Abc Stree Apt",Country="USA",PinCode=245456,Location=DbGeography.FromText("POINT(-122.360 47.656)"),DateCreated=DateTime.Now},
                new AppUser{ AppUserId = 3, FullName ="Tom Nick", AddressLine ="G45 Sri ASD Building",Country="Australia",PinCode=453645,Location=DbGeography.FromText("POINT(-122.360 47.656)"),DateCreated=DateTime.Now},
                new AppUser{ AppUserId = 4, FullName ="Johnson Williams", AddressLine ="11 Park Street",Country="Japan",PinCode=313456,Location=DbGeography.FromText("POINT(-122.360 47.656)"),DateCreated=DateTime.Now},
                new AppUser{ AppUserId = 5, FullName ="Bruce Wayne", AddressLine ="GH34 Willson park",Country="Sweden",PinCode=137567,Location=DbGeography.FromText("POINT(-122.360 47.656)"),DateCreated=DateTime.Now},
            };

            AppUsers.ForEach(x => context.AppUsers.Add(x));
            context.SaveChanges();

            var Games = new List<Game>
            {
                new Game{AppUserId=1,Name="GTA V",ReleaseYear=2013,Platform=Platform.PS4,DateCreated=DateTime.Now},
                new Game{AppUserId=2,Name="GTA IV",ReleaseYear=2008,Platform=Platform.PS4,DateCreated=DateTime.Now},
                new Game{AppUserId=1,Name="Arkham Knight",ReleaseYear=2015,Platform=Platform.XboxOne,DateCreated=DateTime.Now},
                new Game{AppUserId=3,Name="Blood Bourne",ReleaseYear=2013,Platform=Platform.PS4,DateCreated=DateTime.Now},
                new Game{AppUserId=4,Name="FallOut 4",ReleaseYear=2016,Platform=Platform.XboxOne,DateCreated=DateTime.Now},
                new Game{AppUserId=5,Name="NFS 5",ReleaseYear=2014,Platform=Platform.PS4,DateCreated=DateTime.Now},
                new Game{AppUserId=1,Name="Withcer 3",ReleaseYear=2015,Platform=Platform.PS4,DateCreated=DateTime.Now},
                new Game{AppUserId=4,Name="God Of War 3",ReleaseYear=2014,Platform=Platform.XboxOne,DateCreated=DateTime.Now},
                new Game{AppUserId=3,Name="Far Cry 4",ReleaseYear=2015,Platform=Platform.PS4,DateCreated=DateTime.Now},

            };

            Games.ForEach(x => context.Games.Add(x));
            context.SaveChanges();
        }
    }
}