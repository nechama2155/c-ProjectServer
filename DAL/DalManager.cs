using DAL.Api;
using DAL.Models;
using DAL.Services;

namespace DAL
{
    public class DalManager : IDal
    {

        dbcontext data;
        public IDalCustomers Customers { get; }
        public IDalAssessor Assessors { get; }
        public IDalApplications Applications { get; }
        public IDalApartmentDetails ApartmentDetails { get; }
        public IDalAssessment Assessments { get; }
        public IDalChat Chats { get; }
        


        public DalManager()

        { 
            data = new dbcontext();
            Customers = new DalCustomersService(data);
            Assessors = new DalAssessorService(data);
            Applications = new DalApplicationsService(data);
            ApartmentDetails = new DalApartmentDetailsService(data); 
            Assessments = new DalAssessmentsService(data);
            Chats = new DalChatsService(data);


        }
    }
}