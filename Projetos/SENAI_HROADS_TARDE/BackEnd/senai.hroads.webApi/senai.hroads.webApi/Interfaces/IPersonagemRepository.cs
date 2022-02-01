using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Lista todos os Personagems
        /// </summary>
        /// <returns>Uma lista de personagens</returns>
        List<Personagem> Listar();

        /// <summary>
        /// Busca um personagem através do seu id
        /// </summary>
        /// <param name="idPersonagem">ID do personagem que será buscado</param>
        /// <returns>Um personagem encontrado</returns>
        Personagem BuscarPorId(int idPersonagem);

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto personagem com os dados que serão cadastrados</param>
        void Cadastrar(Personagem novoPersonagem);

        /// <summary>
        /// Atualiza um personagem existente
        /// </summary>
        /// <param name="idPersonagem">ID do personagem que será atualizado</param>
        /// <param name="personagemAtualizado">Objeto personagem com as novas informações</param>
        void Atualizar(byte idPersonagem, Personagem personagemAtualizado);

        /// <summary>
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="idPersonagem">ID do Personagem que será deletado</param>
        void Deletar(int idPersonagem);
    }
}
