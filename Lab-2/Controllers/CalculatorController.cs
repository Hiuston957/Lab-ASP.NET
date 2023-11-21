using Labolatorium2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Labolatorium2.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Form()
        {
            return View();
        }
        public IActionResult Result(Calculator model)
        {
          if (!model.IsValid())
            {
                return BadRequest();
            }
          return View(model);
        }
    }
}
