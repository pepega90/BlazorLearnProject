using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShoppingCart.Models
{
    public class UserCart
    {
        public int Id { get; set; }
        public string NamaBarang { get; set; }
        public int Quantity { get; set; }
        public decimal Harga { get; set; }
        public string PhotoPath { get; set; }

        public string DisplayItemUserHarga => string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:C}", Harga);
    }
}
