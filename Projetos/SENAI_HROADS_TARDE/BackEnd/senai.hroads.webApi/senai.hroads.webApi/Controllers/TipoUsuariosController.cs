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
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }
        public TipoUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }


        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um tipo de usuario através do seu id
        /// </summary>
        /// <param name="idTipoUsuario">ID do tipo de usuario que será buscado</param>
        /// <returns>Um tipo de usuario e um status code 200 - Ok</returns>

        [Authorize(Roles = "1, 2")]
        [HttpGet("{idTipoUsuario}")]
        public IActionResult BuscarPorId(int idTipoUsuario)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(idTipoUsuario));
        }

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto com os dados que serão cadastrados</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novoTipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um tipo de usuario existente
        /// </summary>
        /// <param name="idTipoUsuario">ID do tipo de usuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto com os novos dados</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idTipoUsuario}")]
        public IActionResult Atualizar(byte idTipoUsuario, TipoUsuario tipoUsuarioAtualizado)
        {
            _tipoUsuarioRepository.Atualizar(idTipoUsuario, tipoUsuarioAtualizado);

            return StatusCode(204);
        }
        [Authorize(Roles = "1")]
        [HttpDelete("{idTipoUsuario}")]
        public IActionResult Deletar(int idTipoUsuario)
        {
            _tipoUsuarioRepository.Deletar(idTipoUsuario);

            return StatusCode(204);
        }
        [Authorize(Roles = "1, 2")]
        [HttpGet("Usuarios")]
        public IActionResult ListarComUsuarios()
        {
            return Ok(_tipoUsuarioRepository.ListarComUsuarios());
        }
    }
}
