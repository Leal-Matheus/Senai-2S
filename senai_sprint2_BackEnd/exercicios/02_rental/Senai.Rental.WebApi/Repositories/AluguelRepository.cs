using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-773T9AI\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";
        public void AtualizarIdCorpo(AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "UPDATE ALUGUEL SET idCliente = @idCliente, idVeiculo = @idVeiculo, dataAluguel = @dataAluguel, dataDevolucao = @dataDevolucao WHERE idAluguel = @idAluguel";
                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", aluguelAtualizado.idVeiculo);
                    cmd.Parameters.AddWithValue("@dataAluguel", aluguelAtualizado.DataRetirada);
                    cmd.Parameters.AddWithValue("@dataDevolucao", aluguelAtualizado.DataDevolucao);
                    cmd.Parameters.AddWithValue("@idCliente", aluguelAtualizado.idCliente);
                    cmd.Parameters.AddWithValue("@idAluguel", aluguelAtualizado.idAluguel);
                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = @"SELECT dataRetirada, 
                 dataDevolucao, nomeCliente, sobrenomeCliente, placa, nomeModelo    FROM ALUGUEL
                 INNER JOIN CLIENTE 
                 ON ALUGUEL.idCliente = CLIENTE.idCliente
                 INNER JOIN VEICULO
                 ON ALUGUEL.idVeiculo = VEICULO.idVeiculo
                 INNER JOIN MODELO
                 ON VEICULO.idModelo = MODELO.idModelo
                 WHERE idAluguel = @idAluguel";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain aluguelEncontrado = new AluguelDomain
                        {
                            DataRetirada = Convert.ToDateTime(rdr[0]),
                            DataDevolucao = Convert.ToDateTime(rdr[1]),

                            cliente = new ClienteDomain
                            {
                                nomeCliente = rdr[2].ToString(),
                                sobrenomeCliente = rdr[3].ToString()
                            },

                            veiculo = new VeiculoDomain
                            {
                                placa = rdr[4].ToString(),
                                modelo = new ModeloDomain
                                {
                                    nomeModelo = rdr[5].ToString(),
                                }
                            }
                        };
                        return aluguelEncontrado;
                    }
                    return null;
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO ALUGUEL (idCliente, idVeiculo, dataAluguel, dataDevolucao) VALUES (@idCliente, @idVeiculo, @dataAluguel, @dataDevolucao)";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@dataAluguel", novoAluguel.DataRetirada);
                    cmd.Parameters.AddWithValue("@dataDevolucao", novoAluguel.DataDevolucao);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"SELECT dataRetirada, 
                 dataDevolucao, nomeCliente, sobrenomeCliente, placa, nomeModelo FROM ALUGUEL
                 INNER JOIN CLIENTE 
                 ON ALUGUEL.idCliente = CLIENTE.idCliente
                 INNER JOIN VEICULO
                 ON ALUGUEL.idVeiculo = VEICULO.idVeiculo
                 INNER JOIN MODELO
                 ON VEICULO.idModelo = MODELO.idModelo";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain
                        {
                            DataRetirada = Convert.ToDateTime(rdr[0]),
                            DataDevolucao = Convert.ToDateTime(rdr[1]),

                            cliente = new ClienteDomain
                            {
                                nomeCliente = rdr[2].ToString(),
                                sobrenomeCliente = rdr[3].ToString()
                            },

                            veiculo = new VeiculoDomain
                            {
                                placa = rdr[4].ToString(),
                                modelo = new ModeloDomain
                                {
                                    nomeModelo = rdr[5].ToString(),
                                }
                            }
                        };

                        listaAlugueis.Add(aluguel);
                    }
                }
            }
            return listaAlugueis;
        }
    }
}

    