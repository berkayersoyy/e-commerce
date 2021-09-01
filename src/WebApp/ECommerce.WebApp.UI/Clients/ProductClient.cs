using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<DataResult<ProductViewModel>> CreateProduct(ProductViewModel model)
        {
            var dataAsString = JsonConvert.SerializeObject(model);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync("/Product", content);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductViewModel>(responseData);
                if (result!=null)
                {
                    return new DataResult<ProductViewModel>(true, ResultConstants.RecordCreateSuccessfully, result);
                }
                return new DataResult<ProductViewModel>(false, ResultConstants.RecordCreateNotSuccessfully);
            }
            return new DataResult<ProductViewModel>(false, ResultConstants.RecordCreateNotSuccessfully);
        }
        public async Task<DataResult<ProductViewModel>> UpdateProduct(ProductViewModel model)
        {
            var dataAsString = JsonConvert.SerializeObject(model);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync("/Product", content);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductViewModel>(responseData);
                if (result!=null)
                {
                    return new DataResult<ProductViewModel>(true, ResultConstants.RecordUpdateSuccessfully, result);
                }
                return new DataResult<ProductViewModel>(false, ResultConstants.RecordUpdateNotSuccessfully);
            }
            return new DataResult<ProductViewModel>(false, ResultConstants.RecordUpdateNotSuccessfully);
        }    
        public async Task<DataResult<ProductViewModel>> GetProduct(string id)
        {
            var response = await _client.GetAsync("/Product/" + id);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductViewModel>(responseData);
                if (result!=null)
                {
                    return new DataResult<ProductViewModel>(true, ResultConstants.RecordFound, result);
                }
                return new DataResult<ProductViewModel>(false, ResultConstants.RecordNotFound);
            }
            return new DataResult<ProductViewModel>(false, ResultConstants.RecordNotFound);
        }
        public async Task<DataResult<bool>> DeleteProduct(string id)
        {
            var response = await _client.DeleteAsync("/Product/" + id);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductViewModel>(responseData);
                if (result != null)
                {
                    return new DataResult<bool>(true, ResultConstants.RecordDeleteSuccessfully, true);
                }
                return new DataResult<bool>(false, ResultConstants.RecordDeleteNotSuccessfully, false);
            }
            return new DataResult<bool>(false, ResultConstants.RecordDeleteNotSuccessfully, false);
        }

        public async Task<DataResult<List<ProductViewModel>>> GetProductsByName(string name)
        {
            var response = await _client.GetAsync("/Product/GetProductsByName/" + name);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProductViewModel>>(responseData);
                if (result!=null)
                {
                    return new DataResult<List<ProductViewModel>>(true, ResultConstants.RecordFound, result);
                }
                return new DataResult<List<ProductViewModel>>(false, ResultConstants.RecordNotFound);
            }
            return new DataResult<List<ProductViewModel>>(false, ResultConstants.RecordNotFound);
        }
        public async Task<DataResult<List<ProductViewModel>>> GetProductsByCategory(string categoryName)
        {
            var response = await _client.GetAsync("/Product/GetProductsByCategory/" + categoryName);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProductViewModel>>(responseData);
                if (result != null)
                {
                    return new DataResult<List<ProductViewModel>>(true, ResultConstants.RecordFound, result);
                }
                return new DataResult<List<ProductViewModel>>(false, ResultConstants.RecordNotFound);
            }
            return new DataResult<List<ProductViewModel>>(false, ResultConstants.RecordNotFound);
        }
    }
}