using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// Controller responsável pelos endpoints
/// </summary>
namespace senai_filmes_webAPI.Controllers
{
    //Define que tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define a rota de uma requisição será no formato dominio/api/controller
    // ex: http://localhost:500/api/generos
    [Route("api/[controller]")]


    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        [HttpGet]
        public IActionResult Get() 
        {
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            return Ok(listaGeneros);
        }

        /// <summary>
        /// Cadastra um novo Gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero a ser cadastrado</param>
        /// <returns>Retorna um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            //Chama o método de cadastrar
            _generoRepository.Cadastrar(novoGenero);

            return StatusCode(201);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound("Nenhum gênero encontrado!");
            }

            return Ok(generoBuscado);
        }
        [HttpPut("{id]")]
        public IActionResult PutIdUrl(int id, GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Gênero não encontrado",
                        erro = true
                    }
                  );
            }
            try
            {
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);            
            }
        }
        [HttpPut]
        public IActionResult PutByBody(GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.idGenero);

            if (generoBuscado != null)
            {
                try
                {
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound(
                new
                {
                    mensagem = "Gênero não encontrado",
                    erro = true
                }
                );
        }

    }
}
