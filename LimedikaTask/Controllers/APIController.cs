using LimedikaTask.Models;
using LimedikaTask.PostitAPI;
using LimedikaTask.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Web.Http;

namespace LimedikaTask.Controllers
{
    public class APIController : Controller
    {
        private readonly ClientRepository _clientRepository;
        public IConfiguration _configuration { get; }
        public APIController(ClientRepository clientRepository, IConfiguration configuration)
        {
            _clientRepository = clientRepository;
            _configuration = configuration;
        }

        public async Task<ActionResult> UpdatePostCode()
        {
            APIService ApiService = new APIService(_clientRepository, _configuration);
            await ApiService.UpdatePostalCodes();
            return View("~/Views/Home/Index.cshtml", _clientRepository.GetAll());
        }
    }
}
