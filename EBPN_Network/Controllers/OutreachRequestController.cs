using Microsoft.AspNetCore.Mvc;
using EBPN_Network.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EBPN_Network.Controllers
{
    public class OutreachRequestController : Controller
    {
        private readonly OutreachRequestDAO _outreachRequestDao;

        public OutreachRequestController(OutreachRequestDAO outreachRequestDao)
        {
            _outreachRequestDao = outreachRequestDao;
        }

        public async Task<IActionResult> Index()
        {
            // Get all outreach requests
            var requests = await _outreachRequestDao.GetAll();
            return View(requests);
        }

        [HttpGet("api/requests")] // Define the route for the API endpoint
        public async Task<IActionResult> GetAllJSON()
        {
            try
            {
                var requests = await _outreachRequestDao.GetAll();
                return Ok(requests); // Automatically serializes the data to JSON
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: /OutreachRequest/Create
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /OutreachRequest/Create
        [HttpPost]
        public async Task<IActionResult> Create(OutreachRequest request)
        {
           
                await _outreachRequestDao.Create(request);
                return RedirectToAction("Index");
            
        }

        // GET: /OutreachRequest/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var request = _outreachRequestDao.GetById(id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }

        // POST: /OutreachRequest/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(string id, OutreachRequest request)
        {
            if (id != request.RequestID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _outreachRequestDao.Update(id, request);
                return RedirectToAction("Index");
            }
            return View(request);
        }

        // POST: /OutreachRequest/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            _outreachRequestDao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
