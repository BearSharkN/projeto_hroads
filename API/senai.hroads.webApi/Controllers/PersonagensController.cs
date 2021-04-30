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
    public class PersonagensController : ControllerBase
    {
      
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        //Listar todos os Personagens
        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personagemRepository.Listar());
        }

        //Listar todos os Personagens
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            
            return Ok(_personagemRepository.BuscarPorId(id));
        }

        //Todos os Personagens com seus tipos
        [HttpGet("personagem-classe")]
        public IActionResult GetClasse()
        {
           
            return Ok(_personagemRepository.ListarClasse());
        }

      //Atualiza um Personagem por id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagem personagemAtualizado)
        {
            _personagemRepository.Atualizar(id, personagemAtualizado);
            return StatusCode(204);
        }

       //Cadastra um novo personagem
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Personagem novoPersonagem)
        { 
            _personagemRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        //Deletga um Personagem
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personagemRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}