using System;
using System.Collections.Generic;

namespace ShopBook187MVC.Models
{
    public class CartViewModel
    {
        public List<BookViewModel> Books { get; set; } = new List<BookViewModel>();
        public decimal TotalPrice { get; set; }
    }
}
