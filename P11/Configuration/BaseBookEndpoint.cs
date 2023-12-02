using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Configuration
{
    internal class BaseBookEndpoint
    {
        public string Base_url { get; set; }
        public string AddBookAsync { get; set; }
        public string DeleteBookAsync { get; set; }
        public string GetBooksAsync { get; set; }
        public string UpdateBookAsync { get; set; }

    }
}
