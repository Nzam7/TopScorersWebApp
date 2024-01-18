using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopScorersWebApp.Models
{
    public class Person { 
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Score { get; set; }

        public string FullName => $"{FirstName} {SecondName}";
    }
}