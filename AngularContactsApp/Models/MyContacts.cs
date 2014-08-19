using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularContactsApp.Models
{
    public class MyContacts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Int64 MobileNumber { get; set; }
        public string Email { get; set; }
    }
}