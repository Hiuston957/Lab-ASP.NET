using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class AppDbContext: DbContext
    {
        public DbSet<AlbumEntity> Albums { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"data source=d:\contacts.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AlbumEntity>()
            .HasKey(e => e.Id);
            modelBuilder.Entity<AlbumEntity>()

                .HasData(
                new AlbumEntity()
                {
                    Id = 5,
                    Nazwa = "Nazwa"


                },
                 new AlbumEntity()
                 {
                     Id = 6,
                     Nazwa = "Nazwa2"


                 }


                ) ;
        }

       //  {1, new Album() { Id = 1,Nazwa = "Nazwa1",Zespol = "Autor1",Spis_piosenek = new List<string> { "m1", "m2", "m3" },Notowanie = 12,Czas_trwania = new List<TimeSpan> { new TimeSpan(12, 4, 13), new TimeSpan(0, 03, 39), new TimeSpan(0, 01, 11) } , Data_wydania = new DateTime(2023, 11, 11)}
    ///
       /////     {2, new Album() { Id = 2,Nazwa = "Nazwa2",Zespol = "Autor2",Spis_piosenek = new List<string> { "muzyka1" }, Notowanie = 234,Czas_trwania = new List<TimeSpan> { new TimeSpan(33, 55, 24) } , Data_wydania = new DateTime(2022, 12, 12)}
//
     


    }
}
