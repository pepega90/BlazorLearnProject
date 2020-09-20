using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShoppingCart.Models;

namespace BlazorShoppingCart.ComponentBaseClass
{
    public class ShoppingCartBase : ComponentBase
    {
        private int FakeId { get; set; } = 0;
        public IEnumerable<ShoppingCart> ShoppingCartsItem { get; set; }
        protected List<UserCart> listUserCart { get; set; } = new List<UserCart>();
        private decimal ShoppingCartTotal => listUserCart.Sum(e => e.Harga * e.Quantity);

        protected string DisplayShoppingCartTotal => string.Format(new System.Globalization.CultureInfo("id-ID"), "{0:C}", ShoppingCartTotal);

        protected void AddToCart(int itemId)
        {
            var shoppinCart = ShoppingCartsItem.FirstOrDefault(e => e.Id == itemId);
            UserCart itemUser = new UserCart
            {
                Id = FakeId++,
                NamaBarang = shoppinCart.TitleBarang,
                Harga = shoppinCart.Harga,
                Quantity = 1,
                PhotoPath = shoppinCart.PhotoPath
            };

            if (listUserCart.Count < 3)
                listUserCart.Add(itemUser);
            else
                return;
        }

        protected void HapusItem(int id)
        {
            UserCart deletedusercart = listUserCart.Find(e => e.Id == id);

            listUserCart.Remove(deletedusercart);
        }

        protected void BayarPesanan()
        {
            listUserCart.Clear();
        }

        protected override Task OnInitializedAsync()
        {
            LoadItemShopping();
            return base.OnInitializedAsync();
        }
        private void LoadItemShopping()
        {
            ShoppingCart shoppingCart1 = new ShoppingCart
            {
                Id = 1,
                TitleBarang = "Cakue",
                Harga = 15000,
                PhotoPath = "./images/prod1.jpg"
            };

            ShoppingCart shoppingCart2 = new ShoppingCart
            {
                Id = 2,
                TitleBarang = "Odading",
                Harga = 5000,
                PhotoPath = "./images/prod2.jpg"
            };

            ShoppingCart shoppingCart3 = new ShoppingCart
            {
                Id = 3,
                TitleBarang = "Kopi Hitam",
                Harga = 25000,
                PhotoPath = "./images/kopi5.jpg"
            };

            ShoppingCartsItem = new List<ShoppingCart> { shoppingCart1, shoppingCart2, shoppingCart3 };
        }
    }
}
