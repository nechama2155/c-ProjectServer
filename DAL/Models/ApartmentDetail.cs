using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ApartmentDetail
{
    public int ApartmentId { get; set; }

    public string ApartmentCity { get; set; } = null!;

    public string ApartmentAddress { get; set; } = null!;

    public int ApartmentSize { get; set; }

    public int AirDirections { get; set; }

    public string Directions { get; set; } = null!;

    public int Floor { get; set; }

    public bool Elevator { get; set; }

    public string CustomerId { get; set; } = null!;

    public virtual Application Apartment { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
