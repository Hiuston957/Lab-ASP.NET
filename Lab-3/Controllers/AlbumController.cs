using Laboratorium3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium3.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;


        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        public IActionResult Index()
        {
            return View(_albumService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Album model)
        {
            if (ModelState.IsValid) // nie ma jawnego powiązania ale sprawdza czy model istenieje
            {
                _albumService.Add(model);
                // zapamietaj kontakt

                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_albumService.FindById(id));
        }
        [HttpPost]
        public IActionResult Details(Album model)
        {
            if (ModelState.IsValid)
            {


                return RedirectToAction("Index");
            }
            return View();

        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_albumService.FindById(id));
        }
        [HttpPost]
        public IActionResult Update(Album model)
        {
            if (ModelState.IsValid)
            {
                _albumService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_albumService.FindById(id));
        }
        [HttpPost]
        public IActionResult Delete(Album model)
        {
            var albumToDelete = _albumService.FindById(model.Id);

            if (albumToDelete != null)
            {
                _albumService.DeleteById(albumToDelete);
                return RedirectToAction("Index");
            }

            return NotFound(); 

        }


    }
}
