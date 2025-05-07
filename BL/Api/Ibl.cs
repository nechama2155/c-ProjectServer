using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface Ibl
    {

        public IBLCustomer Customers { get; set; }
        public IBLAssessor Assessors { get; set; }
        public IBLApplications Applications { get; set; }
        public IBLAssessment Assessments { get; set; }
        public IBLApartmentDetails ApartmentDetails { get; set; }
        public IBLChat Chats { get; set; }


    }
}
