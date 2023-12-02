using P06.Shared.Books;

namespace P06.Shared.Services.BookService
{
    public interface IBookService
    {
        Task<ServiceResponse<List<Book>>> ReadBooksAsync();
        Task<ServiceResponse<List<Book>>> ReadBooksAsync(string token);
        Task<ServiceResponse<string>> CreateBookAsync(Book book);
        Task<ServiceResponse<string>> DeleteBookAsync(int id);
        Task<ServiceResponse<string>> UpdateBookAsync(Book book);

    }
}
