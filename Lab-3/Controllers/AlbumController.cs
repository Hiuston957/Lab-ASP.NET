using Laboratorium3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
            if (ModelState.IsValid)
            {
                _albumService.Add(model);
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
            if (ModelState.IsValid)
            {
                _albumService.DeleteById(model);
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
                // Additional logic for details if needed
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
