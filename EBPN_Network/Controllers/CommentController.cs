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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string requestId, string commentText)
    {
        if (!string.IsNullOrEmpty(commentText))
        {
            var comment = new Comment
            {
                RequestID = requestId,
                Text = commentText,
                CreatedDate = DateTime.Now
            };
            await _commentDAO.Create(comment);
        }
        return RedirectToAction("Details", "OutreachRequest", new { id = requestId });
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
