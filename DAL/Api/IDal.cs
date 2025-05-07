using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDal
    {
        public IDalCustomers Customers { get; }
        public IDalAssessor Assessors { get; }
        public IDalAssessment Assessments { get; }
        public IDalApplications Applications { get; }
        public IDalApartmentDetails ApartmentDetails { get; }
        public IDalChat Chats { get; }


    }
}
