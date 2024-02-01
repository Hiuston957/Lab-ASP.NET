using Data;
using Data.Entities;
using Laboratorium3.Mappers;
using Laboratorium3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorium3.Models
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
            var entity = AlbumMapper.ToEntity(album);
            _context.Albums.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Album album)
        {
            var entity = AlbumMapper.ToEntity(album);
            _context.Albums.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteById(Album album)
        {
            var entity = AlbumMapper.ToEntity(album);
            _context.Albums.Remove(entity);
            _context.SaveChanges();
        }

        public Album? FindById(int id)
        {
            var entity = _context.Albums.Find(id);
            return entity != null ? AlbumMapper.FromEntity(entity) : null;
        }

        public List<Album> FindAll()
        {
           return _context.Albums.Select(e => AlbumMapper.FromEntity(e)).ToList();
        }
    }
}
