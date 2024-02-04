using Laboratorium3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Laboratorium3.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumApiController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumApiController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var albums = _albumService.FindAll();
            return Ok(albums);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var album = _albumService.FindById(id);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Album model)
        {
            if (ModelState.IsValid)
            {
                _albumService.Add(model);
                return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Album model)
        {
            if (id != model.Id)
            {
                return BadRequest("Mismatched album id in the request body.");
            }

            if (ModelState.IsValid)
            {
                var existingAlbum = _albumService.FindById(id);

                if (existingAlbum == null)
                {
                    return NotFound();
                }

                _albumService.Update(model);
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var album = _albumService.FindById(id);

            if (album == null)
            {
                return NotFound();
            }

            _albumService.DeleteById(album);
            return NoContent();
        }

        [HttpGet("startwith/{letter}")]
        public IActionResult GetByStartingLetter(char letter)
        {
            var filteredAlbums = _albumService.FindAll()
                .Where(a => a.Nazwa.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Ok(filteredAlbums);
        }

        [HttpGet("top")]
        public IActionResult GetTopAlbum()
        {
            var topAlbum = _albumService.FindAll()
                .OrderBy(a => a.Notowanie)
                .FirstOrDefault();

            if (topAlbum == null)
            {
                return NotFound();
            }

            return Ok(topAlbum);
        }


    }
}
