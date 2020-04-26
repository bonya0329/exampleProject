using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using exampleProject.Data;
using exampleProject.Models;

namespace exampleProject.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly MyDBContext _context;

        public AuthorsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Author.ToListAsync());
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Author
                .FirstOrDefaultAsync(m => m.AuthorID == id);
            if (author == null)
            {
                return NotFound();
            }

            var Results = from b in _context.Book
                          select new
                          {
                              b.BookID,
                              b.Title,
                              Checked = (from ab in _context.AuthorToBook
                                         where (ab.AuthorID == id) & (ab.BookID == b.BookID)
                                         select ab).Count() > 0
                          };
            var MyViewModel = new AuthorsViewModel();
            MyViewModel.AuthorID = id.Value;
            MyViewModel.Name = author.Name;
            MyViewModel.SurName = author.SurName;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { ID = item.BookID, Name = item.Title, Checked = item.Checked });
            }
            MyViewModel.Books = MyCheckBoxList;
            return View(MyViewModel);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorID,Name,SurName")] Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Author.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            var Results = from b in _context.Book
                          select new
                          {
                              b.BookID,
                              b.Title,
                              Checked = (from ab in _context.AuthorToBook
                                          where (ab.AuthorID == id) & (ab.BookID == b.BookID)
                                          select ab).Count() > 0
                          };
            var MyViewModel = new AuthorsViewModel();
            MyViewModel.AuthorID = id.Value;
            MyViewModel.Name = author.Name;
            MyViewModel.SurName = author.SurName;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { ID = item.BookID, Name = item.Title, Checked = item.Checked });
            }
            MyViewModel.Books = MyCheckBoxList;
            return View(MyViewModel);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AuthorsViewModel author)
        {
            /*if (id != author.AuthorID)
            {
                return NotFound();
            }*/

            if (ModelState.IsValid)
            {

                try
                {
                    var MyAuthor = _context.Author.Find(author.AuthorID);
                    MyAuthor.Name = author.Name;
                    MyAuthor.SurName = author.SurName;

                    foreach (var item in _context.AuthorToBook)
                    {
                        if(item.AuthorID == author.AuthorID)
                        {
                            _context.Remove(item);
                        }
                    }
                    foreach (var item in author.Books)
                    {
                        if (item.Checked)
                        {
                            _context.AuthorToBook.Add(new AuthorToBook() { AuthorID = author.AuthorID, BookID = item.ID });
                        }

                    }
                    //_context.Update(author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.AuthorID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Author
                .FirstOrDefaultAsync(m => m.AuthorID == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _context.Author.FindAsync(id);
            _context.Author.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            return _context.Author.Any(e => e.AuthorID == id);
        }
    }
}
