using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltairCodex.Models
{
    public class Game
    {
        public int GameId { get; set; }

        public int AppUserId { get; set; }

        public string Name { get; set; }

        public int ReleaseYear { get; set; }

        public Platform Platform { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual AppUser AppUser { get; set; }
    }

    public enum Platform
    {
        PS4=1,
        XboxOne,
        PS3,
        Xbox360
    }
}