using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IEstudioRepository
    {
        List<EstudioDomain> ListarTodos();

        EstudioDomain BuscarPorId(int idEstudio);

        void Cadastrar(EstudioDomain novoEstudio);

        void AtualizarIdCorpo(EstudioDomain estudioAtualizado);

        void Deletar(int idEstudio);
    }
}
