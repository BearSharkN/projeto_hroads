using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;

namespace senai.hroads.webApi_.Controllers
{
   
    [Produces("application/json")]
    [Route("api/[controller]")]
  
    [ApiController]
    public class LoginController : ControllerBase
    {
   
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        //Login
        [HttpPost]
        public IActionResult Login (Usuario login)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

            if (usuarioBuscado == null)
            {
             
                return NotFound("E-mail ou senha inválidos!");
            }
   
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString())
            };

            //Token de acesso
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-autenticacao"));

       
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "hroads.webApi",                 
                audience: "hroads.webApi",               
                claims: claims,                        
                expires: DateTime.Now.AddMinutes(10),   
                signingCredentials: creds             
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}