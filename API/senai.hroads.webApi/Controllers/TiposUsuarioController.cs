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
    public class TiposUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

       //Lista todos os tipos de usuários
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        //Busca um usuário por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
   
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        //Atualiza o tipo de usuario
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

            return StatusCode(204);
        }

        //Cadastra um novo tipo de usuário
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        //Deleta um tipo de usuário
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipoUsuarioRepository.Deletar(id);

            
            return StatusCode(204);
        }
    }
}