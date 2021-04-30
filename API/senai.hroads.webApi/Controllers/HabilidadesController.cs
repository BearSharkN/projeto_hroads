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
    public class HabilidadesController : ControllerBase
    {
      
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

      //Listar todas as Habilidades
        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(_habilidadeRepository.Listar());
        }

        //Listar o tipo de habilidade
        [HttpGet("tipo-habilidade")]
        public IActionResult GetTipoHabilidade()
        {
            
            return Ok(_habilidadeRepository.ListarTipoHabilidade());
        }

        //Busca Habilidade por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_habilidadeRepository.BuscarPorId(id));
        }

       //Atualiza Habilidade por ID
        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade habilidadeAtualizada)
        {
            _habilidadeRepository.Atualizar(id, habilidadeAtualizada);

            return StatusCode(204);
        }

       //Cadastra uma nova Habilidade
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            _habilidadeRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }

        //Deleta uam Habilidade por id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _habilidadeRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
