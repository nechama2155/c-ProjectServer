using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLFullAll
    {
        public List<BLApplications>? applications { get; set; }
        public List<BLApartmentDetails>? apartmentsDetails { get; set; }
        public List<BLCustomer>? customers { get; set; }
        public List<BLAssessment>? assessments { get; set; }
        public List<BLAssessor>? assessors { get; set; }
        public List<BLChat>? chats { get; set; }
    }
}
