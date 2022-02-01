using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os Tipos de habilidade
        /// </summary>
        /// <returns>Uma lista de tipos de habilidade</returns>
        List<TipoHabilidade> Listar();

        /// <summary>
        /// Busca um tipo de habilidade através do seu id
        /// </summary>
        /// <param name="idTipoHabilidade">ID do tipo de habilidade que será buscado</param>
        /// <returns>Um tipo de habilidade encontrado</returns>
        TipoHabilidade BuscarPorId(int idTipoHabilidade);

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto tipoHabilidade com os dados que serão cadastrados</param>
        void Cadastrar(TipoHabilidade novoTipoHabilidade);

        /// <summary>
        /// Atualiza um Tipo de habilidade existente
        /// </summary>
        /// <param name="idTipoHabilidade">ID do tipo de habilidade que será atualizado</param>
        /// <param name="tipoHabilidadeAtualizado">Objeto tipo de habilidade com as novas informações</param>
        void Atualizar(byte idTipoHabilidade, TipoHabilidade tipoHabilidadeAtualizado);

        /// <summary>
        /// Deleta um tipo de habilidade existente
        /// </summary>
        /// <param name="idTipoHabilidade">ID do tipo de habilidade que será deletado</param>
        void Deletar(int idTipoHabilidade);

        List<TipoHabilidade> ListarComHabilidade();
    }
}
