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
        private readonly IClientRepository _clientRepository;
        private readonly IApiService _apiService;
        public APIController(IClientRepository clientRepository, IApiService apiService)
        {
            _clientRepository = clientRepository;
            _apiService = apiService;
        }

        public async Task<ActionResult> UpdatePostCode()
        {
            await _apiService.UpdatePostalCodes();
            return View("~/Views/Home/Index.cshtml", _clientRepository.GetAll());
        }
    }
}
