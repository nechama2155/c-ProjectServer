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
    public class BLApplicationsService : IBLApplications
    {
        IDal dal;
        IBLAssessor assessorBl;
        IBLCustomer customerBl;
        IBLApartmentDetails apartmentDetailsBl;


        public BLApplicationsService(IDal dal, IBLAssessor assessorBl, IBLCustomer customerBl, IBLApartmentDetails apartmentDetailsBl)
        {


            this.dal = dal;
            this.assessorBl = assessorBl;
            this.customerBl = customerBl;
            this.apartmentDetailsBl = apartmentDetailsBl;
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
            var list = dal.Applications.GetApplications();
            if (list != null)
            {

                var code = list[list.Count() - 1].ApplicationId;
                return ++code;
            }
            else return 1000;
        }
        #region Add


        public async Task<BLAssessor> Add(BlFull full, int code)
        {

            full.application.ApplicationId = code;
            // מציאת שמאים פנויים
            var list = dal.Assessors.GetAssessorsSimple().FindAll(x => x.Available == true);
            //מה קורה כשאין שמאי פנוי 
            //
            //var count = list.Count();
            Random r = new Random();
            int ind = r.Next(0, list.Count());

            BLAssessor b = (((BLAssessorService)assessorBl).assessorTobl(list[ind]));

            b.NumOfCustomers = b.NumOfCustomers + 1;
            if (b.NumOfCustomers == ConstantCls.NumCustomer)
            { b.Available = false; }
            full.application.AssessorId = b.AssessorId;

            Task a = dal.Applications.Add(applicationTodal(full.application));
            while (!a.IsCompletedSuccessfully) ;

            ///////////////////////
            full.apartment.ApartmentId = code;
            full.apartment.CustomerId = full.customer.CustomerId;

            Customer? c = dal.Customers.GetCustomers().Find(x => x.CustomerId == full.customer.CustomerId);
            if (c == null)
                await dal.Customers.Add(((BLCustomersService)customerBl).customerTodal((full.customer)));

            /////////////////////////

            Task e = dal.ApartmentDetails.Add(((BLApartmenetDetailsService)apartmentDetailsBl).apartmentDetailsTodal(full.apartment));
            while (!e.IsCompletedSuccessfully) ;

            Task f = dal.Assessments.Add(code);
            //////////////////// 
            while (!f.IsCompletedSuccessfully) ;
            dal.Assessors.Update(((BLAssessorService)assessorBl).assessorTodal(b));
            ////////////// 

            return (((BLAssessorService)assessorBl).assessorTobl(list[ind]));

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
        public Application applicationTodal(BLApplications blapp)
        {
            Application a = new Application()
            {
                ApplicationId = blapp.ApplicationId,
                AssessorId = blapp.AssessorId,
                ApplicationDate = blapp.ApplicationDate,
                LastApplicationDate = blapp.LastApplicationDate,
                ApplicationStatus = blapp.ApplicationStatus,
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



    }
}   

