using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDalAssessment
    {
        List<Assessment> GetAssessments();

        Task Add(int id);

        void Update(Assessment assessment);
        void Delete(int id);
    }
}
