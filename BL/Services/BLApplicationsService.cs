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
        public BLApplicationsService(IDal dal)
        {
            this.dal = dal; 
        }
        #region GetAll
        public List<BLApplications> GetAll()
        {
            var AList = dal.Applications.GetApplications();
            List<BLApplications> list = new();
            AList.ForEach(a => list.Add(Cast.applicationTobl(a)));
            return list;
        }
        #endregion

        #region GetById
        public BLApplications GetById(int id)
        {
            var AList = dal.Applications.GetApplications();
            var o = AList.Find(x => x.ApplicationId == id);
            return Cast.applicationTobl(o);

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
            
            
            Random r = new Random();
            int ind = r.Next(0, list.Count());

          
            BLAssessor b =Cast.assessorTobl(list[ind]);
            b.NumOfCustomers = b.NumOfCustomers + 1;
            if (b.NumOfCustomers == ConstantCls.NumCustomer)
            { b.Available = false; }
            full.application.AssessorId = b.AssessorId;

           await  dal.Applications.Add(Cast.applicationTodal(full.application));
            

            ///////////////////////
            full.apartment.ApartmentId = code;
            full.apartment.CustomerId = full.customer.CustomerId;

            Customer? c = dal.Customers.GetCustomers().Find(x => x.CustomerId == full.customer.CustomerId);
            if (c == null)
                await dal.Customers.Add(Cast.customerTodal((full.customer)));

            /////////////////////////

           
           await dal.ApartmentDetails.Add(Cast.apartmentDetailsTodal(full.apartment));
           
           await dal.Assessments.Add(code);
            //////////////////// 
         
            dal.Assessors.Update(Cast.assessorTodal(b));
            ////////////// 

            return (Cast.assessorTobl(list[ind]));

        }

        #endregion

        #region Update

        public void Update(BLApplications application)
        {
            dal.Applications.Update(Cast.applicationTodal(application));
        }


        #endregion

        #region Delete

        public void Delete(int a)
        {
            dal.Applications.Delete(a);
        }

        #endregion

      


    }
}   

