using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades</returns>
        List<Habilidade> Listar();

        /// <summary>
        /// Busca uma habildade através do seu id
        /// </summary>
        /// <param name="idHabilidade">ID da habilidade que será buscado</param>
        /// <returns>Uma habilidade encontrada</returns>
        Habilidade BuscarPorId(int idHabilidade);

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="idHabilidade">Objeto habilidade com os dados que serão cadastrados</param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="idHabilidade">ID da habilidade que será atualizado</param>
        /// <param name="habilidadeAtualizadad">Objeto habilidade com as novas informações</param>
        void Atualizar(byte idHabilidade, Habilidade habilidadeAtualizada);

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="idHabilidade">ID da habilidade que será deletado</param>
        void Deletar(int idHabilidade);
        List<Habilidade> ListarComHabilidades();
    }
}
