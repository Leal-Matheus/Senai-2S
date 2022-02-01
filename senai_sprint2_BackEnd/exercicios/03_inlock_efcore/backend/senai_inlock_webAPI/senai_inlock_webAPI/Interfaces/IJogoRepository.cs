using senai_inlock_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Interfaces
{
    interface IJogoRepository
    {
        List<Jogo> Listar();

        Jogo BuscarPorId(int idJogo);

        void Cadastrar(Jogo novoJogo);

        void Atualizar(int idJogo, Jogo jogoAtualizado);

        void Deletar(int idJogo);

    }
}
