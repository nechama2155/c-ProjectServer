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
    public class BLAssessmentService : IBLAssessment
    {
        IDal dal;
        public BLAssessmentService(IDal dal)
        {
            this.dal = dal;
        }
        #region GetAll
        public List<BLAssessment> GetAll()
        {
            var AList = dal.Assessments.GetAssessments();
            List<BLAssessment> list = new();
            AList.ForEach(a => list.Add(Cast.assessmentTobl(a)));
            return list;
        }
        #endregion

        #region GetById
        public BLAssessment GetById(int id)
        {
            var AList = dal.Assessments.GetAssessments();
            var o = AList.Find(x => x.AssessmentId == id);
            return Cast.assessmentTobl(o);
        }
        #endregion

        #region Add
        public void Add(int id)
        {
           dal.Assessments.Add(id); 
        }
        #endregion

        #region Update

        public void Update(BLAssessment assessment)
        {
            dal.Assessments.Update(Cast.assessmentTodal(assessment));
            
        }
        #endregion

        #region Delete

        public void Delete(int a)
        {
            dal.Assessments.Delete(a);

        }
        #endregion

    }
}
