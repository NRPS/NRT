﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalWebAPI.Models
{
    public class UserMaster
    { 
        public int UserID { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}