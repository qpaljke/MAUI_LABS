using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShukailaLabs.Services;
using ShukailaLabs.Entities;
using System.Text.Json.Serialization;

internal class RateService : IRateService
{
    private readonly HttpClient _httpClient;

    public RateService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://api.nbrb.by/exrates/currencies[/{cur_id}]");
    }
    public IEnumerable<Rate>GetRates(DateTime date)
    {
        HttpResponseMessage responce = _httpClient.GetAsync($"/rates?date={date.ToString("yyyy-MM-dd")}").Result;

        if(responce.IsSuccessStatusCode)
        {
            string json = responce.Content.ReadAsStringAsync().Result;
            IEnumerable<Rate> rates = JsonConvert.DeserializeObject<IEnumerable<Rate>>(json);
            return rates;
        }
        else
        {
            throw new Exception("Failed to fetch rates from the API");
        }
    }
}
