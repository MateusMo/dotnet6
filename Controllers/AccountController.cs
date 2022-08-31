using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.Services;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    
    [ApiController]
    public class AccountController : ControllerBase 
    {
        private readonly TokenService _tokenService;
        private readonly BlogDataContext _context;

        public AccountController(TokenService tokenService,BlogDataContext context)
        {
            this._tokenService = tokenService;
            this._context = context;
        }

        [HttpPost("v1/accounts")]
        public async Task<IActionResult> Post([FromBody]RegisterViewModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Slug = model.Email.Replace("@", "-").Replace(".", "-");
            }
        }

        [HttpPost("v1/login")]
        public IActionResult Login()
        {
            var token = _tokenService.GenerateToken(null);
            return Ok(token);
        }
        

    }
}
