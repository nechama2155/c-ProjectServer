using BL.Api;
using BL.Models;
using DAL.Api;
using DAL.Models;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLApartmenetDetailsService : IBLApartmentDetails
    {
        IDal dal;

        public BLApartmenetDetailsService(IDal dal)       {
            this.dal = dal;
        }


        #region GetAll
        public List<BLApartmentDetails> GetAll()
        {
            var AList = dal.ApartmentDetails.GetApartmentDetails();
            List<BLApartmentDetails> list = new();
            
            AList.ForEach(a => list.Add((apartmentDetailsTobl(a))));
            return list;
        }
        #endregion

        #region GetById
        public BLApartmentDetails GetById(int id)
        {
            var AList = dal.ApartmentDetails.GetApartmentDetails();
            var o = AList.Find(x => x.ApartmentId == id);
            return apartmentDetailsTobl(o);

        }
        #endregion

        #region Add
        public void Add(BLApartmentDetails a)
        {
            dal.ApartmentDetails.Add(apartmentDetailsTodal(a));
        }
        #endregion

        #region Update

        public void Update(BLApartmentDetails apartmentDetails)
        {
            dal.ApartmentDetails.Update(apartmentDetailsTodal(apartmentDetails));


        }


        #endregion

        #region Delete

        public void Delete(int a)
        {
            dal.ApartmentDetails.Delete(a);
        }

        #endregion


        #region apartmentDetailsTodal
        public ApartmentDetail apartmentDetailsTodal(BLApartmentDetails a)
        {
            ApartmentDetail bla = new ApartmentDetail()
            {
                ApartmentId = a.ApartmentId,
                AirDirections = a.AirDirections,
                ApartmentAddress = a.ApartmentAddress,
                ApartmentCity = a.ApartmentCity,
                Directions = a.Directions,
                ApartmentSize = a.ApartmentSize,
                Elevator = a.Elevator,
                Floor = a.Floor,
                CustomerId = a.CustomerId
            };
            return bla;
        }

        #endregion

        #region apartmentDetailsTobl
       public  BLApartmentDetails apartmentDetailsTobl(ApartmentDetail a)
        {
            BLApartmentDetails bla = new BLApartmentDetails()
            {
                ApartmentId = a.ApartmentId,
                AirDirections = a.AirDirections,
                ApartmentAddress = a.ApartmentAddress,
                ApartmentCity = a.ApartmentCity,
                Directions = a.Directions,
                ApartmentSize = a.ApartmentSize,
                Elevator = a.Elevator,
                Floor = a.Floor,
                CustomerId = a.CustomerId
            };
            return bla;
        }
        #endregion



    }
}
