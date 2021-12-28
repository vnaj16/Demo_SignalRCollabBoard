using Demo_SignalRCollabBoard.Hubs;
using Demo_SignalRCollabBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_SignalRCollabBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHubContext<PositionHub> positionHubContext; //https://docs.microsoft.com/en-us/aspnet/core/signalr/background-services?view=aspnetcore-6.0

        public HomeController(ILogger<HomeController> logger, IHubContext<PositionHub> positionHubContext)
        {
            _logger = logger;
            this.positionHubContext = positionHubContext;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Position()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Position(PositionDiv positionDiv)
        {
            positionHubContext.Clients.All.SendAsync("ReceivePosition", positionDiv.Left, positionDiv.Top);
            return View();
        }

        //TODO probar un form que le pase las coordenados, llame la funcion y actualice la posicion del Div
    }
}
