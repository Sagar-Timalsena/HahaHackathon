using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        public DbSet<Amenity> Amenities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {

                    Id = 1,
                    Name = "Royal Villa",
                    Description = "kjjjjkkjkj  knkjkj mkkj",
                    ImageUrl = " knmkmk ,mkm",
                    Occupancy = 10,
                    Price = 100,
                    Sqft = 100,


                },
                new Villa
                {
                    Id = 2,
                    Name = "King Villa",
                    Description = "kjjjjkkjkj  knkjkj mkkj",
                    ImageUrl = " knmkmk ,mkm",
                    Occupancy = 10,
                    Price = 100,
                    Sqft = 200,
                },

                new Villa
                {


                    Id = 3,
                    Name = "King Villa",
                    Description = "kjjjjkkjkj  knkjkj mkkj",
                    ImageUrl = " knmkmk ,mkm",
                    Occupancy = 10,
                    Price = 100,
                    Sqft = 200,

                });

            modelBuilder.Entity<VillaNumber>().HasData(
                new VillaNumber
                {
                    Villa_Number = 101,
                    VillaId = 1,
                },

                 new VillaNumber
                 {
                     Villa_Number = 102,
                     VillaId = 1,
                 },

                  new VillaNumber
                  {
                      Villa_Number = 103,
                      VillaId = 1,
                  },
                   new VillaNumber
                   {
                       Villa_Number = 201,
                       VillaId = 2,
                   },
                    new VillaNumber
                    {
                        Villa_Number = 202,
                        VillaId = 2,
                    },
                     new VillaNumber
                     {
                         Villa_Number = 203,
                         VillaId = 2,
                     },
                      new VillaNumber
                      {
                          Villa_Number = 204,
                          VillaId = 2,
                      },
                       new VillaNumber
                       {
                           Villa_Number = 301,
                           VillaId = 3,
                       },
                        new VillaNumber
                        {
                            Villa_Number = 302,
                            VillaId = 3,
                        },
                         new VillaNumber
                         {
                             Villa_Number = 303,
                             VillaId = 3,
                         }

                );

            modelBuilder.Entity<Amenity>().HasData(

                new Amenity
                {
                    Id = 1,
                    VillaId = 1,
                    Name = "Private Pool"



                },
                new Amenity
                {

                    Id = 2,
                    VillaId = 1,
                    Name = "Microwave"
                },
                   new Amenity
                   {

                       Id = 3,
                       VillaId = 1,
                       Name = "Microwave"
                   },


                      new Amenity
                      {

                          Id = 4,
                          VillaId = 2,
                          Name = "Microwave"
                      },

                       new Amenity
                     {

                    Id = 5,
                 VillaId = 3,
                 Name = "Microwave"
                     }


                );








        }
    }
}
