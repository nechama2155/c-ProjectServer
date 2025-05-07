using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string CustomerFirstName { get; set; } = null!;

    public string CustomerLastName { get; set; } = null!;

    public string CustomerCity { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public string? CustomerEmail { get; set; }

    public virtual ICollection<ApartmentDetail> ApartmentDetails { get; set; } = new List<ApartmentDetail>();
}
