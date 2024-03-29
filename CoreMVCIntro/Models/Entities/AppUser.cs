﻿using CoreMVCIntro.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCIntro.Models.Entities
{
    public class AppUser:BaseEntity
    {
        public string UserName { get; set; }
        public UserRole UserRole { get; set; }

        //Relational Properties
        public virtual AppUserProfile Profile { get; set; }

    }
}
