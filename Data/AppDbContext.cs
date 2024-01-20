using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    //internal class AppDbContext: DbContext
    //  {
    // public DbSet<AlbumEntity> Albums { get; set; }


    internal class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() { Id = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = "127813268163", Birth = new DateTime(2000, 10, 10) },
                new ContactEntity() { Id = 2, Name = "Ewa", Email = "ewa@wsei.edu.pl", Phone = "293443823478", Birth = new DateTime(1999, 8, 10) }
            );
        }
    }

    //  {1, new Album() { Id = 1,Nazwa = "Nazwa1",Zespol = "Autor1",Spis_piosenek = new List<string> { "m1", "m2", "m3" },Notowanie = 12,Czas_trwania = new List<TimeSpan> { new TimeSpan(12, 4, 13), new TimeSpan(0, 03, 39), new TimeSpan(0, 01, 11) } , Data_wydania = new DateTime(2023, 11, 11)}
    ///
    /////     {2, new Album() { Id = 2,Nazwa = "Nazwa2",Zespol = "Autor2",Spis_piosenek = new List<string> { "muzyka1" }, Notowanie = 234,Czas_trwania = new List<TimeSpan> { new TimeSpan(33, 55, 24) } , Data_wydania = new DateTime(2022, 12, 12)}
    //



    //}
}
