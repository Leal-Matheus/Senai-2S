using senai_inlock_webAPI.Contexts;
using senai_inlock_webAPI.Domains;
using senai_inlock_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int idJogo, Jogo jogoAtualizado)
        {
            Jogo jogoBuscado = ctx.Jogos.Find(idJogo);
            if (jogoAtualizado.NomeJogo != null)
            {
                jogoBuscado.NomeJogo = jogoAtualizado.NomeJogo;

                ctx.Jogos.Update(jogoBuscado);

                ctx.SaveChanges();
            }
        }

        public Jogo BuscarPorId(int idJogo)
        {
            return ctx.Jogos.FirstOrDefault(e => e.IdJogo == idJogo);
        }

        public void Cadastrar(Jogo novoJogo)
        {
            ctx.Jogos.Add(novoJogo);

            ctx.SaveChanges();
        }

        public void Deletar(int idJogo)
        {
            ctx.Jogos.Remove(BuscarPorId(idJogo));

            ctx.SaveChanges();
        }

        public List<Jogo> Listar()
        {
            return ctx.Jogos.ToList();
        }
    }
}
