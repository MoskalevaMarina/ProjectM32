using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectM32.Models;
using ProjectM32.Models.Db;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectM32.Controllers
{
    public class HomeController : Controller
    {
       
        // ссылка на репозиторий
        private readonly BlogRepository _repo;
        private readonly LogRepository _repo1;
        private readonly ILogger<HomeController> _logger;

        // Также добавим инициализацию в конструктор
        public HomeController(ILogger<HomeController> logger, BlogRepository repo, LogRepository repo1)
        {
            _logger = logger;
            _repo = repo;
            _repo1 = repo1;
        }

        // Сделаем метод асинхронным
        public async Task<IActionResult> Index()
        {
           
            return View();
        }

        public async Task<IActionResult> Logs()
        {
            var logs = await _repo1.GetRequests();
            return View(logs);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
