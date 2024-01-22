using Data;
using Data.Entities;
using Laboratorium3.Models;
using Laboratorium3.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorium3.Services
{
    public class EFAlbumService : IAlbumService
    {
        private AppDbContext _context;

        public EFAlbumService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Album album)
        {
            var e = _context.Albums.Add(AlbumMapper.ToEntity(album));
            _context.SaveChanges();
        }

        public void DeleteById(Album album)
        {
            AlbumEntity? find = _context.Albums.Find(album.Id);
            if (find != null)
            {
                _context.Albums.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Album> FindAll()
        {
            return _context.Albums.Select(e => AlbumMapper.FromEntity(e)).ToList();
        }

        public Album? FindById(int id)
        {
            return AlbumMapper.FromEntity(_context.Albums.Find(id));
        }

        public void Update(Album album)
        {
            _context.Albums.Update(AlbumMapper.ToEntity(album));
            _context.SaveChanges();
        }
    }
}
