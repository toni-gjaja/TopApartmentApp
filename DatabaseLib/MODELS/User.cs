using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib.MODELS
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string PhoneNumberConfirmed { get; set; }

        public string Address { get; set; }

        public string Mail { get; set; }

        public string MailConfirmed { get; set; }
    }
}
