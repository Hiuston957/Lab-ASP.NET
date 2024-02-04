using Data.Entities;
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

        public DbSet<OrganizationEntity> Organizations { get; set; }


        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Mydata6.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //------------------------------------



            modelBuilder.Entity<ContactEntity>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>().HasData(
                 new OrganizationEntity()
                 {
                     OrganizationEntityId = 1,
                     Title = "WSEI",
                     Nip = "83492384",
                     Regon = "13424234",
                 },
                 new OrganizationEntity()
                 {
                     OrganizationEntityId = 2,
                     Title = "Firma",
                     Nip = "2498534",
                     Regon = "0873439249",
                 }
             ); ;
            modelBuilder.Entity<ContactEntity>().HasData(
               new ContactEntity()
               {
                   Id = 1,
                   Name = "AA",
                   Email = "Adam",
                   Phone = "13424234",
                   OrganizationId = 1,

               },
               new ContactEntity()
               {
                   Id = 2,
                   Name = "C#",
                   Email = "Ewa",
                   Phone = "02879283",
                   OrganizationId = 2,
               }
           );
           modelBuilder.Entity<OrganizationEntity>()
               .OwnsOne(e => e.Address)
                 .HasData(
                 new { OrganizationEntityId = 1, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150", Region = "małopolskie" },
                 new { OrganizationEntityId = 2, City = "Kraków", Street = "Krowoderska 45/6", PostalCode = "31-150", Region = "małopolskie" }
               );



            //--------------------------------------
            modelBuilder.Entity<AlbumEntity>().HasData(
             new AlbumEntity() { Id = 1, Nazwa = "Album1", Zespol = "Band1", Spis_piosenek = "Song1, Song2", Notowanie = 1, Data_wydania = new DateTime(2022, 1, 1) },
             new AlbumEntity() { Id = 2, Nazwa = "Album2", Zespol = "Band2", Spis_piosenek = "Song3, Song4", Notowanie = 2, Data_wydania = new DateTime(2022, 2, 1) }
         );

          
            modelBuilder.Entity<AlbumEntity>();
            base.OnModelCreating(modelBuilder);

      







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
