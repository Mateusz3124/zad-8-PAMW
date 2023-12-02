using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services.WeatherServices;
using P06.Shared.Services.BookService;
using P06.Shared.Books;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class BookViewModel : ObservableObject
    {
        private readonly IBookService _bookService;

        public ObservableCollection<Book> visibleBooks { get; set; }
        private int page;
        private int current;
        private List<List<Book>> books;
        private readonly IServiceProvider _serviceProvider;

        [ObservableProperty]
        private string shownPage;

        [ObservableProperty]
        private string id;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string author;

        public BookViewModel(IBookService bookService, IServiceProvider serviceProvider)
        {
            _bookService = bookService;
            _serviceProvider = serviceProvider;
            visibleBooks = new ObservableCollection<Book>();
            books = new List<List<Book>>();
            page = 0;
            current = 0;
            shownPage = "0";
        }

        public async void GetProducts()
        {
            visibleBooks.Clear();
            books.Clear();
            page = 0;
            ShownPage = "0";
            current = 0;
            var BookResult = await _bookService.ReadBooksAsync();
            int count = 0;
            books.Add(new List<Book>());
            if (BookResult.Success)
            {
                foreach (var p in BookResult.Data)
                {
                    count++;
                    if (count == 5)
                    {
                        count = 1;
                        page++;
                        books.Add(new List<Book>());
                    }
                    books[page].Add(p);
                }
            }
            page++;
            foreach (Book b in books[0])
            {
                visibleBooks.Add(b);
            }
        }

        [RelayCommand]
        public void reloadRight()
        {
            visibleBooks.Clear();
            current++;
            if (current > page -1)
            {
                current = 0;
            }
            foreach (Book b in books[Math.Abs(current%page)])
            {
                visibleBooks.Add(b);
            }
            ShownPage = current.ToString();
        }
        [RelayCommand]
        public void reloadLeft()
        {
            visibleBooks.Clear();
            current--;
            if(current < 0)
            {
                current = page - 1;
            }
            foreach (Book b in books[Math.Abs(current % page)])
            {
                visibleBooks.Add(b);
            }
            ShownPage = current.ToString();
        }

        [RelayCommand]
        public void LoaderOfDetails()
        {
            DetailsBook detailBookView = _serviceProvider.GetService<DetailsBook>();
            detailBookView.Show();
        }

        [RelayCommand]
        public async void create()
        {
            int idBook = int.Parse(Id);
            Book test = new Book()
            {
                Id = idBook,
                Title = this.Title,
                Author = this.Author,
            };
            var BookResult = await _bookService.CreateBookAsync(test);
            GetProducts();
        }
        [RelayCommand]
        public async void remove()
        {
            int idBook = int.Parse(Id);
            var BookResult = await _bookService.DeleteBookAsync(idBook);
            GetProducts();
        }
        [RelayCommand]
        public async void update()
        {
            int idBook = int.Parse(Id);
            Book test = new Book()
            {
                Id = idBook,
                Title = this.Title,
                Author = this.Author,
            };
            var BookResult = await _bookService.UpdateBookAsync(test);
            GetProducts();
        }

    }
}
