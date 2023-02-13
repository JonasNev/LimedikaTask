using LimedikaTask.Data;
using LimedikaTask.Models;
using LimedikaTask.Repository;
using LimedikaTask.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace LimedikaTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClientRepository _clientRepository;

        public HomeController(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IActionResult Index()
        {
            return View(_clientRepository.GetAll());
        }
        public IActionResult ImportClients()
        {
            JsonReader jsonService = new JsonReader();
            var clientList = jsonService.ReadJson();
            _clientRepository.UpdateList(clientList);
            return View("~/Views/Home/Index.cshtml", _clientRepository.GetAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}