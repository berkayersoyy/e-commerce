using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ECommerce.WebApp.Core.Common;
using ECommerce.WebApp.Core.ResultModels;
using ECommerce.WebApp.UI.ViewModels;
using Newtonsoft.Json;

namespace ECommerce.WebApp.UI.Clients
{
    public class ProductClient
    {
        private readonly HttpClient _client;

        public ProductClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(CommonInfo.BaseAddress);
        }

        public async Task<DataResult<List<ProductViewModel>>> GetProducts()
        {
            var response = await _client.GetAsync("/Product");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProductViewModel>>(responseData);
                if (result.Any())
                {
                    return new DataResult<List<ProductViewModel>>(true, ResultConstants.RecordFound, result);
                }

                return new DataResult<List<ProductViewModel>>(false, ResultConstants.RecordNotFound);
            }
            return new DataResult<List<ProductViewModel>>(false, ResultConstants.RecordNotFound);
        }
    }
}