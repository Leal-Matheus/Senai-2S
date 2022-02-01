using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepository _veiculoRepository { get; set; }
        public VeiculosController()
        {
            _veiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaVeiculos = _veiculoRepository.ListarTodos();

            return Ok(listaVeiculos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculoDomain veiculoBuscado = _veiculoRepository.BuscarPorId(id);

            if (veiculoBuscado == null)
            {
                return NotFound("Nenhum veículo foi encontrado!");
            }

            return Ok(veiculoBuscado);
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {
            _veiculoRepository.Cadastrar(novoVeiculo);
            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _veiculoRepository.Deletar(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult PutIdBody(VeiculoDomain veiculoAtualizado)
        {
            if (veiculoAtualizado.idEmpresa <= 0 || veiculoAtualizado.idVeiculo <= 0 || veiculoAtualizado.idModelo <= 0 || veiculoAtualizado.placa == null)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Nem todos requisitos foram informadps"
                    });
            }

            VeiculoDomain veiculoBuscado = _veiculoRepository.BuscarPorId(veiculoAtualizado.idVeiculo);

            if (veiculoBuscado != null)
            {
                try
                {
                    _veiculoRepository.AtualizarIdCorpo(veiculoAtualizado);

                    return NoContent();
                }
                catch (Exception codErro)
                {
                    return BadRequest(codErro);
                }
            }

            return NotFound(
                    new
                    {
                        mensagem = "Veículo não encontrado!",
                        errorStatus = true
                    }
                );
        }
    }
}