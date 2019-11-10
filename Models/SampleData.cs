using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using magazin.Models;

namespace magazin.Models
{
    public static class SampleData
    {
        public static void Initialize(MobileContext context)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "iPhone 11 Pro max",
                        Company = "Apple",
                        Price = 2000
                    },
                    new Phone
                    {
                        Name = "Samsung Galaxy S10",
                        Company = "Samsung",
                        Price = 1200
                    },
                    new Phone
                    {
                        Name = "Google Pixel",
                        Company = "Google",
                        Price = 1500
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
