﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Model.Entities
{
    public class UserEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }        
        public UserEntityType UserType { get; set; }
        public decimal Money { get; set; }
    }
}
