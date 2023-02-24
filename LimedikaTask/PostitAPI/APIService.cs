using LimedikaTask.Models.JsonModels;
using LimedikaTask.Repository;
using LimedikaTask.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimedikaTask.PostitAPI
{
    public class ApiService : IApiService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IStringFormatting _stringFormatting;
        private IConfiguration _configuration { get; }
        public ApiService(IClientRepository clientRepository, IConfiguration configuration, IStringFormatting stringFormatting)
        {
            _clientRepository = clientRepository;
            _configuration = configuration;
            _stringFormatting = stringFormatting;
        }

        private string? _apiKey => _configuration[Constants.Clients.PostitApiKeySecretName];
        public async Task UpdatePostalCodes()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var pharmacy in _clientRepository.GetAll())
                {
                    if (!string.IsNullOrEmpty(pharmacy.Address) && !string.IsNullOrEmpty(_apiKey))
                    {
                        var apiQuery = _stringFormatting.CreateQuery(pharmacy.Address, _apiKey, _configuration.GetValue<string>(Constants.Clients.BaseUrlConfigurationName));
                        HttpResponseMessage Res = await client.GetAsync(apiQuery);
                        if (Res.IsSuccessStatusCode)
                        {
                            var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                            var postItResponse = JsonConvert.DeserializeObject<PostitApiModel.Rootobject>(EmpResponse);
                            var pharmacyToUpdate = _clientRepository.GetByAdress(pharmacy.Address);
                            if (pharmacyToUpdate != null)
                            {
                                pharmacyToUpdate.PostCode = postItResponse?.Data?.First().Post_code;
                                _clientRepository.Update(pharmacyToUpdate);
                            }
                        }
                    }
                }

            }
        }
    }
}
