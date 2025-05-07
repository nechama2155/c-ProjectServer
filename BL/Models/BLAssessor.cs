using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLAssessor
    {
        public string AssessorId { get; set; } 

        public string AssessorFirstName { get; set; }

        public string AssessorLastName { get; set; }

        public string AssessorCity { get; set; }

        public string AssessorAddress { get; set; } 

        public string AssessorPhone { get; set; } 

        public string AssessorEmail { get; set; } 

        public int Seniority { get; set; }

        public bool Available { get; set; }
        public bool IsManager { get; set; }
        public int NumOfCustomers { get; set; }

    }
}
