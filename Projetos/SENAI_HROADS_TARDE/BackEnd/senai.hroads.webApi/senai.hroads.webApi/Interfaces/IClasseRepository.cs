using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IClasseRepository
    {
        /// <summary>
        /// Lista todos as classes
        /// </summary>
        /// <returns>Uma lista de classes</returns>
        List<Classe> Listar();

        /// <summary>
        /// Busca uma classe através do seu id
        /// </summary>
        /// <param name="idClasse">ID da classe que será buscado</param>
        /// <returns>Uma classe encontrado</returns>
        Classe BuscarPorId(int idClasse);

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto tipoUsuario com os dados que serão cadastrados</param>
        void Cadastrar(Classe novaClasse);

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="idClasse">ID da classe que será atualizado</param>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações</param>
        void Atualizar(byte idClasse, Classe classeAtualizada);

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="idClasse">ID da classe que será deletado</param>
        void Deletar(int idClasse);

        List<Classe> ListarComPersonagens();

        List<Classe> ListarComHabilidades();
    }
}
