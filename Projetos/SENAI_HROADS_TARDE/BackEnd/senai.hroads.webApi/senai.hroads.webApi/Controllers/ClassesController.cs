using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;

namespace senai.hroads.webApi_.Controllers
{
    [Produces ("application/json")]
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
        public IActionResult Listar()
        {
            return Ok(_classeRepository.Listar());
        }

        [HttpGet("{idClasse}")]
        public IActionResult BuscarPorId(int idClasse)
        {
            return Ok(_classeRepository.BuscarPorId(idClasse));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Classe novaClasse)
        {
            _classeRepository.Cadastrar(novaClasse);
            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idClasse}")]
        public IActionResult Atualizar(byte idClasse, Classe classeAtualizada)
        {
            _classeRepository.Atualizar(idClasse, classeAtualizada);
            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idClasse}")]
        public IActionResult Deletar(int idClasse)
        {
            _classeRepository.Deletar(idClasse);
            return StatusCode(204);
        }
        [HttpGet("Personagens")]
        public IActionResult ListarComPersonagens()
        {
            return Ok(_classeRepository.ListarComPersonagens());
        }
        [HttpGet("QuadroHabilidades")]
        public IActionResult ListarComHabilidades()
        {
            return Ok(_classeRepository.ListarComHabilidades());
        }
    }
}
