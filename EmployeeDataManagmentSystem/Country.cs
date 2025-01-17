using Newtonsoft.Json;
using RestSharp;

namespace EmployeeDataManagmentSystem
{
    public class Country
    {
        public Name Name { get; set; }

        public void FetchCountryList()
        {
            var client = new RestClient("https://restcountries.com/v3.1/all?fields=name");
            RestRequest request = new RestRequest();
            RestResponse response = client.Execute(request);
        }
    }

    public class Name
    {
        [JsonProperty("common")]
        public string CountryCommonName { get; set; }

        [JsonProperty("official")]
        public string CountryOfficialName { get; set; }

        [JsonProperty("nativeName")]
        public NativeName CountryNativeName { get; set; }
    }

    public class NativeName
    {
        [JsonProperty("eng")]
        public EnglishName CountryNativeName { get; set; }
    }

    public class EnglishName
    {
        [JsonProperty("official")]
        public string CountryEnglishOfficialName { get; private set; }

        [JsonProperty("common")]
        public string CountryEnglishCommonName { get; private set; }
    }
}
