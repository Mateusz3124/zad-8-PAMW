using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using P06.Shared.Services.BookService;
using P04WeatherForecastAPI.Client.ViewModels;
using P06Shop.Shared.MessageBox;
using P06.Shared.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P12MAUI.Client.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    [QueryProperty(nameof(Title), nameof(Title))]
    [QueryProperty(nameof(Author), nameof(Author))]
    [QueryProperty(nameof(BookViewModel), nameof(BookViewModel))]
    public partial class BookDetailsViewModel : ObservableObject
    {
        private readonly IBookService _productService;
        private readonly IMessageDialogService _messageDialogService;
        private BookViewModel _productViewModel;

        public BookDetailsViewModel(IBookService productService, IMessageDialogService messageDialogService, IGeolocation geolocation, IMap map)
        {
            _productService = productService;
            _messageDialogService = messageDialogService;

            
        }


        public BookViewModel BookViewModel
        {
            get
            {
                return _productViewModel;
            }
            set
            {
                _productViewModel = value;
            }
        }


        [ObservableProperty]
        private string id;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string author;

        Book product;

        public async Task DeleteProduct()
        {
            await _productService.DeleteBookAsync(product.Id);
            await _productViewModel.GetProducts();
        }

        public async Task CreateProduct()
        {

            var result = await _productService.CreateBookAsync(product);
            if (result.Success)
                await _productViewModel.GetProducts();
            else
                _messageDialogService.ShowMessage(result.Message);
        }

        public async Task UpdateProduct()
        {
            await _productService.UpdateBookAsync(product);
            await _productViewModel.GetProducts();
        }


        [RelayCommand]
        public async Task Save()
        {
            int idBook = int.Parse(Id);
            product = new Book()
            {
                Id = idBook,
                Title = this.Title,
                Author = this.Author,
            };
            var productsResult = await _productService.ReadBooksAsync();
            foreach(Book item in productsResult.Data)
            {
                if(item.Id == idBook)
                {
                    UpdateProduct();
                    await Shell.Current.GoToAsync("../", true);
                }
            }
            CreateProduct();
            await Shell.Current.GoToAsync("../", true);
        }

        [RelayCommand]
        public async Task Delete()
        {
            int idBook = int.Parse(Id);
            product = new Book()
            {
                Id = idBook,
                Title = this.Title,
                Author = this.Author,
            };
            DeleteProduct();
            await Shell.Current.GoToAsync("../", true);
        }
    }
}
