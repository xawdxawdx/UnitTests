﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace magazin.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
