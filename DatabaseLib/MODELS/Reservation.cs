using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib.MODELS
{
    public class Reservation
    {
        public int Id { get; set; }

        public int ApartmentId { get; set; }

        public string ApartmentName { get; set; }

        public string Details { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        
    }
}
