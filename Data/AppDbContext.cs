﻿using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

        
       public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<AlbumEntity> Albums { get; set; }

       // public DbSet<AlbumSong> AlbumSongs { get; set; } // Add DbSet for AlbumSong
       // public DbSet<AlbumTimeSpan> AlbumTimeSpans { get; set; } // Add DbSet for AlbumTimeSpan



        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Mydata5.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumEntity>().HasData(
             new AlbumEntity() { Id = 1, Nazwa = "Album1", Zespol = "Band1", Spis_piosenek = "Song1, Song2", Notowanie = 1, Data_wydania = new DateTime(2022, 1, 1) },
             new AlbumEntity() { Id = 2, Nazwa = "Album2", Zespol = "Band2", Spis_piosenek = "Song3, Song4", Notowanie = 2, Data_wydania = new DateTime(2022, 2, 1) }
         );

            //modelBuilder.Entity<ContactEntity>();
            modelBuilder.Entity<AlbumEntity>();
            //  modelBuilder.Entity<AlbumSong>(); // Add configuration for AlbumSong
            //  modelBuilder.Entity<AlbumTimeSpan>(); // Add configuration for AlbumTimeSpan

            base.OnModelCreating(modelBuilder);

            // Existing code for roles and users

            // Configure relationships
            /*
            modelBuilder.Entity<AlbumSong>()
                .HasOne(song => song.Album)
                .WithMany(album => album.Songs)
                .HasForeignKey(song => song.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AlbumTimeSpan>()
                .HasOne(span => span.Album)
                .WithMany(album => album.Czas_trwania)
                .HasForeignKey(span => span.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);

            */









            base.OnModelCreating(modelBuilder);

            // Dodanie roli administratora
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            });

            // Utworzenie administratora jako użytkownika
            string ADMIN_ID = Guid.NewGuid().ToString();
            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adam@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "adam",
                NormalizedUserName = "ADMIN"
            };

            // Haszowanie hasła
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");

            // Zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(admin);

            // Przypisanie roli administratora użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });

            // Dodanie roli użytkownika
            string USER_ROLE_ID = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            });

            // Utworzenie użytkownika z rolą USER
            string USER_ID = Guid.NewGuid().ToString();
            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "user@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "user",
                NormalizedUserName = "user"
            };

            // Haszowanie hasła użytkownika
            user.PasswordHash = ph.HashPassword(user, "user1234");

            // Zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(user);

            // Przypisanie roli USER użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = USER_ROLE_ID,
                UserId = USER_ID
            });
        }
    }
}
