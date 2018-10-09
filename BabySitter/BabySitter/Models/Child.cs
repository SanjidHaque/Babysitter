using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabySitter.Models
{
    public class Child : Name
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Health { get; set; }
        public string Interest { get; set; }
        public  Employer Employer { get; set; }
        public int EmployerId { get; set; }

    }
}