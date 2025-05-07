using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlFull
    {
        public BLApplications  application { get; set; }
        public  BLApartmentDetails apartment  { get; set; }
        public BLCustomer customer { get; set; }
    }
}
