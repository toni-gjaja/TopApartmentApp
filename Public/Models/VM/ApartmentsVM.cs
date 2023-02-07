using DatabaseLib.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Public.Models.VM
{
    public class ApartmentsVM
    {
        public IList<Apartment> Apartments { get; set; }
    }
}