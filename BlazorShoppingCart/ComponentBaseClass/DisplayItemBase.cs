using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShoppingCart.Models;

namespace BlazorShoppingCart.ComponentBaseClass
{
    public class DisplayItemBase : ComponentBase
    {
        [Parameter]
        public ShoppingCart CartItem { get; set; }

        [Parameter]
        public EventCallback<int> OnAddItem { get; set; }
    }
}
