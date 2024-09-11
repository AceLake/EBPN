using EBPN_Network.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class CommentController : Controller
{
    private readonly CommentDAO _commentDAO;

    public CommentController()
    {
        _commentDAO = new CommentDAO();
    }

    // POST: Comment/Create
    [HttpPost]
    public IActionResult Create(Comment model)
    {

            // Save the comment to the database
            _commentDAO.Create(model);

            // Redirect back to the details page
            return RedirectToAction("Details", "OutreachRequest", new { id = model.RequestID });
        

        // If the model state is not valid, re-render the form with validation errors
        //return View(model);
    }

    // GET: Comment/Delete/5
    public IActionResult Delete(string id)
    {
        var comment = _commentDAO.GetById(id);
        if (comment == null)
        {
            return NotFound();
        }
        return View(comment);
    }

    // POST: Comment/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(string id)
    {
        var comment = _commentDAO.GetById(id);
        if (comment == null)
        {
            return NotFound();
        }
        _commentDAO.Delete(id);
        return RedirectToAction("Details", "OutreachRequest", new { id = comment.RequestID });
    }
}
