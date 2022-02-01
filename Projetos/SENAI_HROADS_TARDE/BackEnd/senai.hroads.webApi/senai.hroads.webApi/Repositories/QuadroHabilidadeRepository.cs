using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class QuadroHabilidadeRepository : IQuadroHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(byte idQuadro, QuadroHabilidade quadroHabilidadeAtualizado)
        {
            QuadroHabilidade quadroHabilidadeBuscado = ctx.QuadroHabilidades.Find(idQuadro);

            if (quadroHabilidadeAtualizado.IdQuadro != null)
            {
                quadroHabilidadeBuscado.IdQuadro = quadroHabilidadeAtualizado.IdQuadro;

                ctx.QuadroHabilidades.Update(quadroHabilidadeBuscado);

                ctx.SaveChanges();
            }
        }

        public QuadroHabilidade BuscarPorId(int idQuadro)
        {
            return ctx.QuadroHabilidades.FirstOrDefault(c => c.IdQuadro == idQuadro);
        }

        public void Cadastrar(QuadroHabilidade novoQuadro)
        {
            ctx.QuadroHabilidades.Add(novoQuadro);
            ctx.SaveChanges();
        }

        public void Deletar(int idQuadro)
        {
            ctx.QuadroHabilidades.Remove(BuscarPorId(idQuadro));
            ctx.SaveChanges();
        }

        public List<QuadroHabilidade> Listar()
        {
            return ctx.QuadroHabilidades.ToList();
        }
    }
}
