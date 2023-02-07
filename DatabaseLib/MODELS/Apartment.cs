using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib.MODELS
{
    
    public class Apartment
    {
        
        public int Id { get; set; }
        public ApartmentOwner Owner { get; set; }
        public ApartmentStatus ApartmentStatus { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string Price { get; set; }
        public string MaxAdults { get; set; }
        public string MaxChildren { get; set; }
        public string TotalRooms { get; set; }
        public string BeachDistance { get; set; }

    }
}
