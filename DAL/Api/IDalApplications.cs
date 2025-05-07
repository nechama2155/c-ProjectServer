using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDalApplications
    {
        List<Application> GetApplications();
        Task Add(Application application);
        void Update(Application application);
        void Delete(int id);
    }
}
