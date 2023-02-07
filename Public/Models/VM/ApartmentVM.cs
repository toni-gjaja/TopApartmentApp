using DatabaseLib.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Public.Models.VM
{
    public class ApartmentVM
    {
        public Apartment Apartment { get; set; }

        public IList<ApartmentReview> ApartmentReviews { get; set; }

        public IList<AssignedTag> AssignedTags { get; set; }

        public int Rating { get; set; }


    }
}