using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLChat
    {
        public int ChatId { get; set; }

        public int ApplicationId { get; set; }

        public string From { get; set; }

        public string Information { get; set; }

        public bool Read { get; set; }

        public DateTime SendDate { get; set; }

        public string To { get; set; } 
    }
}
