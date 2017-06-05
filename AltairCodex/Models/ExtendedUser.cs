using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Spatial;

namespace AltairCodex.Models
{
    public class ExtendedUser : IdentityUser
    {
        public string FullName { get; set; }
        public virtual Address Address { get; private set; }
    }

    public class Address
    {

        public string UserId { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public long PinCode { get; set; }
        public DbGeography Location { get; set; }

        public virtual ExtendedUser User { get; set; }

    }
}