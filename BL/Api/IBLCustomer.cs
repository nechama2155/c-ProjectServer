using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLCustomer
    {
        List<BLCustomer> GetAll();
        BLCustomer GetById(string id);
        void Add(BLCustomer id);
        void Update(BLCustomer customer);
        void Delete(string id);
        List<BLAssessor> GetAssessor(string id);
        List<BLChat> GetChat(string id);
        List<BLApplications> GetApplication(string id);
        List<BLAssessment> GetAssessment(string id);
        List<BLApartmentDetails> GetApartmentDetails(string id);
    }
}
