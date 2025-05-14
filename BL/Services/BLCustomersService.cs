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
        IBLChat chatBl;
        IDal dal;
        IBLApartmentDetails apartmentDetailsBl;
        IBLAssessment assessmentBl ;
        IBLApplications applicationsBl;
        IBLAssessor assessorBl;
        public  BLCustomersService(IDal dal, IBLAssessor assessorBl, IBLApplications applicationsBl, IBLChat chatBl, IBLAssessment assessmentBl, IBLApartmentDetails apartmentDetailsBl)
        {
            this.chatBl = chatBl;
            this.dal = dal;
            this.apartmentDetailsBl = apartmentDetailsBl;
            this.assessmentBl = assessmentBl;   
            this.applicationsBl = applicationsBl;
            this.assessorBl = assessorBl;   

        }

        #region GetAll
        public List<BLCustomer> GetAll()
        {
            var AList = dal.Customers.GetCustomers();
            List<BLCustomer> list = new();
            AList.ForEach(a => list.Add(customerTobl(a)));
            return list;
        }
        #endregion

        #region GetById
        public BLCustomer GetById(string id)
        {
            var AList = dal.Customers.GetCustomers();
            var o = AList.Find(x => x.CustomerId == id);
            return customerTobl(o);

        }
        #endregion

        #region GetAssesors
        public List <BLAssessor> GetAssessor(string id) {
            var AList = dal.Customers.GetAssessors(id);
            List<BLAssessor> list = new();
            AList.ForEach(a => list.Add(((BLAssessorService)assessorBl).assessorTobl(a)));
            return list;
            ;
        }
        

        #endregion

        #region GetApplications
        public List<BLApplications> GetApplication(string id)
        {
            var AList = dal.Customers.GetApplications(id);
            List<BLApplications> list = new();
            AList.ForEach(a => list.Add(((BLApplicationsService)applicationsBl).applicationTobl(a)));
            return list;
        }
        #endregion

        #region GetAssessments

        public List<BLAssessment> GetAssessment(string id)
        {
            var AList = dal.Customers.GetAssessments(id);
            List<BLAssessment> list = new();
            AList.ForEach(a => list.Add(((BLAssessmentService)assessorBl).assessmentTobl(a)));
            return list;
        }
        #endregion

        #region GetApartmentDetails

        public List<BLApartmentDetails> GetApartmentDetails(string id)
        {
            var AList = dal.Customers.GetApartmentsDetails(id);
            List<BLApartmentDetails> list = new();
            AList.ForEach(a => list.Add(((BLApartmenetDetailsService)apartmentDetailsBl).apartmentDetailsTobl(a)));
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
                    list.Add(((BLChatService)chatBl).chatTobl(a.ElementAt(j)));
                }
            }
            return list;
        }
        #endregion

        #region Add
        public void Add(BLCustomer c)
        {
            dal.Customers.Add(customerTodal(c));
        }
        #endregion

        #region Update
        public void Update(BLCustomer customer)
        {
            dal.Customers.Update(customerTodal(customer));


        }
        #endregion

        #region Delete

        public void Delete(string a)
        {
            dal.Customers.Delete(a);
        }

        #endregion


        #region customerTodal
      public  Customer customerTodal(BLCustomer blc)
        {
            Customer c = new Customer()
            {
                CustomerId = blc.CustomerId,
                CustomerFirstName = blc.CustomerFirstName,
                CustomerLastName = blc.CustomerLastName,
                CustomerCity = blc.CustomerCity,
                CustomerAddress = blc.CustomerAddress,
                CustomerPhone = blc.CustomerPhone,
                CustomerEmail = blc.CustomerEmail != null ? blc.CustomerEmail : "",
            };
            return c;
        }
        #endregion

        #region customerTobl
      public  BLCustomer customerTobl(Customer c)
        {
            if (c != null)
            {
                BLCustomer bla = new BLCustomer()
                {
                    CustomerId = c.CustomerId,
                    CustomerFirstName = c.CustomerFirstName,
                    CustomerLastName = c.CustomerLastName,
                    CustomerCity = c.CustomerCity,
                    CustomerAddress = c.CustomerAddress,
                    CustomerPhone = c.CustomerPhone,
                    CustomerEmail = c.CustomerEmail != null ? c.CustomerEmail : "",

                };
                return bla;
            }
            return null;
        }
        #endregion

    }

}
