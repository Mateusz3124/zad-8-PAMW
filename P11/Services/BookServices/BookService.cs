using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Configuration;
using P06.Shared;
using P06.Shared.Books;
using P06.Shared.Services.BookService;
using P06.Shared.Shop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services.BookServices
{
    internal class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public BookService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient= httpClient;
            _appSettings= appSettings.Value;
        }

        public async Task<ServiceResponse<string>> CreateBookAsync(Book book)
        {
            JsonContent content = JsonContent.Create(book);
            var response = await _httpClient.PostAsync(_appSettings.BaseBookEndpoint.AddBookAsync, content);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<string>> (json);
            return result;
        }

        public async Task<ServiceResponse<string>> DeleteBookAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_appSettings.BaseBookEndpoint.DeleteBookAsync + "/" + id.ToString());
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<string>>(json);
            return result;
        }

        public async Task<ServiceResponse<List<Book>>> ReadBooksAsync()
        {
            var response = await _httpClient.GetAsync(_appSettings.BaseBookEndpoint.GetBooksAsync);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Book>>>(json);
            return result;
        }

        public async Task<ServiceResponse<string>> UpdateBookAsync(Book book)
        {
            JsonContent content = JsonContent.Create(book);
            var response = await _httpClient.PutAsync(_appSettings.BaseBookEndpoint.UpdateBookAsync, content);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<string>>(json);
            return result;
        }
    }
}
