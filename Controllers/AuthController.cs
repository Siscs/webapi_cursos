using System.Linq;
using System.Threading.Tasks;
using lxwebapijwt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace lxwebapijwt.Controllers
{
    [ApiController]
    [Route("v1/auth")]
    public class AuthController : ControllerBase
    {

        private readonly SignInManager<IdentityUser> _signInmanager;
        private readonly UserManager<IdentityUser> _usermanager;

        public AuthController(SignInManager<IdentityUser> signInmanager, UserManager<IdentityUser> usermanager)
        {
            _signInmanager = signInmanager;
            _usermanager = usermanager;
        }

        [HttpPost("novousuario")]
        public async Task<ActionResult> NovoUsuario(UsuarioRegistrarVM usuarioRegistrarVM)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(p => p.Errors));

            var newUser = new IdentityUser
            {
                UserName = usuarioRegistrarVM.Email,
                Email = usuarioRegistrarVM.Email,
                EmailConfirmed = true
            };

            var result = await _usermanager.CreateAsync(newUser, usuarioRegistrarVM.Senha);

            if(!result.Succeeded) return BadRequest(result.Errors);

            await _signInmanager.SignInAsync(newUser, false);

            return Ok();

        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UsuarioLoginVM usuarioLoginVM)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(p => p.Errors));

            var result = await _signInmanager.PasswordSignInAsync(usuarioLoginVM.Email, usuarioLoginVM.Senha, false , true);

            if(result.Succeeded) return Ok();

            return BadRequest(new { Message = "usuario inválido"} );

        }
        
    }
}