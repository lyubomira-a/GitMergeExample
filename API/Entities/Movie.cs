using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Producer { get; set; }

        public int Rating { get; set; }
    }
}
