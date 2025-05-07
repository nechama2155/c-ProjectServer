using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DalAssessmentsService:IDalAssessment
    {
        dbcontext db;

        public  DalAssessmentsService(dbcontext data)
        {
            this.db = data;
        }
        public List<Assessment> GetAssessments()
        {
            return db.Assessments.ToList();

        }
        public async Task Add(int id)
        {
            Assessment assess = new Assessment();
            assess.AssessmentId = id;
            db.Assessments.Add(assess);
          await  db.SaveChangesAsync();
        }
        public void Update(Assessment assessment)
        {
            Assessment assess = db.Assessments.Find(assessment.AssessmentId);
                if(assess!=null) {
                assess.Plot=assessment.Plot;
                assess.Block = assessment.Block;
                assess.SubPlot = assessment.SubPlot;    
                assess.ConstructionYear = assessment.ConstructionYear;  
                assess.AcquisionPrice = assessment.AcquisionPrice;
                assess.AssessmentGoal = assessment.AssessmentGoal;
                assess.LegalState = assessment.LegalState;
                assess.BuildingPermit = assessment.BuildingPermit;
                assess.IrregularitiesBuilding = assessment.IrregularitiesBuilding;
            } 
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var list = db.Assessments.ToList();
            db.Assessments.Remove(list.Find(x => x.AssessmentId == id));
            db.SaveChanges();
        }

       

    }
}
