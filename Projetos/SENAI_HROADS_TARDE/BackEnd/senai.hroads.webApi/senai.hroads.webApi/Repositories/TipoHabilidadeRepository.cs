using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(byte idTipoHabilidade, TipoHabilidade tipoHabilidadeAtualizado)
        {
            TipoHabilidade tipoHabilidade = ctx.TipoHabilidades.Find(idTipoHabilidade);

            if (tipoHabilidadeAtualizado.NomeTipo != null)
            {
                tipoHabilidade.NomeTipo = tipoHabilidadeAtualizado.NomeTipo;

                ctx.TipoHabilidades.Update(tipoHabilidadeAtualizado);

                ctx.SaveChanges();
            }
        }

        public TipoHabilidade BuscarPorId(int idTipoHabilidade)
        {
            return ctx.TipoHabilidades.FirstOrDefault(h => h.IdTipo == idTipoHabilidade);
        }

        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            ctx.TipoHabilidades.Add(novoTipoHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int idTipoHabilidade)
        {
            ctx.TipoHabilidades.Remove(BuscarPorId(idTipoHabilidade));
            ctx.SaveChanges();
        }

        public List<TipoHabilidade> Listar()
        {
           return ctx.TipoHabilidades.ToList();
        }

        public List<TipoHabilidade> ListarComHabilidade()
        {
            return ctx.TipoHabilidades.Include(h => h.Habilidades).ToList();
        }
    }
}
