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
    public class QuadroHabilidadesController : ControllerBase
    {
        private  IQuadroHabilidadeRepository _quadroHabilidadesRepository { get; set; }
        public QuadroHabilidadesController()
        {
            _quadroHabilidadesRepository = new QuadroHabilidadeRepository();
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_quadroHabilidadesRepository.Listar());
        }
        [Authorize(Roles = "1, 2")]
        [HttpGet("{idQuadro}")]
        public IActionResult BuscarPorId(int idQuadroHabilidade)
        {
            return Ok(_quadroHabilidadesRepository.BuscarPorId(idQuadroHabilidade));
        }
        [Authorize(Roles = "1, 2")]
        [HttpPost]
        public IActionResult Cadastrar(QuadroHabilidade novoQuadroHabilidade)
        {
            _quadroHabilidadesRepository.Cadastrar(novoQuadroHabilidade);
            return StatusCode(201);
        }
        [Authorize(Roles = "1, 2")]
        [HttpPut("{idQuadro}")]
        public IActionResult Atualizar(byte idQuadroHabilidade, QuadroHabilidade quadroHabilidadeAtualizado)
        {
            _quadroHabilidadesRepository.Atualizar(idQuadroHabilidade, quadroHabilidadeAtualizado);
            return StatusCode(204);

        }
        [Authorize(Roles = "1, 2")]
        [HttpDelete("{idQuadro}")]
        public IActionResult Deletar(int idQuadroHabilidade)
        {
            _quadroHabilidadesRepository.Deletar(idQuadroHabilidade);
            return StatusCode(204);

        }

    }
}
