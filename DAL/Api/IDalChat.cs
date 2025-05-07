using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDalChat
    {

        List<Chat> GetChats();
        void Add(Chat chat);
        void Update(Chat chat);
        void Delete(int id);
    }
}
