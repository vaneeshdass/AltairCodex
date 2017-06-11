using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace AltairCodex.Models
{
    public class AltairCodexInitializer : DropCreateDatabaseIfModelChanges<AltairCodexDbContext>
    {
        //protected override void Seed(AltairCodexDbContext context)
        //{
        //    var AppUsers = new List<AppUser>
        //    {
        //        new AppUser{FullName="Vaneesh Dass", AddressLine ="B409 Sri Amethyst Apt",Country="India",PinCode=560036,Location=DbGeography.FromText("POINT(13.0046949 77.7126473)"),DateCreated=DateTime.Now},
        //        new AppUser{FullName="Sawyer Ford", AddressLine ="A78 Abc Stree Apt",Country="USA",PinCode=245456,Location=DbGeography.FromText("POINT(-122.360 47.656)"),DateCreated=DateTime.Now},
        //        new AppUser{FullName="Tom Nick", AddressLine ="G45 Sri ASD Building",Country="Australia",PinCode=453645,Location=DbGeography.FromText("POINT(-122.360 47.656)"),DateCreated=DateTime.Now},
        //        new AppUser{FullName="Johnson Williams", AddressLine ="11 Park Street",Country="Japan",PinCode=313456,Location=DbGeography.FromText("POINT(-122.360 47.656)"),DateCreated=DateTime.Now},
        //        new AppUser{FullName="Bruce Wayne", AddressLine ="GH34 Willson park",Country="Sweden",PinCode=137567,Location=DbGeography.FromText("POINT(-122.360 47.656)"),DateCreated=DateTime.Now},
        //    };

        //    var Games = new List<Game>
        //    {
        //        new Game{}
        //    };
        //}
    }
}