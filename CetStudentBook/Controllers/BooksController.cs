using System.Threading.Tasks;
using CetStudentBook.Data;
using CetStudentBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CetStudentBook.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Books
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.AsNoTracking().ToListAsync();
            return View(books);
        }

        // GET: /Books/Create
        public IActionResult Create()
        {
            return View(new Book());
        }

        // POST: /Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books.FindAsync(id.Value);
            if (book == null) return NotFound();

            return View(book);
        }

        // POST: /Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id) return NotFound();

            if (!ModelState.IsValid)
                return View(book);

            try
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var exists = await _context.Books.AnyAsync(b => b.Id == id);
                if (!exists) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id.Value);
            if (book == null) return NotFound();

            return View(book);
        }

        // POST: /Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}