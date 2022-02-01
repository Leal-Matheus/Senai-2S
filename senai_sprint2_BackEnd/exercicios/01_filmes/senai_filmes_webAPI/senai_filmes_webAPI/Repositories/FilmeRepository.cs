using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String com as informações para conectar no servidor
        /// </summary>
        private string stringConexao = "Data Source=NOTE0113H3\\SQLEXPRESS; initial catalog=catalogo; user Id=sa; pwd=Senai@132";
        public void AtualizarIdCorpo(FilmeDomain filmeAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, FilmeDomain filmeAtualizado)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int idFilme)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme a ser cadastrado</param>
        public void Cadastrar(FilmeDomain novoFilme)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert;
                if (novoFilme.idGenero > 0)
                {
                    queryInsert = $"INSERT INTO FILME (idGenero, nomeFilme) VALUES ({novoFilme.idGenero},'{novoFilme.nomeFilme}')";
                }
                else 
                {
                    queryInsert = $"INSERT INTO FILME (nomeFilme) VALUES ('{novoFilme.nomeFilme}')";
                }
                

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdGenero)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                //Comando a ser rodado no banco de dados
                string querySelectAll = "SELECT idFilme, isnull(FILME.idGenero,0) idGenero, nomeFilme, isnull(nomeGenero,'não cadastrado') 'nome do genero' FROM FILME LEFT JOIN GENERO ON FILME.idGenero = GENERO.idGenero";

                //abre conexão com o banco de dados
                con.Open();

                //Declara um SqlDataReader para percorrer o banco de dados
                SqlDataReader rdr;

                //Declara um SqlCommand passando a query e a conexão como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registro para serem lidos no rdr o laço se repete
                    while (rdr.Read())
                    {
                        //Cria o objeto FilmeDomain com os atributos já alocados
                        FilmeDomain filme = new FilmeDomain()
                        {
                            idFilme = Convert.ToInt32(rdr[0]),
                            idGenero = Convert.ToInt32(rdr[1]),
                            nomeFilme = rdr[2].ToString(),
                            genero = new GeneroDomain()
                            {
                                idGenero = Convert.ToInt32(rdr[1]),
                                nomeGenero = (rdr[3]).ToString()
                            }

                    };

                        listaFilmes.Add(filme);
                    }
                }
            }
            return listaFilmes;
        }
    }
}
