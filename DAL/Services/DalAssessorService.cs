using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.Services
{
    public class DalAssessorService : IDalAssessor
    {

        dbcontext db ;

        public DalAssessorService(dbcontext data) {
            db = data;
        
        }

        public List<Assessor> GetAssessors()
        {
                var assessors = db.Assessors
                    .Include(x => x.Applications)
                        .ThenInclude(c => c.ApartmentDetail)
                            .ThenInclude(s => s.Customer)
                    .ToList();

                return assessors;

            }
        public List<Assessor> GetAssessorsSimple()
        {
            var assessors = db.Assessors.ToList();
            return assessors;

        }



        public List<Customer> GetCustomers(string id)
        {
            Assessor listA = db.Assessors
                    .Include(x => x.Applications)
                        .ThenInclude(c => c.ApartmentDetail)
                            .ThenInclude(s => s.Customer)
                    .ToList().Find(x => x.AssessorId == id);
           

            var rr =   listA.Applications.Select(c=> c.ApartmentDetail.Customer).ToList();
            return rr;

        }
        public List<Models.Application> GetApplications(string id)
        {
          var a =  db.Applications.Where(x=> x.AssessorId == id).ToList();
            return a;
        }

        public List<Models.Assessment> GetAssessments(string id)
        {
            List<Assessor> lst = db.Assessors
                .Include(x => x.Applications)
                    .ThenInclude(c => c.Assessment)
                .ToList();
            Assessor A = lst.Find(x => x.AssessorId == id);

            var a = A.Applications.Select(x => x.Assessment).ToList();
            return a;

            //Assessor listA = GetAssessors().Find(x => x.AssessorId == id);


            //var rr = listA.Applications.Select(c => c.ApartmentDetail.Customer).ToList();
            //return rr;
        }

        public List<Models.ApartmentDetail> GetApartmentsDetails(string id)
        {
            List<Assessor> lst = db.Assessors
                    .Include(x => x.Applications)
                        .ThenInclude(c => c.ApartmentDetail)
                            .ThenInclude(s => s.Customer)
                    .ToList();
            Assessor A = lst.Find(x => x.AssessorId == id);
            //Assessor A = GetAssessors().Find(x => x.AssessorId == id);
            var a = A.Applications.Select(x => x.ApartmentDetail).ToList();
            return a;

        }
        public List<ICollection< Chat>> GetChats(string id)
        {
            List<Assessor> lst = db.Assessors
                    .Include(x => x.Applications)
                            .ThenInclude(s => s.Chats)
                    .ToList();
            Assessor A = lst.Find(x => x.AssessorId == id);
            var a = A.Applications.Select(x => x.Chats).ToList();
            return a;

        }
        public void Add(Assessor assessor)
        {
            db.Assessors.Add(assessor);
            db.SaveChanges();
        }

        public void Update(Assessor assessor)
        {
            Assessor ases = db.Assessors.Find(assessor.AssessorId);
            if (ases != null) { 
                ases.AssessorFirstName = assessor.AssessorFirstName;
                ases.AssessorLastName = assessor.AssessorLastName;
                ases.AssessorCity = assessor.AssessorCity;
                ases.AssessorPhone = assessor.AssessorPhone;
                ases.AssessorAddress = assessor.AssessorAddress;
                ases.Available = assessor.Available;
                ases.Seniority = assessor.Seniority;
                ases.AssessorEmail = assessor.AssessorEmail;
               ases.IsManager = assessor.IsManager; 
                ases.NumOfCustomers = assessor.NumOfCustomers;
            }
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            var list = db.Assessors.ToList();
            db.Assessors.Remove(list.Find(x => x.AssessorId == id));
            db.SaveChanges();
            
        }
    }
}
