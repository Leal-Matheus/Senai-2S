using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os  usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um usuario através do seu id
        /// </summary>
        /// <param name="idUsuario">ID do usuario que será buscado</param>
        /// <returns>Um usuario encontrado</returns>
        Usuario BuscarPorId(int idUsuario);

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto usuario com os dados que serão cadastrados</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="idUsuario">ID do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuario com as novas informações</param>
        void Atualizar(int idUsuario, Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="idUsuario">ID do usuario que será deletado</param>
        void Deletar(int idUsuario);

        Usuario BuscarUsuario(string email, string senha);
    }
}
