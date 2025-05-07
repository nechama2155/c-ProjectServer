using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDalAssessor
    {

        List<Assessor> GetAssessors();
        List<Assessor> GetAssessorsSimple();
        List<Customer> GetCustomers(string id);
        List<Application> GetApplications(string id);
        List<Assessment> GetAssessments(string id);
        List<ApartmentDetail> GetApartmentsDetails(string id);
        List<ICollection< Chat>> GetChats(string id);
        void Add(Assessor assessor);
        void Update(Assessor assessor); 
        void Delete(string id);
    }
}
