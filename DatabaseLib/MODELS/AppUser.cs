using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib.MODELS
{
    [Serializable]
    public class AppUser
    {
        public int Id { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string Address { get; set; }
    }
}
