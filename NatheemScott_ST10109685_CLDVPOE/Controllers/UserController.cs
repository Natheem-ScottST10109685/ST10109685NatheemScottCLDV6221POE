using Microsoft.AspNetCore.Mvc;
using NatheemScott_ST10109685_CLDVPOE.Models;

namespace NatheemScott_ST10109685_CLDVPOE.Controllers
{
    public class UserController : Controller
    {
        public userTbl usrtbl = new userTbl();

        [HttpPost]
        public IActionResult Signup(userTbl user)
        {
            var result = usrtbl.insert_User(user);
            return RedirectToAction("Login", "Home");
        }
    }
}