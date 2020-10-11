using System;
using System.Collections.Generic;
using System.Text;
using EfTest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EfTest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
            AddAdmin(modelBuilder);
        }

        private void AddAdmin(ModelBuilder modelBuilder)
        {
            string adminId = Guid.NewGuid().ToString();
            string roleId = Guid.NewGuid().ToString();


            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = roleId, Name = "Admin", NormalizedName = "Admin".ToUpper() });

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = adminId,
                    Name = "admin",
                    UserName = "admin@test.com",
                    NormalizedUserName = "admin@test.com".ToUpper(),
                    Email = "admin@test.com",
                    NormalizedEmail = "admin@test.com".ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = string.Empty,
                    PasswordHash = HashPassword(null, "pass")

                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher() { Name = "Little, Brown and Company", Id = -1 },
                new Publisher() { Name = "Scholastic", Id = -2 }
                );
            modelBuilder.Entity<Book>().HasData(
                new Book() { Id = -1, Title = "Harry Potter And The Cursed Child", PublisherId = -1 },
                new Book() { Id = -2, Title = "The Hunger Games", PublisherId = -2 }
                );


            modelBuilder.Entity<AppUser>().HasData(

                new AppUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "a@test.com",
                    NormalizedUserName = "a@test.com".ToUpper(),
                    Email = "a@test.com",
                    NormalizedEmail = "a@test.com".ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = string.Empty,
                    PasswordHash = HashPassword(null, "pass")
                });
        }
        string HashPassword(AppUser user, string password)
        {
            var hasher = new PasswordHasher<AppUser>();
            return hasher.HashPassword(user, password);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}




