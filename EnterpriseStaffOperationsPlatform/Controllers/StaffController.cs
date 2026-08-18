using Microsoft.AspNetCore.Mvc;
using EnterpriseStaffOperationsPlatform.Models;
using EnterpriseStaffOperationsPlatform.Services;

namespace EnterpriseStaffOperationsPlatform.Controllers
{
    public class StaffController : Controller
    {
        //Accessing the staff service
        private readonly StaffService _staffService;

        //Constructor injection
        public StaffController(StaffService staffService)
        { }
    }
}
