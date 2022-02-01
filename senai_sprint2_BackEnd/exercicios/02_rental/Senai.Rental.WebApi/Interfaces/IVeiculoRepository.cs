using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IVeiculoRepository
    {
        List<VeiculoDomain> ListarTodos();

        VeiculoDomain BuscarPorId(int idVeiculo);

        void Cadastrar(VeiculoDomain novoVeiculo);

        void AtualizarIdCorpo(VeiculoDomain veiculoAtualizado);

        void Deletar(int idVeiculo);
    }
}
