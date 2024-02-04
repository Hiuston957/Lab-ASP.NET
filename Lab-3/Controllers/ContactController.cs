using Laboratorium3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laboratorium3.Controllers
{
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
        public ActionResult Create()
        {
            Contact model = new Contact();
            model.Organizations = _contactService
                .FindAllOrganizationsForVieModel()
                .Select(o => new SelectListItem() { Value = o.OrganizationEntityId.ToString(), Text = o.Title })
                .ToList();
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            }

            model.Organizations = _contactService
                .FindAllOrganizationsForVieModel()
                .Select(o => new SelectListItem() { Value = o.OrganizationEntityId.ToString(), Text = o.Title })
                .ToList();

            return View(model);
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
            if (ModelState.IsValid) 
            {
                

                return RedirectToAction("Index");
            }
            return View();

        }










    }





}
