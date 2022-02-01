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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(byte idHabilidade, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(idHabilidade);

            if (habilidadeAtualizada.Habilidade1 != null)
            {
                habilidadeBuscada.Habilidade1 = habilidadeAtualizada.Habilidade1;

                ctx.Habilidades.Update(habilidadeBuscada);

                ctx.SaveChanges();
            }
        }

        public Habilidade BuscarPorId(int idHabilidade)
        {
            return ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == idHabilidade);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int idHabilidade)
        {
            ctx.Habilidades.Remove(BuscarPorId(idHabilidade));
            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.ToList();
        }
        public List<Habilidade> ListarComHabilidades()
        {
            return ctx.Habilidades.Include(qh => qh.QuadroHabilidades).ToList();
        }
    }
}
