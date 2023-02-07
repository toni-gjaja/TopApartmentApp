using DatabaseLib.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Public.Models.VM
{
    public class UserVM
    {
        public AppUser AppUser { get; set; }

        public IList<ApartmentReview> Reviews { get; set; }

        public IList<Reservation> Reservations { get; set; }
    }
}