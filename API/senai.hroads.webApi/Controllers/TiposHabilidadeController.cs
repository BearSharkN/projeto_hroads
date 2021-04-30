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

    public class TiposHabilidadeController : ControllerBase
    {
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }

        public TiposHabilidadeController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

       //Lista todo s tipos de habilidade
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoHabilidadeRepository.Listar());
        }

        //Busca uma Habilidade por ID
        [HttpGet("{id}")] 
        public IActionResult GetById(int id)
        {
            //
            return Ok(_tipoHabilidadeRepository.BuscarPorId(id));
        }

        //Cadastra um novo tipo de Habilidade
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoHabilidade novoTipoHabilidade)
        {
      
            _tipoHabilidadeRepository.Cadastrar(novoTipoHabilidade);

            return StatusCode(201); 
        }

       //Atualiza uma Habilidade
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoHabilidade tipoHabilidadeAtualizado)
        {
            _tipoHabilidadeRepository.Atualizar(id, tipoHabilidadeAtualizado);

            return StatusCode(204);
        }

        //Deleta uma Habilidade
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _tipoHabilidadeRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
