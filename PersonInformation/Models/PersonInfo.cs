using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonInformation.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonInformation.Models
{
    public class PersonInfo
    {

        [Required,Display(Name ="Enter Your First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Enter Your Last Name")]
        public string LastName { get; set; }
        [Required, Display(Name = "Country")]
        public int CountryId { get; set; }
        public string  CountryName { get; set; }
        [Required, Display(Name = "City")]
        public int CityId { get; set; }

        public string CityName { get; set; }


        [Required]
        [Display(Name ="Enter your personal img")]
        public IFormFile img { get; set; }

        public string imgURL { get; set; }

        [Required]
        public  int Age { get; set; }
       


    }
}
