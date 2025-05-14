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
            AList.ForEach(a => list.Add(assessorTobl(a)));  
            return list;
        }
        #endregion

        #region GetCustomers
        public List<BLCustomer> GetCustomers(string id)
        {
            var AList = dal.Assessors.GetCustomers(id);
            List<BLCustomer> list = new();
            AList.ForEach(a => list.Add(((BLCustomersService)customerBl).customerTobl(a)));
            return list;
        }
        #endregion

        #region GetApplications
        public List<BLApplications> GetApplication(string id)
        {
            var AList = dal.Assessors.GetApplications(id);
            List<BLApplications> list = new();
            AList.ForEach(a => list.Add(((BLApplicationsService)applicationBl).applicationTobl(a)));
            return list;
        }
        #endregion

        #region GetAssessments

        public List<BLAssessment> GetAssessment(string id)
        {
            var AList = dal.Assessors.GetAssessments(id);
            List<BLAssessment> list = new();
            AList.ForEach(a => list.Add(((BLAssessmentService)assessmentBl).assessmentTobl(a)));
            return list;
        }
        #endregion

        #region GetApartmentDetails

        public List<BLApartmentDetails> GetApartmentDetails(string id)
        {
            var AList = dal.Assessors.GetApartmentsDetails(id);
            List<BLApartmentDetails> list = new();
            AList.ForEach(a => list.Add(((BLApartmenetDetailsService)apartmentDetailsBL).apartmentDetailsTobl(a)));
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
                    list.Add(((BLChatService)chatBl).chatTobl(a.ElementAt(j)));
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
         if(o!=null) return assessorTobl(o);
            return null;
           
        }
        #endregion

        #region Add
        public void Add(BLAssessor a)
        {
            dal.Assessors.Add(assessorTodal(a));
        }
        #endregion

        #region Update

        public void Update(BLAssessor assessor)
        {
            dal.Assessors.Update(assessorTodal(assessor));


        }


        #endregion

        #region Delete

        public void Delete(string a) 
        {
            dal.Assessors.Delete(a);
        }

        #endregion

        #region  assessorTobl
     public   BLAssessor assessorTobl(Assessor a)
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
                NumOfCustomers = (int)a.NumOfCustomers,
            };
            return bla;
        }
        #endregion

        #region assessorTodal
       public Assessor assessorTodal(BLAssessor bla)
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
