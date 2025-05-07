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
            AList.ForEach(a => list.Add(assessmentTobl(a)));
            return list;
        }
        #endregion

        #region GetById
        public BLAssessment GetById(int id)
        {
            var AList = dal.Assessments.GetAssessments();
            var o = AList.Find(x => x.AssessmentId == id);
            return assessmentTobl(o);
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
            dal.Assessments.Update(assessmentTodal(assessment));
            
        }
        #endregion

        #region Delete

        public void Delete(int a)
        {
            dal.Assessments.Delete(a);

        }
        #endregion


        #region assessmentTodal
        Assessment assessmentTodal(BLAssessment bla)
        {
            Assessment a = new Assessment()
            {
                AssessmentId = bla.AssessmentId,
                Block = bla.Block,
                Plot = bla.Plot,
                SubPlot = bla.SubPlot,
                ConstructionYear = bla.ConstructionYear,
                AcquisionPrice = bla.AcquisionPrice,
                AssessmentGoal = bla.AssessmentGoal,
                LegalState = bla.LegalState,
                BuildingPermit = bla.BuildingPermit,
                IrregularitiesBuilding = bla.IrregularitiesBuilding
            };
            return a;
        }
        #endregion

        #region assessmentTobl
        BLAssessment assessmentTobl(Assessment a)
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
        #endregion


    }
}
