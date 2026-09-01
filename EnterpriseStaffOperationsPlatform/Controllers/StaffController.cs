using Microsoft.AspNetCore.Mvc;
using EnterpriseStaffOperationsPlatform.Models;
using EnterpriseStaffOperationsPlatform.Services;
using Microsoft.AspNetCore.Authorization;

namespace EnterpriseStaffOperationsPlatform.Controllers
{
    //Authenticated administrators only
    [Authorize(Roles = "Administrator")]
    public class StaffController : Controller
    {
        //Accessing the staff service
        private readonly StaffService _staffService;

        //Constructor injection
        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }

        //List all staff memebers
        public IActionResult Index()
        {
            var staffMembers = _staffService.GetAllStaffMembers();

            return View(staffMembers);
        }

       
        //Process the added staff member
        [HttpPost]
        public IActionResult Create(StaffMember staff)
        {
            if(!ModelState.IsValid)
            {
                return View(staff);
            }

            _staffService.AddStaffMember(staff);

            return RedirectToAction("Index");
        }

    
        //Process the updated staff member information
        [HttpPost]
        public IActionResult Edit(StaffMember staff)
        {
            if(!ModelState.IsValid)
            {
                return View(staff);
            }

            var updated = _staffService.UpdateStaffMember(staff);

            if(!updated)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        
        //Processing the deleting off staff memeber
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleted = _staffService.DeleteStaffMember(id);

            if(!deleted)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

    }
}
