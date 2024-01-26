using Laboratorium3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
     

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if(ModelState.IsValid) // nie ma jawnego powiązania ale sprawdza czy model istenieje
            {
                _contactService.Add(model);
                // zapamietaj kontakt

                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contactService.FindById(id));
        }
        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if(ModelState.IsValid)
            {
                _contactService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_contactService.FindById(id));
        }
        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            if (ModelState.IsValid) 
            {
                _contactService.DeleteById(model);
                // zapamietaj kontakt

                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_contactService.FindById(id));
        }
        [HttpPost]
        public IActionResult Details(Contact model)
        {
            if (ModelState.IsValid) // nie ma jawnego powiązania ale sprawdza czy model istenieje
            {
                

                return RedirectToAction("Index");
            }
            return View();

        }










    }





}
