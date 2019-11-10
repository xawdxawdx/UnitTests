using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace magazin.Models
{
    public class CustomAttribute:ValidationAttribute
    {
        public override bool  IsValid(object value) {
            if ((value as string).Length <= 1)
                return false;
            return true;
        }
    }
}
