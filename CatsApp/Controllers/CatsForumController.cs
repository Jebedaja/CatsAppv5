using Microsoft.AspNetCore.Mvc;
using CatsForum.Models;
using System.Linq;
using CatsApp.Data;

namespace CatsForum.Controllers
{
    public class CatsForumController : Controller   // Kontroler do obsługi forum
    {
        private readonly ApplicationDbContext _context;

        public CatsForumController(ApplicationDbContext context)    // Wstrzykiwanie DI
        {
            _context = context;
        }

        public IActionResult Comments()
        {
            var comments = _context.Comments.ToList();     // ToList () zwraca listę wszystkich komentarzy z bazy danych
            return View("Comments", comments);
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)     // Dodaj komentarz do bazy danych
        {
            if (ModelState.IsValid)    // Sprawdzenie, czy model jest poprawny
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
                return RedirectToAction("Comments");
            }

            return Comments();
        }

    }
}

