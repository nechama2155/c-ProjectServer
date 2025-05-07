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
    public class BLApplicationsService:IBLApplications
    {
        IDal dal;

        public BLApplicationsService(IDal dal)
        {
            this.dal = dal;
        }
        #region GetAll
        public List<BLApplications> GetAll()
        {
            var AList = dal.Applications.GetApplications();
            List<BLApplications> list = new();
            AList.ForEach(a => list.Add(applicationTobl(a)));
            return list;
        }
        #endregion

        #region GetById
        public BLApplications GetById(int id)
        {
            var AList = dal.Applications.GetApplications();
            var o = AList.Find(x => x.ApplicationId == id);
            return applicationTobl(o);

        }
        #endregion

        public int GetCode()
        {
                var list  = dal.Applications.GetApplications();
                if (list != null) {
                
                    var code = list[list.Count() - 1].ApplicationId;
                    return ++code;
                 }
                else return 1000;
            }
    #region Add
        

        public async Task<BLAssessor> Add(BlFull full,int code)
        {
            full.application.ApplicationId = code;
            // מציאת שמאים פנויים
            var list = dal.Assessors.GetAssessorsSimple().FindAll(x => x.Available == true);
            //מה קורה כשאין שמאי פנוי 
            //
            //var count = list.Count();
            Random r = new Random();    
            int ind = r.Next(0, list.Count());

            BLAssessor b = assessorTobl(list[ind]);

            b.NumOfCustomers = b.NumOfCustomers + 1;
            if(b.NumOfCustomers ==ConstantCls.NumCustomer )
                        { b.Available = false; }
            full.application.AssessorId = b.AssessorId;
            await dal.Applications.Add(applicationTodal(full.application));
            ///////////////////////
            full.apartment.ApartmentId = code;
            full.apartment.CustomerId = full.customer.CustomerId;

            Customer? c= dal.Customers.GetCustomers().Find(x=> x.CustomerId == full.customer.CustomerId);
            if(c==null )
               await dal.Customers.Add(customerTodal(full.customer));
           /////////////////////////

           await  dal.ApartmentDetails.Add(apartmentDetailsTodal(full.apartment));
            ////////////////////
           await  dal.Assessments.Add(code);
            ////////////////////
            dal.Assessors.Update(assessorTodal(b));
            //////////////
            return assessorTobl(list[ind]);
        }

        #endregion

        #region Update

        public void Update(BLApplications application)
        {
            dal.Applications.Update(applicationTodal(application));
        }


        #endregion

        #region Delete

        public void Delete(int a)
        {
            dal.Applications.Delete(a);
        }

        #endregion

        #region applicationTodal
        Application applicationTodal(BLApplications blapp)
        {
            Application a = new Application()
            {
                ApplicationId = blapp.ApplicationId,
                AssessorId = blapp.AssessorId,
                ApplicationDate = blapp.ApplicationDate,
                LastApplicationDate = blapp.LastApplicationDate,
                ApplicationStatus = blapp.ApplicationStatus,
                //AssessmentId = blapp.AssessmentId != 0 ? blapp.AssessmentId : null,
                //ApartmentId = blapp.ApartmentId != 0 ? blapp.ApartmentId : null,
            };

            return a;
        }
        #endregion

        #region applicationTobl
        public BLApplications applicationTobl(Application a)
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

        #region  assessorTobl
        BLAssessor assessorTobl(Assessor a)
        {
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
            };
            return bla;
        }
        #endregion

        #region apartmentDetailsTodal
        static ApartmentDetail apartmentDetailsTodal(BLApartmentDetails a)
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

        #region assessorTodal
        Assessor assessorTodal(BLAssessor bla)
        {
            Assessor a = new Assessor()
            {
                AssessorId = bla.AssessorId,
                AssessorFirstName = bla.AssessorFirstName,
                AssessorLastName = bla.AssessorLastName,
                AssessorCity = bla.AssessorCity,
                AssessorAddress = bla.AssessorAddress,
                AssessorPhone = bla.AssessorPhone,
                AssessorEmail = bla.AssessorEmail,
                Seniority = bla.Seniority,
                Available = bla.Available,
                IsManager = bla.IsManager,
                NumOfCustomers = bla.NumOfCustomers,
            };
            return a;
        }


        #endregion
    }
}
