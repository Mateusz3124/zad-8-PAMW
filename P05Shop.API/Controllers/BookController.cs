using Microsoft.AspNetCore.Mvc;
using P04WeatherForecastAPI.Client.Models;
using P06.Shared;
using P06.Shared.Services.BookService;
using P06.Shared.Books;
using Microsoft.AspNetCore.Authorization;

namespace P05Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService BookService)
        {
            _bookService = BookService;
        }
            
        [HttpGet("ReadBooks"), Authorize]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooks()
        {
            var result = await _bookService.ReadBooksAsync();

            if (result.Success)
                return Ok(result);
            else
                return  StatusCode(result.CodeError, $"{result.Message}");
        }

        [HttpPost("createBook")] 
        public async Task<ActionResult<ServiceResponse<List<Book>>>> AddBook([FromBody] Book book)
        {
            var result = await _bookService.CreateBookAsync(book);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(result.CodeError, $"{result.Message}");
        }
  
        [HttpDelete("DeleteBook/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> DeleteBook([FromRoute] int id)
        {
            var result = await _bookService.DeleteBookAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(result.CodeError, $"{result.Message}");
        }

        [HttpPut("UpdateBook")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> UpdateBook([FromBody] Book book)
        {
            var result = await _bookService.UpdateBookAsync(book);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(result.CodeError, $"{result.Message}");
        }


    }
}
