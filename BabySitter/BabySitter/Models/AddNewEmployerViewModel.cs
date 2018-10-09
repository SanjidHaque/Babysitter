using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BabySitter.Models
{
    public class AddNewEmployerViewModel
    {
        [Required(ErrorMessage = "*Employer's name is reqiured!")]
        public string EmployerName { get; set; }

        [Required(ErrorMessage = "*Employer's address is reqiured!")]
        public string EmployerAddress { get; set; }

        [Required(ErrorMessage = "*Employer's cell number is reqiured!")]
        public int EmployerCellNumber { get; set; }
        public int EmployerChildNo { get; set; }

        [Required(ErrorMessage = "*Child's name is reqiured!")]
        public string ChildName { get; set; }

        [Required(ErrorMessage = "*Child's age is reqiured!")]
        public int ChildAge { get; set; }


        [Required(ErrorMessage = "*Child's health condition is reqiured!")]
        public string ChildHeath { get; set; }

        [Required(ErrorMessage = "*Child's interest is reqiured!")]
        public string ChildInterest { get; set; }

        [Required(ErrorMessage = "*Emergency contact's name is reqiured!")]
        public string EmergContName { get; set; }

        [Required(ErrorMessage = "*Emergency contact's cell number is reqiured!")]
        public int EmergContCellnumber { get; set; }

        [Required(ErrorMessage = "*Emergency contact's relation with employer is reqiured!")]
        public string EmerContRelation { get; set; }

        public int NewEmployersId { get; set; }
     


    }
}