using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabySitter.Models
{
    public class EmergencyContact: CellNumber
    {
        public int Id { get; set; }
        public string Relation { get; set; }
    }
}