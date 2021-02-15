using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace VamosLaOnibus.Business
{
    public class DataService
    {

        HttpClient client = new HttpClient();
        public async Task<Models.TripResults> GetTripAsync()
        {
            try
            {
                string url = "https://4jehkg0izj.execute-api.us-east-1.amazonaws.com/stage-v0/route";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<Models.TripResults>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
