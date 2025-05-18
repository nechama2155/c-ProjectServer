using BL.Api;
using BL.Models;
using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLCustomersService : IBLCustomer
    {
       
        IDal dal;
       
        public  BLCustomersService(IDal dal)
        {
            this.dal = dal;
        }

        #region GetAll
        public List<BLCustomer> GetAll()
        {
            var AList = dal.Customers.GetCustomers();
            List<BLCustomer> list = new();
            AList.ForEach(a => list.Add(Cast.customerTobl(a)));
            return list;
        }
        #endregion

        #region GetById
        public BLCustomer GetById(string id)
        {
            var AList = dal.Customers.GetCustomers();
            var o = AList.Find(x => x.CustomerId == id);
            return Cast.customerTobl(o);

        }
        #endregion

        #region GetAssesors
        public List <BLAssessor> GetAssessor(string id) {
            var AList = dal.Customers.GetAssessors(id);
            List<BLAssessor> list = new();
            AList.ForEach(a => list.Add(Cast.assessorTobl(a)));
            return list;
            ;
        }
        

        #endregion

        #region GetApplications
        public List<BLApplications> GetApplication(string id)
        {
            var AList = dal.Customers.GetApplications(id);
            List<BLApplications> list = new();
            AList.ForEach(a => list.Add(Cast.applicationTobl(a)));
            return list;
        }
        #endregion

        #region GetAssessments

        public List<BLAssessment> GetAssessment(string id)
        {
            var AList = dal.Customers.GetAssessments(id);
            List<BLAssessment> list = new();
            AList.ForEach(a => list.Add(Cast.assessmentTobl(a)));
            return list;
        }
        #endregion

        #region GetApartmentDetails

        public List<BLApartmentDetails> GetApartmentDetails(string id)
        {
            var AList = dal.Customers.GetApartmentsDetails(id);
            List<BLApartmentDetails> list = new();
            AList.ForEach(a => list.Add(Cast.apartmentDetailsTobl(a)));
            return list;
        }
        #endregion

        #region GetChats

        public List<BLChat> GetChat(string id)
        {
            var List = dal.Customers.GetChats(id);
            List<BLChat> list = new();
            for (int i = 0; i < List.Count(); i++)
            {
                var a = List[i];
                for (int j = 0; j < a.Count(); j++)
                {
                    list.Add(Cast.chatTobl(a.ElementAt(j)));
                }
            }
            return list;
        }
        #endregion

        #region Add
        public void Add(BLCustomer c)
        {
            dal.Customers.Add(Cast.customerTodal(c));
        }
        #endregion

        #region Update
        public void Update(BLCustomer customer)
        {
            dal.Customers.Update(Cast.customerTodal(customer));


        }
        #endregion

        #region Delete

        public void Delete(string a)
        {
            dal.Customers.Delete(a);
        }

        #endregion




    }

}
