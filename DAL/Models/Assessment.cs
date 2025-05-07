using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Assessment
{
    public int AssessmentId { get; set; }

    public string? Block { get; set; }

    public string? Plot { get; set; }

    public string? SubPlot { get; set; }

    public string? ConstructionYear { get; set; }

    public int? AcquisionPrice { get; set; }

    public string? AssessmentGoal { get; set; }

    public string? LegalState { get; set; }

    public string? BuildingPermit { get; set; }

    public string? IrregularitiesBuilding { get; set; }

    public virtual Application AssessmentNavigation { get; set; } = null!;
}
