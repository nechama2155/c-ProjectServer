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
        public  BLCustomersService(IDal dal, IBLChat chatBl)
        {
            this.chatBl = chatBl;
            this.dal = dal;
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
            AList.ForEach(a => list.Add(assessorTobl(a)));
            return list;
            ;
        }
        

        #endregion

        #region GetApplications
        public List<BLApplications> GetApplication(string id)
        {
            var AList = dal.Customers.GetApplications(id);
            List<BLApplications> list = new();
            AList.ForEach(a => list.Add(applicationTobl(a)));
            return list;
        }
        #endregion

        #region GetAssessments

        public List<BLAssessment> GetAssessment(string id)
        {
            var AList = dal.Customers.GetAssessments(id);
            List<BLAssessment> list = new();
            AList.ForEach(a => list.Add(assessmentTobl(a)));
            return list;
        }
        #endregion

        #region GetApartmentDetails

        public List<BLApartmentDetails> GetApartmentDetails(string id)
        {
            var AList = dal.Customers.GetApartmentsDetails(id);
            List<BLApartmentDetails> list = new();
            AList.ForEach(a => list.Add(apartmentDetailsTobl(a)));
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
        Customer customerTodal(BLCustomer blc)
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
        BLCustomer customerTobl(Customer c)
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

        #region  assessorTobl
        BLAssessor assessorTobl(Assessor a)
        {
            if(a != null) { 
            BLAssessor bla = new BLAssessor()
            {
                AssessorId = a.AssessorId,
                AssessorFirstName = a.AssessorFirstName,
                AssessorLastName = a.AssessorLastName,
                AssessorCity = a.AssessorCity,
                AssessorAddress = a.AssessorAddress,
                AssessorPhone = a.AssessorPhone,
                AssessorEmail = a.AssessorEmail,
                Seniority = a.Seniority,
                Available = a.Available,
                IsManager = a.IsManager,
                NumOfCustomers = (int)a.NumOfCustomers,
            };
            return bla;
            }
            return null;
        }
        #endregion

        #region applicationTobl
        BLApplications applicationTobl(Application a)
        {

            BLApplications blapp = new BLApplications()
            {
                ApplicationId = a.ApplicationId,
                AssessorId = a.AssessorId,
                ApplicationDate = a.ApplicationDate,
                LastApplicationDate = a.LastApplicationDate,
                ApplicationStatus = a.ApplicationStatus,
            };
            return blapp;
        }
        #endregion

        #region assessmentTobl
        BLAssessment assessmentTobl(Assessment a)
        {
            if (a != null)
            {
                BLAssessment bla = new BLAssessment()
                {
                    AssessmentId = a.AssessmentId,
                    Block = a.Block != null ? a.Block : "",
                    Plot = a.Plot != null ? a.Plot : "",
                    SubPlot = a.SubPlot != null ? a.SubPlot : "",
                    ConstructionYear = a.ConstructionYear != null ? a.ConstructionYear : "",
                    AcquisionPrice = (int)(a.AcquisionPrice != null ? a.AcquisionPrice : 0),
                    AssessmentGoal = a.AssessmentGoal != null ? a.AssessmentGoal : "",
                    LegalState = a.LegalState != null ? a.LegalState : "",
                    BuildingPermit = a.BuildingPermit != null ? a.BuildingPermit : "",
                    IrregularitiesBuilding = a.IrregularitiesBuilding != null ? a.IrregularitiesBuilding : "",
                };
                return bla;
            }
            return null;
        }
        #endregion


        #region apartmentDetailsTobl
        BLApartmentDetails apartmentDetailsTobl(ApartmentDetail a)
        {
            if (a != null)
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
            return null;
        }
        #endregion

    }

}
