using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLApartmentDetails
    {
        List<BLApartmentDetails> GetAll();
        BLApartmentDetails GetById(int id);
        void Add(BLApartmentDetails apartmentDetail);
        void Update(BLApartmentDetails apartmentDetails);
        void Delete(int id);
    }
}
