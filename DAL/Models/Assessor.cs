using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Assessor
{
    public string AssessorId { get; set; } = null!;

    public string AssessorFirstName { get; set; } = null!;

    public string AssessorLastName { get; set; } = null!;

    public string AssessorCity { get; set; } = null!;

    public string AssessorAddress { get; set; } = null!;

    public string AssessorPhone { get; set; } = null!;

    public string AssessorEmail { get; set; } = null!;

    public int Seniority { get; set; }

    public bool Available { get; set; }

    public bool IsManager { get; set; }

    public int? NumOfCustomers { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
