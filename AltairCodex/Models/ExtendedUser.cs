using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace AltairCodex.Models
{
    public class ExtendedUser : IdentityUser
    {

        public ExtendedUser()
        {
            Addresses = new List<Address>();
        }
        public string FullName { get; set; }

       

        public virtual ICollection<Address> Addresses { get; private set; }
    }

   public class Address
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public long PinCode { get; set; }
        public DbGeography Location { get; set; }
    }

   }