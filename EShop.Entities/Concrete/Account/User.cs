﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace EShop.Entities.Concrete.Account
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Role Role { get; set; }


        [ForeingnKey("ID")]
        public int RoleID { get; set; }
    }
}
