using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLApartmentDetails
    {
        public int ApartmentId { get; set; }

        public string ApartmentCity { get; set; } = null!;

        public string ApartmentAddress { get; set; } = null!;

        public int ApartmentSize { get; set; }

        public int AirDirections { get; set; }

        public string Directions { get; set; } = null!;

        public int Floor { get; set; }

        public bool Elevator { get; set; }
        public string? CustomerId { get; set; }

    }
}
