using EBPN_Network.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        if (ModelState.IsValid)
        {
            await _requestDAO.Create(request);
            return RedirectToAction("Index");
        }
        return View(request);
    }

    // GET: OutreachRequest/Details/5
    public IActionResult Details(string id)
    {
        var request = _requestDAO.GetById(id);
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
