﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace magazin.Models
{
    public class User
    {
        public int Id { get; set; }
     
        public string Login { get; set; }
        public string Password { get; set; }

        public UserProfile Profile { get; set; }
    }
}
