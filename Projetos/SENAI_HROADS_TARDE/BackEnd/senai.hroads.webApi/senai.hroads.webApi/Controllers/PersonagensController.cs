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

        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_personagemRepository.Listar());
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("{idPersonagem}")]
        public IActionResult BuscarPorId(int idPersonagem)
        {
            return Ok(_personagemRepository.BuscarPorId(idPersonagem));
        }
        [Authorize(Roles = "1, 2")]
        [HttpPost]
        public IActionResult Cadastrar(Personagem novoPersonagem)
        {
            _personagemRepository.Cadastrar(novoPersonagem);
            return StatusCode(201);
        }
        [Authorize(Roles = "1, 2")]
        [HttpPut("{idPersonagem}")]
        public IActionResult Atualizar(byte idPersonagem, Personagem personagemAtualizado)
        {
            _personagemRepository.Atualizar(idPersonagem, personagemAtualizado);
            return StatusCode(204);

        }
        [Authorize(Roles = "1, 2")]
        [HttpDelete("{idPersonagem}")]
        public IActionResult Deletar(int idPersonagem)
        {
            _personagemRepository.Deletar(idPersonagem);
            return StatusCode(204);

        }

    }
}
