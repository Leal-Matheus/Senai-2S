using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IQuadroHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os quadros
        /// </summary>
        /// <returns>Uma lista de quadros</returns>
        List<QuadroHabilidade> Listar();

        /// <summary>
        /// Busca um quadro através do seu id
        /// </summary>
        /// <param name="idQuadroHabilidade">ID do quadro que será buscado</param>
        /// <returns>Um quadro encontrado</returns>
        QuadroHabilidade BuscarPorId(int idQuadroHabilidade);

        /// <summary>
        /// Cadastra um novo quadro
        /// </summary>
        /// <param name="novoQuadroHabilidade">Objeto quadroHabilidade com os dados que serão cadastrados</param>
        void Cadastrar(QuadroHabilidade novoQuadroHabilidade);

        /// <summary>
        /// Atualiza quadro existente
        /// </summary>
        /// <param name="idQuadroHabilidade">ID do quadro que será atualizado</param>
        /// <param name="quadroHabilidadeAtualizado">Objeto quadro com as novas informações</param>
        void Atualizar(byte idQuadroHabilidade, QuadroHabilidade quadroHabilidadeAtualizado);

        /// <summary>
        /// Deleta um quadro existente
        /// </summary>
        /// <param name="idQuadroHabilidade">ID do quadro que será deletado</param>
        void Deletar(int idQuadroHabilidade);
    }
}
