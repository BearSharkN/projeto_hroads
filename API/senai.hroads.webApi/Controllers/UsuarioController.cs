using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;

namespace senai.hroads.webApi_.Controllers
{
   
    [Produces("application/json")]
    [Route("api/[controller]")]

    
    [ApiController]
    public class UsuarioController : ControllerBase
    {
      
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }

        //Lista todos os usuários e seus tipos
        [HttpGet("tipo-usuario")]
        public IActionResult GetTipoUsuario()
        {
            return Ok(_usuarioRepository.ListarTipoUsuario());
        }

        //Busca um usuário atráves do seu id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        //Atualiza um usuário existente
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            _usuarioRepository.Atualizar(id, usuarioAtualizado);

            return StatusCode(204);
        }

        //Cadsastra um novo usuário
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        //Deleta um usuário
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            _usuarioRepository.Deletar(id);

           
            return StatusCode(204);
        }
    }
}