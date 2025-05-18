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
    public class BLAssessorService:IBLAssessor
    {
        IDal dal;
        IBLApplications applicationBl;
        IBLApartmentDetails apartmentDetailsBL;
        IBLChat chatBl;
        IBLAssessment assessmentBl ;
        IBLCustomer customerBl;
        //public int MyProperty { get; set; }
        public BLAssessorService(IDal dal,IBLApplications application, IBLCustomer customerBl, IBLAssessment assessmentBl, IBLApartmentDetails apartmentDetails, IBLChat chatBl)
        {
            this.dal = dal;
            this.applicationBl = application;
            this.apartmentDetailsBL = apartmentDetails;
            this.chatBl = chatBl;
            this.customerBl = customerBl;
            this.assessmentBl = assessmentBl;
        }


        #region GetAll
        public List<BLAssessor> GetAll()
        {
            var AList = dal.Assessors.GetAssessors();
            List<BLAssessor> list = new();
            AList.ForEach(a => list.Add(Cast.assessorTobl(a)));  
            return list;
        }
        #endregion

        #region GetCustomers
        public List<BLCustomer> GetCustomers(string id)
        {
            var AList = dal.Assessors.GetCustomers(id);
            List<BLCustomer> list = new();
            AList.ForEach(a => list.Add(Cast.customerTobl(a)));
            return list;
        }
        #endregion

        #region GetApplications
        public List<BLApplications> GetApplication(string id)
        {
            var AList = dal.Assessors.GetApplications(id);
            List<BLApplications> list = new();
            AList.ForEach(a => list.Add(Cast.applicationTobl(a)));
            return list;
        }
        #endregion

        #region GetAssessments

        public List<BLAssessment> GetAssessment(string id)
        {
            var AList = dal.Assessors.GetAssessments(id);
            List<BLAssessment> list = new();
            AList.ForEach(a => list.Add(Cast.assessmentTobl(a)));
            return list;
        }
        #endregion

        #region GetApartmentDetails

        public List<BLApartmentDetails> GetApartmentDetails(string id)
        {
            var AList = dal.Assessors.GetApartmentsDetails(id);
            List<BLApartmentDetails> list = new();
            AList.ForEach(a => list.Add(Cast.apartmentDetailsTobl(a)));
            return list;
        }
        #endregion

        #region GetChats

        public List<BLChat> GetChat(string id)
        {
            var List = dal.Assessors.GetChats(id);
            List<BLChat> list = new();
           for(int i = 0; i < List.Count(); i++)
            {
                var a = List[i];
                for (int j = 0; j <a.Count() ;j++)
                {
                    list.Add(Cast.chatTobl(a.ElementAt(j)));
                }
            }
            return list;
        }
        #endregion

        #region GetById
        public BLAssessor GetById(string id)
        {
            var AList = dal.Assessors.GetAssessors();
           var o = AList.Find(x => x.AssessorId == id);
         if(o!=null) return Cast.assessorTobl(o);
            return null;
           
        }
        #endregion

        #region Add
        public void Add(BLAssessor a)
        {
            dal.Assessors.Add(Cast.assessorTodal(a));
        }
        #endregion

        #region Update

        public void Update(BLAssessor assessor)
        {
            dal.Assessors.Update(Cast.assessorTodal(assessor));


        }


        #endregion

        #region Delete

        public void Delete(string a) 
        {
            dal.Assessors.Delete(a);
        }

        #endregion

     

    }
}
