using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLApplications
    {
        List<BLApplications> GetAll();
        BLApplications GetById(int id);
        Task <BLAssessor> Add(BlFull full,int code);
        int GetCode();
        void Update(BLApplications application);

        void Delete(int id);
    }
}
