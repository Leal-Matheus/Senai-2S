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
    public class TipoHabilidadesController : ControllerBase
    {
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }
        public TipoHabilidadesController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoHabilidade novoTipo)
        {
            _tipoHabilidadeRepository.Cadastrar(novoTipo);

            return StatusCode(201);
        }


        [Authorize(Roles = "1")]
        [HttpDelete("{idTipoHabilidade}")]
        public IActionResult Deletar(int idTipoHabilidade)
        {
            _tipoHabilidadeRepository.Deletar(idTipoHabilidade);

            return StatusCode(204);
        }


        [Authorize(Roles = "1")]
        [HttpPut("{idTipoHabilidade}")]
        public IActionResult Atualizar(byte idTipoHabilidade, TipoHabilidade tipoHabilidadeAtualizado)
        {
            _tipoHabilidadeRepository.Atualizar(idTipoHabilidade, tipoHabilidadeAtualizado);

            return StatusCode(204);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            _tipoHabilidadeRepository.Listar();

            return Ok(_tipoHabilidadeRepository.Listar());
        }

        [HttpGet("{idTipoHabilidade}")]
        public IActionResult BuscarPorId(int idTipoHabilidade)
        {
            return Ok(_tipoHabilidadeRepository.BuscarPorId(idTipoHabilidade));
        }

        [HttpGet("Habilidade")]
        public IActionResult ListarComHabilidade()
        {
            return Ok(_tipoHabilidadeRepository.ListarComHabilidade());
        }
    }
}
