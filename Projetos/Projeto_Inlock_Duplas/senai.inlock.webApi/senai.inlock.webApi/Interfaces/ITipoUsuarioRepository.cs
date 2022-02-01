using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> ListarTodos();

        TipoUsuarioDomain BuscarPorId(int idTipoUsuario);

        void Cadastrar(TipoUsuarioDomain novoTipoUsuario);

        void AtualizarIdCorpo(TipoUsuarioDomain TipoUsuarioAtualizado);

        void Deletar(int idTipoUsuario);
    }
}
