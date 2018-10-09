using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BabySitter.Models;

namespace BabySitter.Controllers
{
    public class BabySitterController : Controller
    {
        private ApplicationDbContext _context;
        public BabySitterController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: BabySitter
        public ActionResult IndexofBabySitter()
        {
            return View();
        }
        public ActionResult ViewEmployers()
        {
            var allInfoOfEmployers = _context.Employers.Include(c => c.Children).Include(c => c.EmergencyContact).ToList();
            return View(allInfoOfEmployers);
        }

        public ActionResult AddEmployers()
        {
            return View();
        }

        public ActionResult DeleteEmployers()
        {
            var employerList = _context.Employers.ToList();
            return View(employerList);
        }

        [Route("Babysitter/{empId}/AfterDeletingEmployers")]
        public ActionResult AfterDeletingEmployers(int empId)
        {
            var delEmerCont = new List<EmergencyContact>();
            var delChildren = new List<Child>();
            var delEmp =  new List<Employer>();
             delEmerCont = _context.EmergencyContacts.Where(e => e.Id == empId).ToList();
            _context.EmergencyContacts.RemoveRange(delEmerCont);
            _context.SaveChanges();
             delChildren = _context.Children.Where(c => c.EmployerId == empId).ToList();
            _context.Children.RemoveRange(delChildren);
            _context.SaveChanges();
             delEmp = _context.Employers.Where(e => e.Id == empId).ToList();
            _context.Employers.RemoveRange(delEmp);
            _context.SaveChanges();
            return RedirectToAction("DeleteEmployers");
        }

        public ActionResult LearnMore()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddingNewEmployer(AddNewEmployerViewModel newEmployerViewModel)
        {
            var newEmerCont = new EmergencyContact();
            newEmerCont.name = newEmployerViewModel.EmergContName;
            newEmerCont.cellNumber = newEmployerViewModel.EmergContCellnumber;
            newEmerCont.Relation = newEmployerViewModel.EmerContRelation;
            _context.EmergencyContacts.Add(newEmerCont);
            _context.SaveChanges();

            var newEmployer = new Employer();
            newEmployer.name = newEmployerViewModel.EmployerName;
            newEmployer.Address = newEmployerViewModel.EmployerAddress;
            newEmployer.cellNumber = newEmployerViewModel.EmployerCellNumber;
            newEmployer.EmergencyContactId = newEmerCont.Id;
            _context.Employers.Add(newEmployer);
           _context.SaveChanges();
          
            return RedirectToAction("AddingNewChildren","BabySitter" ,new {empId= newEmployer.Id});
        }


        [Route("BabySitter/{empId}/AddingNewChildren")]
        public ActionResult AddingNewChildren(int empId/*, int empChildrenNo*/)
        {
            var emp = new NewChildrenCount { EmpId = empId };
            return View("AddingNewChildren",emp);
        }

        [HttpPost]
        [Route("BabySitter/{empId}/SavingNewChildren")]
        public ActionResult SavingNewChildren(int empId , NewChildrenCount newChildren)
        {
               var newChild = new Child();
              newChild.EmployerId = empId;
              newChild.Age = newChildren.AddNewEmployerViewModel.ChildAge;
              newChild.name = newChildren.AddNewEmployerViewModel.ChildName;
              newChild.Health = newChildren.AddNewEmployerViewModel.ChildHeath;
              newChild.Interest = newChildren.AddNewEmployerViewModel.ChildInterest;
              _context.Children.Add(newChild);
              _context.SaveChanges();
            return View(empId);
        }
    }
}
