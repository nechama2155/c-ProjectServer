using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLApplications
    {
        //public int ApplicationId { get; set; }

        //public string CustomerId { get; set; } = null!;

        //public int ApartmentId { get; set; }

        //public string AssessorId { get; set; } = null!;

        //public int AssessmentId { get; set; }

        public int ApplicationId { get; set; }

        public string? AssessorId { get; set; }

        public DateTime ApplicationDate { get; set; }

        public DateTime? LastApplicationDate { get; set; }

        public int ApplicationStatus { get; set; }

    }
}
