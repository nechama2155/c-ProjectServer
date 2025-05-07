using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string StatusDescribtion { get; set; } = null!;
}
