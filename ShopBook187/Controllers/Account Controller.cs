// Controller của API (AccountController)
using Microsoft.AspNetCore.Mvc;
using ShopBook187.API.Models;
using System.Collections.Generic;

namespace ShopBook187.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private static readonly List<AccountDTO> _accounts = new List<AccountDTO>();

        [HttpPost("Register")]
        public IActionResult Register(AccountDTO model)
        {
            if (ModelState.IsValid)
            {
                _accounts.Add(model); // Thêm tài khoản vào danh sách (hoặc lưu vào cơ sở dữ liệu)
                return Ok("Account registered successfully");
            }
            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public IActionResult Login(AccountDTO model)
        {
            var account = _accounts.Find(a => a.Username == model.Username && a.Password == model.Password);
            if (account != null)
            {
                return Ok("Login successful");
            }
            return NotFound("Invalid username or password");
        }
    }
}
