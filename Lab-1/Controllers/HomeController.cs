using Laboratorium.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laboratorium.Controllers
{
    public enum Operators
    {
        ADD, SUB, MUL, DIV, POT
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Calculator(Operators op, double? a, double? b) //? kolo zmiennej sluzy do sprawdzenia czy wartosc jest nullem
        {
            // string op = Request.Query["op"];

            //ViewData["op"] = op; to samo ^^
            // string a=Request.Query["a"];
            // Double.Parse(a); zle bo moze powodowac bledy, dlatego w () funkcji
            // string b = Request.Query["b"];
            // Double.Parse(b);
            if (a == null || b == null || op == null)
            {
                return View("Error");
                
            }

            switch (op)
            {
                case Operators.ADD: ViewBag.op = a + b; break;
                case Operators.DIV: ViewBag.op = a / b; break;
                case Operators.MUL: ViewBag.op = a * b; break;
                case Operators.SUB: ViewBag.op = a - b; break;
                case Operators.POT:
                    double? suma = 1;
                    if (b == 0) ViewBag.op = 1;
                    else
                    {
                        for (int i = 0; i < b; i++)
                        {
                            suma = suma*a;

                        }
                    }
                
                    ViewBag.op = suma; break;
            }
                
                return View();
           


            }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}