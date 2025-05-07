using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLAssessor
    {
        List<BLAssessor> GetAll();
        List<BLCustomer> GetCustomers(string id);
        List<BLApplications> GetApplication(string id);
        List<BLAssessment> GetAssessment(string id);
        List<BLApartmentDetails> GetApartmentDetails(string id);
        List<BLChat> GetChat(string id);
        BLAssessor GetById(string id);
        void Add(BLAssessor id);
        void Update(BLAssessor assessor);
        void Delete(string id); 
    }
}
