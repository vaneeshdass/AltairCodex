﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace AltairCodex.Models
{
    public class AppUser
    {
        public AppUser()
        {
            Games = new List<Game>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }

        public string AddressLine { get; set; }
        public string Country { get; set; }
        public long PinCode { get; set; }
        public DbGeography Location { get; set; }

        public ICollection<Game> Games { get; set; }

    }

}