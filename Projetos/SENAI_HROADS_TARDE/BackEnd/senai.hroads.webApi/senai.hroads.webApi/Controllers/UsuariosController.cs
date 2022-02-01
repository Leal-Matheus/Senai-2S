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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public UsuariosController()
        {
             _usuarioRepository = new UsuarioRepository();
        }


        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um usuario através do seu id
        /// </summary>
        /// <param name="idUsuario">ID do usuario que será buscado</param>
        /// <returns>Um usuario e um status code 200 - Ok</returns>

        [Authorize(Roles = "1, 2")]
        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorId(int idUsuario)
        {
            return Ok(_usuarioRepository.BuscarPorId(idUsuario));
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto com os dados que serão cadastrados</param>
        /// <returns>Um status code 201 - Created</returns>

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="idUsuario">ID do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com os novos dados</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "1, 2")]
        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            _usuarioRepository.Atualizar(idUsuario, usuarioAtualizado);

            return StatusCode(204);
        }
        [Authorize(Roles = "1, 2")]
        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            _usuarioRepository.Deletar(idUsuario);

            return StatusCode(204);
        }
    }
}
