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

    public class ClassesController : ControllerBase
    {
        
        private IClasseRepository _classeRepository { get; set; }

        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_classeRepository.Listar());
        }
        
        //Buscar uma classe por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            
            return Ok(_classeRepository.BuscarPorId(id));
        }

        //Cadastra uma nova Classe
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Classe novaClasse)
        {
            
            _classeRepository.Cadastrar(novaClasse);

            return StatusCode(201); 
        }

        //Atualiza uma Classe
        [HttpPut("{id}")]
        public IActionResult Put(int id, Classe classeAtualizada)
        {
           
            _classeRepository.Atualizar(id, classeAtualizada);

           
            return StatusCode(204);
        }

        //Deleta uma classe
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            
            _classeRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
