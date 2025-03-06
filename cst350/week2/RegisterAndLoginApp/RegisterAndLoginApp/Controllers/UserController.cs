using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using RegisterAndLoginApp.Filters;
using RegisterAndLoginApp.Models;

namespace RegisterAndLoginApp.Controllers
{
    public class UserController : Controller
    {
        private IUserManager users;

        public UserController(IUserManager users)
        {
            this.users = users;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(LoginViewModel loginVM)
        {
            int userId = users.CheckCredentials(loginVM.username, loginVM.password);
            if (userId > 0)
            {
                var loggedInUser = users.GetUserById(userId);
                if (loggedInUser != null)
                {
                    string userJSON = JsonSerializer.Serialize(loggedInUser);
                    HttpContext.Session.SetString("User", userJSON);

                    return View("LoginSuccess", loggedInUser);
                }
            }

            return View("LoginFailure");
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        public IActionResult ProcessRegister(RegisterViewModel registerVM)
        {
            UserModel user = new UserModel
            {
                Username = registerVM.username,
                PasswordHash = registerVM.password,
                Groups = string.Join(",", registerVM.groups.Where(g => g.isSelected).Select(g => g.groupName))
            };

            users.AddUser(user);

            return RedirectToAction("Index");
        }

        [SessionCheckFilter]
        public IActionResult MembersOnly()
        {
            return View();
        }

        [AdminCheckFilter]
        public IActionResult AdminOnly()
        {
            return View();
        }

        [SessionCheckFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index");
        }
    }
}
