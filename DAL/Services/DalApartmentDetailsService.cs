using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DalApartmentDetailsService:IDalApartmentDetails
    {
        dbcontext db;

        public DalApartmentDetailsService(dbcontext data)
        {
            db = data;
        }

        public List<ApartmentDetail> GetApartmentDetails()
        {
            return db.ApartmentDetails.ToList();
        }

        public async Task Add(ApartmentDetail apartmentDetail)
        {
            db.ApartmentDetails.Add(apartmentDetail);
           await db.SaveChangesAsync();
        }

        public void Update(ApartmentDetail apartmentDetail)
        {
            ApartmentDetail apartm = db.ApartmentDetails.Find(apartmentDetail.ApartmentId);
            if (apartm != null)
            {
                apartm.CustomerId = apartmentDetail.CustomerId;
                apartm.Elevator = apartmentDetail.Elevator;
                apartm.Floor = apartmentDetail.Floor;
                apartm.Directions = apartmentDetail.Directions;
               apartm.AirDirections = apartmentDetail.AirDirections;
                apartm.ApartmentSize = apartmentDetail.ApartmentSize;
                apartm.ApartmentAddress = apartmentDetail.ApartmentAddress;
                apartm.ApartmentCity = apartmentDetail.ApartmentCity;

            }
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var list = db.ApartmentDetails.ToList();
            db.ApartmentDetails.Remove(list.Find(x => x.ApartmentId == id));
            db.SaveChanges();

        }

    }
}
