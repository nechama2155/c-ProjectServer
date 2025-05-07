using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Application
{
    public int ApplicationId { get; set; }

    public string? AssessorId { get; set; }

    public DateTime ApplicationDate { get; set; }

    public DateTime? LastApplicationDate { get; set; }

    public int ApplicationStatus { get; set; }

    public virtual ApartmentDetail? ApartmentDetail { get; set; }

    public virtual Assessment? Assessment { get; set; }

    public virtual Assessor? Assessor { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
}
