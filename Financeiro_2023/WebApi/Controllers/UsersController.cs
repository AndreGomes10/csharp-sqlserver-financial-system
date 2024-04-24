using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers
{
    // para criar um controller, adicionar -> controlador -> api, controlador vazio

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // criar usuario, metodo de confirmação
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AdicionarUsuario")]
        public async Task<IActionResult> AdicionaUsuario([FromBody] Login login)
        {
            if(string.IsNullOrWhiteSpace(login.email) || 
               string.IsNullOrWhiteSpace(login.senha)  || 
               string.IsNullOrWhiteSpace(login.cpf))
            {
                return Ok("Falta alguns dados");
            }

            var user = new ApplicationUser
            {
                Email = login.email,
                UserName = login.email,
                CPF = login.cpf
            };

            var result = await _userManager.CreateAsync(user, login.senha);  // criar usuario

            if(result.Errors.Any())  // se tem algum erro
            {
                return Ok(result.Errors);
            }

            // Geração de confirmação caso precise - Enviar Email de Confirmação se o usuario é de verdade ou não

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));  // code enviar por email

            // retorno do email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var respose_Retorn = await _userManager.ConfirmEmailAsync(user, code);

            // se o usuario esta autenticado e pode usar o sistema ou não
            if(respose_Retorn.Succeeded)
            {
                return Ok("Usuário Adicionado");
            }
            else
            {
                return Ok("Erro ao confirmar cadastro de Usuário");
            }
        }
    }
}
