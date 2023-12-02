using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04WeatherForecastAPI.Client.Models;
using P06Shop.Shared.MessageBox;
using P12MAUI.Client;
using P12MAUI.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using P06.Shared.Services.BookService;
using P06.Shared.Books;


namespace P04WeatherForecastAPI.Client.ViewModels
{
   
 public partial class BookViewModel : ObservableObject
    {
        private readonly IBookService _productService;
        private readonly BookDetailsView _productDetailsView;
        private readonly IMessageDialogService _messageDialogService;
        private readonly IConnectivity _connectivity;
        public ObservableCollection<Book> Products { get; set; }

        [ObservableProperty]
        private Book selectedProduct;

        public BookViewModel(IBookService productService, BookDetailsView productDetailsView, IMessageDialogService messageDialogService,
            IConnectivity connectivity)
        {
            _messageDialogService = messageDialogService;
            _productDetailsView = productDetailsView;
            _productService = productService;
            _connectivity = connectivity; // set the _connectivity field
            Products = new ObservableCollection<Book>();
            GetProducts();
        }

        public async Task GetProducts()
        {
            Products.Clear();
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _messageDialogService.ShowMessage("Internet not available!");
                return;
            }

            var productsResult = await _productService.ReadBooksAsync();
            if (productsResult.Success)
            {
                foreach (var p in productsResult.Data)
                {
                    Products.Add(p);
                }
            }
            else
            {
                _messageDialogService.ShowMessage(productsResult.Message);
            }
        }

        [RelayCommand]
        public async Task ShowDetails(Book product)
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _messageDialogService.ShowMessage("Internet not available!");
                return;
            }

            await Shell.Current.GoToAsync(nameof(BookDetailsView), true, new Dictionary<string, object>
            {
                {"Product", product },
                {nameof(BookViewModel), this }
            });
            SelectedProduct = product;
        }

        [RelayCommand]
        public async Task New()
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _messageDialogService.ShowMessage("Internet not available!");
                return;
            }

            SelectedProduct = new Book();
            await Shell.Current.GoToAsync(nameof(BookDetailsView), true, new Dictionary<string, object>
            {
                {"Book", SelectedProduct },
                {nameof(BookViewModel), this }
            });
        }

    }
}
