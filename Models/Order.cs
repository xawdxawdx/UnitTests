using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace magazin.Models
{
    public class Order : IValidatableObject
    {
        public int OrderId { get; set; }
        public string User { get; set; } 
        public string Address { get; set; } 
        public string ContactPhone { get; set; } 

        public int PhoneId { get; set; } 
        public Phone Phone { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.User))
            {
                errors.Add(new ValidationResult("Введите имя!", new List<string>() { "Name" }));
            }
            if (string.IsNullOrWhiteSpace(this.Address))
            {
                errors.Add(new ValidationResult("Введите адрес!"));
            }
            if (!this.ContactPhone.StartsWith("+7"))
            {
                errors.Add(new ValidationResult("Недопустимый номер страны!"));
            }

            return errors;
        }
    }
}
