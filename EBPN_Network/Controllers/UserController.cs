using Microsoft.AspNetCore.Mvc;
using EBPN_Network.Models;
using FirebaseAdmin.Auth;

namespace EBPN_Network.Controllers
{
    public class UserController : Controller
    {

        private readonly UserDAO _userDao;

        public UserController(UserDAO userDao)
        {
            _userDao = userDao;
        }

        // GET: /User/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /User/Register
        // Register new user
        [HttpPost]
        public async Task<IActionResult> Register(string email, string password)
        {
            try
            {
                var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(new UserRecordArgs
                {
                    Email = email,
                    Password = password
                });

                var user = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(email);

                User newUser = new User();
                newUser.Uid = user.Uid;
                newUser.Email = email;

                _userDao.Create(newUser);

                // Handle successful registration
                return RedirectToAction("Login");
            }
            catch (FirebaseAuthException ex)
            {
                // Handle registration errors
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: /User/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("auth_token");
            return RedirectToAction("Login", "User");
        }

        // POST: /User/Login
        // Login user
        [Route("User/Login")]
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                // Authenticate the user with Firebase
                var user = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(email);

                // Validate the user credentials (add password validation logic here)

                // Generate a custom token
                var customToken = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(user.Uid);

                // Send the custom token to the client
                return Json(new { token = customToken });
            }
            catch (FirebaseAuthException ex)
            {
                // Handle login errors
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
