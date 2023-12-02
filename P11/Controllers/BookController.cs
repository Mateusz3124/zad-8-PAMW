using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P06.Shared.Books;
using P06.Shared.Services.BookService;
using P06.Shared.Shop;

namespace Tester2.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService) {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _bookService.ReadBooksAsync();
            return products != null ?
                          View(products.Data.AsEnumerable()) :
                          Problem("Entity set 'Books'  is null.");
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author")] Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.CreateBookAsync(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _bookService.ReadBooksAsync();
            foreach (var item in products.Data)
            {
                if(item.Id == id)
                {
                    return View(item);
                }
            }
            return NotFound();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var productResult = await _bookService.UpdateBookAsync(book);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _bookService.ReadBooksAsync();
            foreach (var item in products.Data)
            {
                if (item.Id == id)
                {
                    return View(item);
                }
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _bookService.DeleteBookAsync((int)id);
            if (product.Success)
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
        }

    }
}
