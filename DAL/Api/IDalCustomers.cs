using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDalCustomers
    {
        List<Customer> GetCustomers();
        List<Assessor> GetAssessors(string id);
        List<Application> GetApplications(string id);
        List<Assessment> GetAssessments(string id);
        List<ICollection<Chat>> GetChats(string id);
        List<ApartmentDetail> GetApartmentsDetails(string id);
        Task Add(Customer customer);
        void Update(Customer customer);
        void Delete(string id);

    }
}
