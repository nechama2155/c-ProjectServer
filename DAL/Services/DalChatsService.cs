using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DalChatsService:IDalChat
    {
        dbcontext db;

        public DalChatsService(dbcontext data)
        {
            db = data;
        }

        public void Add(Chat chat)
        {
            db.Chats.Add(chat);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var list = db.Chats.ToList();
            var c = list.Find(x => x.ChatId == id);

            db.Chats.Remove(c);
            db.SaveChanges();
        }

        public List<Chat> GetChats()
        {
            var l = db.Chats.ToList();
            return l;
        }

        public void Update(Chat chat)
        {
            Chat? ch = db.Chats.Find(chat.ChatId);
            if (ch != null)
            {
                ch.ApplicationId = chat.ApplicationId;
                ch.Read = chat.Read;
                ch.From = chat.From;
                ch.SendDate = chat.SendDate;    
                ch.Information = chat.Information;
                ch.To = chat.To;
            }
            db.SaveChanges();
        }
    }
}
