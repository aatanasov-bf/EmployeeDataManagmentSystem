using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManagmentSystem.Services
{
    public class CountryService
    {
        private const string countryListApiUrl = "https://restcountries.com/v3.1/all?fields=name";

        public List<Country> FetchCountryList()
        {
            var client = new RestClient(countryListApiUrl);
            RestRequest request = new RestRequest();
            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<List<Country>>(response.Content);
            else
            {
                throw new Exception("Data was not fetched!\n");
            }
        }
    }
}
