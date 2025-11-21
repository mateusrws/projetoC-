

using Loja.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loja.Controllers.UserController
{
    public class UserController : ControllerBase
    {
        private readonly AddDbContext _context;

        public UserController(AddDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _context.Users.ToListAsync();
            return Ok(user);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (id == null) return NotFound("Id não fornecido");
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("Usuário não encontrado");
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] string email, string pass)
        {
            if (email == null | pass == null) return NotFound("Email ou senha faltando");
            var user = await _context.Users.FindAsync(email);
            if (user == null) return NotFound("Usuário não encontrado");
            bool valid = BCrypt.Net.BCrypt.Verify(pass, user.password);
            if (valid == false) return Unauthorized("Senha incorreta");
            return Ok(user);
        }
        //Continuar para o POST
   }
}