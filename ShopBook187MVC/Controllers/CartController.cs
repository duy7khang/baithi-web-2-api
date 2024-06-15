using Microsoft.AspNetCore.Mvc;
using ShopBook187MVC.Models;
using System;
using System.Linq;

namespace ShopBook187MVC.Controllers
{
    public class CartController : Controller
    {
        private static CartViewModel _cart = new CartViewModel();

        public IActionResult Index()
        {
            return View(_cart);
        }

        [HttpPost]
        public IActionResult Add(BookViewModel book)
        {
            _cart.Books.Add(book);
            _cart.TotalPrice += book.Price;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(Guid id)
        {
            var bookToRemove = _cart.Books.FirstOrDefault(b => b.Id == id);
            if (bookToRemove != null)
            {
                _cart.Books.Remove(bookToRemove);
                _cart.TotalPrice -= bookToRemove.Price;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            // Xử lý thanh toán ở đây
            // Sau khi thanh toán, bạn có thể xóa toàn bộ sách trong giỏ hàng
            _cart.Books.Clear();
            _cart.TotalPrice = 0;
            return RedirectToAction("Index", "Home"); // Hoặc trang cảm ơn thanh toán
        }
    }
}
