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
            
            AList.ForEach(a => list.Add((Cast.apartmentDetailsTobl(a))));
            return list;
        }
        #endregion

        #region GetById
        public BLApartmentDetails GetById(int id)
        {
            var AList = dal.ApartmentDetails.GetApartmentDetails();
            var o = AList.Find(x => x.ApartmentId == id);
            return Cast.apartmentDetailsTobl(o);

        }
        #endregion

        #region Add
        public void Add(BLApartmentDetails a)
        {
            dal.ApartmentDetails.Add(Cast.apartmentDetailsTodal(a));
        }
        #endregion

        #region Update

        public void Update(BLApartmentDetails apartmentDetails)
        {
            dal.ApartmentDetails.Update(Cast.apartmentDetailsTodal(apartmentDetails));


        }


        #endregion

        #region Delete

        public void Delete(int a)
        {
            dal.ApartmentDetails.Delete(a);
        }

        #endregion






    }
}
