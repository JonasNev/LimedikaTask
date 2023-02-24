using LimedikaTask.Data;
using LimedikaTask.Models;
using LimedikaTask.Models.ViewModels;
using LimedikaTask.Repository;
using LimedikaTask.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace LimedikaTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IJsonReader _jsonReader;

        public HomeController(IClientRepository clientRepository, IJsonReader jsonReader)
        {
            _clientRepository = clientRepository;
            _jsonReader = jsonReader;
        }

        public IActionResult Index()
        {
            return View(_clientRepository.GetAll());
        }

        public IActionResult ImportClients()
        {
            var clientList = _jsonReader.ReadJson();
            if (clientList != null)
            {
                _clientRepository.UpdateList(clientList);
            }
            return View("~/Views/Home/Index.cshtml", _clientRepository.GetAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}