using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _clienteRepository { get; set; }
        public ClientesController()
        {
            _clienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            List<ClienteDomain> listaClientes = _clienteRepository.ListarTodos();

            return Ok(listaClientes);

        }

        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            //Chama o método de cadastrar
            _clienteRepository.Cadastrar(novoCliente);

            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClienteDomain clienteBuscado = _clienteRepository.BuscarPorId(id);

            if (clienteBuscado == null)
            {
                return NotFound("Nenhum cliente encontrado!");
            }

            return Ok(clienteBuscado);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _clienteRepository.Deletar(id);
            return NoContent();
        }


        [HttpPut]
        public IActionResult PutIdBody(ClienteDomain clienteAtualizado)
        {
            if (clienteAtualizado.nomeCliente == null || clienteAtualizado.idCliente <= 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Nome ou o id do cliente não foi informado!"
                    });
            }

            ClienteDomain clienteBuscado = _clienteRepository.BuscarPorId(clienteAtualizado.idCliente);

            if (clienteBuscado != null)
            {
                try
                {
                    _clienteRepository.AtualizarIdCorpo(clienteAtualizado);

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
                        mensagem = "Cliente não encontrado!",
                        errorStatus = true
                    }
                );
        }

    }
}
