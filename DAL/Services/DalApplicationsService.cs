using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DalApplicationsService : IDalApplications
    {
        dbcontext db;
        public DalApplicationsService(dbcontext data)
        {
            db = data;
        }

        public List<Application> GetApplications()
        {
            return db.Applications.ToList();
        }

        public async Task Add (Application application)
        {
            db.Applications.Add(application);
            await db.SaveChangesAsync();
        }

    public void Update(Application application)
        {
            Application? applic = db.Applications.Find(application.ApplicationId);
            if(applic != null)
            {
                applic.ApplicationDate = application.ApplicationDate!= null ?application.ApplicationDate:DateTime.Now;
                applic.LastApplicationDate = application.LastApplicationDate!= null? application.LastApplicationDate:DateTime.Now;
                applic.ApplicationStatus = application.ApplicationStatus!=null?application.ApplicationStatus:10;
            }
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var list = db.Applications.ToList();
            db.Applications.Remove(list.Find(x => x.ApplicationId == id));
            db.SaveChanges();
        }
    }
}
