using BL.Api;
using BL.Models;
using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLChatService : IBLChat
    {
        IDal dal;
        public BLChatService(IDal dal)
        {
            this.dal = dal;
        }

        public void Add(BLChat id)
        {
            var c1 = dal.Chats.GetChats();
            var code = 1;
            if (c1 != null)
            {
                code = c1[c1.Count() - 1].ChatId;
                code++;
            }
            id.ChatId = code;
            dal.Chats.Add(chatTodal(id));
        }

        public void Delete(int id)
        {
            dal.Chats.Delete(id);
        }

        public List<BLChat> GetAll()
        {
            var AList = dal.Chats.GetChats();
            List<BLChat> list = new();
            AList.ForEach(a => list.Add(chatTobl((Chat)a)));
            return list;
        }

        public BLChat GetById(int id)
        {
            var AList = dal.Chats.GetChats();
            var o = AList.Find(x => x.ChatId == id);
            return chatTobl((Chat)o);
        }   

        public void Update(BLChat chat)
        {
            dal.Chats.Update(chatTodal(chat));
        }
   
    #region customerTodal
    Chat chatTodal(BLChat chat)
    {
            Chat c = new Chat()
        {
            
            ChatId = chat.ChatId,
            ApplicationId = chat.ApplicationId,
            Read = chat.Read,
            From = chat.From,
            SendDate =chat.SendDate,    
            Information = chat.Information,
            To = chat.To,   
        };
        return c;
    }
      
    #endregion

    #region chatTobl
   public BLChat chatTobl(Chat chat)
    {
        if (chat != null)
        {
            BLChat ch = new BLChat()
            {
                ChatId = chat.ChatId,
                ApplicationId = (int)chat.ApplicationId,
                Read = (bool)chat.Read,
                SendDate=chat.SendDate,
                From = chat.From,
                Information = chat.Information,
                To = chat.To,   
            };
            return ch;
        }
        return null;
    }

        #endregion
    }
}
