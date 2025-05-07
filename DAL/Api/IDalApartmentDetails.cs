using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDalApartmentDetails
    {
        List<ApartmentDetail> GetApartmentDetails();
        Task Add(ApartmentDetail apartmentDetail);
        void Update(ApartmentDetail apartmentDetail);
        void Delete(int apartmentDetail);
    }
}
