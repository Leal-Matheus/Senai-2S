using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    interface IFilmeRepository
    {
        // Estrutura dos métodos
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro);

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Retorna uma lista de filmes</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Busca um Filme através do Id
        /// </summary>
        /// <param name="idFilme">Id do filme a ser buscado</param>
        /// <returns>Reporta um objeto do tipo FilmeDomain</returns>
        FilmeDomain BuscarPorId(int idFilme);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto do tipo FilmeDomain a ser cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Atualiza um filme existente. Id passado dentro do objeto filmeAtualizado
        /// </summary>
        /// <param name="filmeAtualizado">Objeto do tipo FilmeDomain com os campos atualizados</param>
        void AtualizarIdCorpo(FilmeDomain filmeAtualizado);

        /// <summary>
        /// Atualiza um filme existente. Id passado pela URL
        /// </summary>
        /// <param name="id">Id do filme a ser atualizado</param>
        /// <param name="filmeAtualizado">Objeto do tipo FilmeDomain com os campos atualizados</param>
        void AtualizarIdUrl(int id, FilmeDomain filmeAtualizado);

        /// <summary>
        /// Deleta um filme através do id
        /// </summary>
        /// <param name="IdGenero">Id do filme a ser deletado</param>
        void Deletar(int IdGenero);
    }
}
