using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace magazin.Models
{
    public class Phone
    {
        public int Id { get; set; }
        [Custom(ErrorMessage = "Название телефона не может состоять из 1 буквы")]
        public string Name { get; set; }
        [Required]
        [Remote(action: "CheckCompany", controller: "Home", ErrorMessage = "Эта компания у нас забанена ! САНЦИИИИИИИ!!!")]
        public string Company { get; set; }
        [Range(50, 3000)]
        [Required]
        public int Price { get; set; }
    }
}
