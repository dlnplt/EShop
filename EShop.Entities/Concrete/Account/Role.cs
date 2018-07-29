﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Entities.Concrete.Account
{
    public class Role
    {
        public int ID { get; set; }
        public string RoleName { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
