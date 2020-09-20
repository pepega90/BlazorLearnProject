using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShoppingCart.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string TitleBarang { get; set; }
        public decimal Harga { get; set; }
        public string PhotoPath { get; set; }

        public string DisplayShoppingCartItem => string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:C}", Harga);
    }
}
