using Microsoft.AspNetCore.Mvc;
using UserRegistration.Business.Services;
using UserRegistration.Data.Models;

namespace User_Registration.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        public IActionResult Create()
        {
            ViewBag.States = _userService.GetStates();
            return View();
        }

        [HttpPost]
        public IActionResult Create(userRegistration user)
        {
            if (ModelState.IsValid)
            {
                _userService.RegisterUser(user);
                return RedirectToAction("Index");
            }

            ViewBag.States = _userService.GetStates();
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = _userService.GetUserById(id);
            ViewBag.States = _userService.GetStates();
            ViewBag.Cities = _userService.GetCitiesByStateId(user.StateId);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(userRegistration user)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user);
                return RedirectToAction("Index");
            }

            ViewBag.States = _userService.GetStates();
            ViewBag.Cities = _userService.GetCitiesByStateId(user.StateId);
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            var user = _userService.GetUserById(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("Index");
        }

        public JsonResult GetCities(int stateId)
        {
            var cities = _userService.GetCitiesByStateId(stateId);
            return Json(cities);
        }
    }
}
