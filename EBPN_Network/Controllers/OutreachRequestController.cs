using Amazon.Runtime.Internal;
using EBPN_Network.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;

public class OutreachRequestController : Controller
{
    private readonly OutreachRequestDAO _requestDAO;

    public OutreachRequestController()
    {
        _requestDAO = new OutreachRequestDAO();
    }

    // GET: OutreachRequest/Index
    public async Task<IActionResult> Index()
    {
        var requests = await _requestDAO.GetAll();
        return View(requests);
    }

    // GET: OutreachRequest/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: OutreachRequest/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OutreachRequest request)
    {
        OutreachRequest newRequest = new OutreachRequest(
            request.UserID,
            request.Title,
            request.Description,
            "English",
            "United States of America",
            false,
            DateTime.Now,
            DateTime.Now,
            "asdfasdf",
            "asdfasdf",
            "asdfasdf",
            false,
            false
        );

        await _requestDAO.Create(newRequest);
            return RedirectToAction("Index");
        return View(request);
    }

    // GET: OutreachRequest/Details/5
    public async Task<IActionResult> Details(string id)
    {
        OutreachRequest request = _requestDAO.GetById(id);

        if (request == null)
        {
            return NotFound();
        }
        return View(request);
    }

    // GET: OutreachRequest/Edit/5
    public IActionResult Edit(string id)
    {
        var request = _requestDAO.GetById(id);
        if (request == null)
        {
            return NotFound();
        }
        return View(request);
    }

    [HttpGet("api/requests")] // Define the route for the API endpoint
    public async Task<IActionResult> GetAllJSON()
    {
        try
        {
            var requests = await _requestDAO.GetAll();
            return Ok(requests); // Automatically serializes the data to JSON
        }
        catch (Exception ex)
        {
            // Log exception
            return StatusCode(500, "Internal server error");
        }
    }

    // POST: OutreachRequest/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(string id, OutreachRequest updatedRequest)
    {
        if (id != updatedRequest.RequestID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _requestDAO.Update(id, updatedRequest);
            return RedirectToAction("Index");
        }
        return View(updatedRequest);
    }

    // GET: OutreachRequest/Delete/5
    public IActionResult Delete(string id)
    {
        var request = _requestDAO.GetById(id);
        if (request == null)
        {
            return NotFound();
        }
        return View(request);
    }

    // POST: OutreachRequest/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(string id)
    {
        _requestDAO.Delete(id);
        return RedirectToAction("Index");
    }
}
