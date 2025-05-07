using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLAssessment
    {
        List<BLAssessment> GetAll();
        BLAssessment GetById(int id);
        void Add(int id);
        void Update(BLAssessment assessment);

        void Delete(int id);


    }
}
