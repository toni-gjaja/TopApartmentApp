﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib.MODELS
{
    public class ApartmentReview
    {
        public int ApartmentId { get; set; }

        public int UserId { get; set; }

        public string Details { get; set; }

        public int Stars { get; set; }
    }
}
