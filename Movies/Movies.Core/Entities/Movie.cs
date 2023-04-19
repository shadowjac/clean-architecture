using System;
using Movies.Core.Entities.Base;

namespace Movies.Core.Entities
{
    public class Movie : Entity
    {
        public Movie()
        {
        }

        public string Name { get; set; }
        public string DirectedBy { get; set; }
        public int ReleaseYear { get; set; }
    }
}

