using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Tipos de usuario
        /// </summary>
        /// <returns>Uma lista de estúdios</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Busca um tipoUsuario através do seu id
        /// </summary>
        /// <param name="idTipoUsuario">ID do tipoUsuario que será buscado</param>
        /// <returns>Um tipoUsuario encontrado</returns>
        TipoUsuario BuscarPorId(int idTipoUsuario);

        /// <summary>
        /// Cadastra um novo TipoUsuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto tipoUsuario com os dados que serão cadastrados</param>
        void Cadastrar(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um Tipo =Usuario existente
        /// </summary>
        /// <param name="idTipoUsuario">ID do TipoUsuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto tipoUsuarioAtualizado com as novas informações</param>
        void Atualizar(byte idTipoUsuario, TipoUsuario tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um TipoUsuario existente
        /// </summary>
        /// <param name="idTipoUsuario">ID do TipoUsuario que será deletado</param>
        void Deletar(int idTipoUsuario);

        List<TipoUsuario> ListarComUsuarios();
    }
}
