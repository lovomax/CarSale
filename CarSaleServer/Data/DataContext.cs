using CarSale.Models;
using CarSaleBackEnd.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarSale.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasOne(c => c.Make).WithMany(m => m.Cars).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Photo>().HasOne(p => p.Car).WithOne(c => c.Photo).OnDelete(DeleteBehavior.Cascade);

            //Populating the Database
            var admin = new User
            {
                Id = Guid.NewGuid(),
                Name = "admin"
            };
            var pwd = "admin";

            using (var hmac = new HMACSHA512())
            {
                admin.PasswordSalt = hmac.Key;
                admin.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            }

            modelBuilder.Entity<User>().HasData(admin);

            modelBuilder.Entity<Make>().HasData(
                new Make { Id = 1, Name = "toyota" },
                new Make { Id = 2, Name = "mitsubishi" },
                new Make { Id = 3, Name = "ford" },
                new Make { Id = 4, Name = "audi" },
                new Make { Id = 5, Name = "volkswagen" }
            );
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 2000, Name="xei", Model = "corolla", Color = "white", MakeId = 1, Kilometers = 1000, Price= 40000, Year = new DateTime(2018, 1, 1) },
                new Car { Id = 2429, Name = "sw4", Model = "hilux", Color = "brown", MakeId = 1, Kilometers = 59210, Price = 12144, Year = new DateTime(2001, 1, 1) },
                new Car { Id = 5912, Name = "pajero", Model = "montero", Color = "black", MakeId = 2, Kilometers = 71293, Price = 36000, Year = new DateTime(1999, 1, 1) },
                new Car { Id = 312, Name = "g4", Model = "mirage", Color = "red", MakeId = 2, Kilometers = 3000, Price = 49000, Year = new DateTime(2015, 1, 1) },
                new Car { Id = 59182, Name = "sportback ambiente", Model = "a5", Color = "blue", MakeId = 4, Kilometers = 0, Price = 250000, Year = new DateTime(2022, 1, 1) },
                new Car { Id = 23, Name = "xlt", Model = "ecosport", Color = "yellow", MakeId = 3, Kilometers = 6000, Price = 25000, Year = new DateTime(2010, 1, 1) },
                new Car { Id = 12198, Name = "msi total trendline", Model = "gol", Color = "grey", MakeId = 5, Kilometers = 1235, Price = 35000, Year = new DateTime(2017, 1, 1) },
                new Car { Id = 9, Name = "fsi tronic turbo", Model = "tt", Color = "silver", MakeId = 4, Kilometers = 6231, Price = 200000, Year = new DateTime(2007, 1, 1) },
                new Car { Id = 1928, Name = "xl 2.8", Model = "ranger", Color = "orange", MakeId = 3, Kilometers = 12938, Price = 70000, Year = new DateTime(2002, 1, 1) },
                new Car { Id = 12568, Name = "3.6 super gasolina", Model = "f-100", Color = "green", MakeId = 3, Kilometers = 192102, Price = 10000, Year = new DateTime(1982, 1, 1) },
                new Car { Id = 4236, Name = "gli 2.0", Model = "santana", Color = "purple", MakeId = 5, Kilometers = 82191, Price = 27000, Year = new DateTime(1996, 1, 1) },
                new Car { Id = 123566, Name = "gt v6", Model = "outlander", Color = "black", MakeId = 2, Kilometers = 1000, Price = 65000, Year = new DateTime(2018, 1, 1) },
                new Car { Id = 12, Name = "200 tsi total", Model = "t-cross", Color = "white", MakeId = 5, Kilometers = 100, Price = 55000, Year = new DateTime(2022, 1, 1) },
                new Car { Id = 1254, Name = "avant quattro", Model = "rs4", Color = "white", MakeId = 4, Kilometers = 500, Price = 290000, Year = new DateTime(2021, 1, 1) },
                new Car { Id = 132, Name = "ambiente quattro", Model = "q3", Color = "dark blue", MakeId = 4, Kilometers = 1223, Price =160000, Year = new DateTime(2013, 1, 1) }
            );
        }


        public DbSet<User> Users => Set<User>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Make> Makes => Set<Make>();
        public DbSet<Photo> Photos => Set<Photo>();

    }
}
