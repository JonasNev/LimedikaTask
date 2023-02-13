using LimedikaTask.Models;
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
    public class APIService
    {
        private readonly ClientRepository _clientRepository;
        public IConfiguration _configuration { get; }
        public APIService(ClientRepository clientRepository, IConfiguration configuration)
        {
            _clientRepository = clientRepository;
            _configuration = configuration;
        }
        public async Task UpdatePostalCodes()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var pharmacy in _clientRepository.GetAll())
                {
                    if (!string.IsNullOrEmpty(pharmacy.Address))
                    {
                        StringFormatting stringFormattingService = new StringFormatting();
                        var apiQuery = stringFormattingService.CreateQuery(pharmacy.Address, _configuration.GetValue<string>("ApiKey:Default"), _configuration.GetValue<string>("BaseUrl:Default"));
                        HttpResponseMessage Res = await client.GetAsync(apiQuery);
                        if (Res.IsSuccessStatusCode)
                        {
                            var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                            var postItResponse = JsonConvert.DeserializeObject<PostitAPIModel.Rootobject>(EmpResponse);
                            var pharmacyToUpdate = _clientRepository.GetByAdress(pharmacy.Address);
                            pharmacyToUpdate.PostCode = postItResponse.data[0].post_code;
                            _clientRepository.Update(pharmacyToUpdate);
                        }
                    }
                }

            }
        }
    }
}
