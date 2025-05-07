using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLChat
    {
        List<BLChat> GetAll();
        BLChat GetById(int id);
        void Add(BLChat id);
        void Update(BLChat chat);
        void Delete(int id);
    }
}
