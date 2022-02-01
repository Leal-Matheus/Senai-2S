using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Habilidade novaHabilidade)
        {
            _habilidadeRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idHabilidade}")]

        public IActionResult Deletar(int idHabilidade)
        {
            _habilidadeRepository.Deletar(idHabilidade);

            return StatusCode(204);
        }


        [Authorize(Roles = "1")]
        [HttpPut("{idHabilidade}")]
        public IActionResult Atualizar(byte idHabilidade, Habilidade habilidadeAtualizada)
        {
            _habilidadeRepository.Atualizar(idHabilidade, habilidadeAtualizada);

            return StatusCode(204);
        }

        [HttpGet]
        public IActionResult Listar()
        {

            return Ok(_habilidadeRepository.Listar());
        }

        [HttpGet("{idHabilidade}")]
        public IActionResult BuscarPorId(int idHabilidade) 
        {
            return Ok(_habilidadeRepository.BuscarPorId(idHabilidade));
        }

        [HttpGet("QuadroHabilidades")]
        public IActionResult ListarComHabilidades()
        {
            return Ok(_habilidadeRepository.ListarComHabilidades());
        }

    }
}
