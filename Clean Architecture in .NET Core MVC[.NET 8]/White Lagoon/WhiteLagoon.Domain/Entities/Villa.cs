﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhiteLagoon.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Price Per Night")]
        [Range(10, 10000)]
        public double Price { get; set; }
        public int Sqft { get; set; }

        public int Occupancy { get; set; }
        [NotMapped]

        public IFormFile? Image { get; set; }

        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }


        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [ValidateNever]
        public IEnumerable<Amenity> VillaAmenity { get; set; }


    }
}
