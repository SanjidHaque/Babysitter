using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabySitter.Models
{
    public class Employer: CellNumber
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public EmergencyContact EmergencyContact { get; set; }
        public int EmergencyContactId { get; set; }
        
        public ICollection<Child> Children { get; set; }
}


    }
