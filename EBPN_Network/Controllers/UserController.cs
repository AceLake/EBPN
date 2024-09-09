using EBPN_Network.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class UserController : Controller
{
    // Here
    private readonly UserDAO _userDAO;

    public UserController()
    {
        _userDAO = new UserDAO();
    }

    // GET: User/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: User/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(User user)
    {
        if (ModelState.IsValid)
        {
            await _userDAO.Create(user);
            return RedirectToAction("Login");
        }
        return View(user);
    }

    // GET: User/Login
    public IActionResult Login()
    {
        return View();
    }

    // POST: User/Login
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var user = _userDAO.GetByEmailAndPassword(email, password);
        if (user == null)
        {
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        // Handle login logic here, e.g., setting session or cookie
        return RedirectToAction("UserDashboard");
    }

    // GET: User/EditProfile
    public IActionResult EditProfile(string id)
    {
        var user = _userDAO.GetById(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    // POST: User/EditProfile
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditProfile(string id, User updatedUser)
    {
        if (id != updatedUser.UserID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _userDAO.Update(id, updatedUser);
            return RedirectToAction("UserDashboard");
        }
        return View(updatedUser);
    }

    // GET: User/UserDashboard
    public IActionResult UserDashboard()
    {
        // Implement user-specific dashboard logic here
        return View();
    }
}
