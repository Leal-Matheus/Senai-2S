using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{

    public class VeiculoRepository : IVeiculoRepository

    {
        private string stringConexao = @"Data Source=DESKTOP-773T9AI\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";
        public void AtualizarIdCorpo(VeiculoDomain veiculolAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "UPDATE VEICULO SET idEmpresa = @idEmpresa, idModelo = @idModelo, placa = @placa WHERE idVeiculo = @idVeiculo";
                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    cmd.Parameters.AddWithValue("@idEmpresa", veiculolAtualizado.idEmpresa);
                    cmd.Parameters.AddWithValue("@idModelo", veiculolAtualizado.idModelo);
                    cmd.Parameters.AddWithValue("@placa", veiculolAtualizado.placa);
                    cmd.Parameters.AddWithValue("@idVeiculo", veiculolAtualizado.idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = @"SELECT EMPRESA.nomeEmpresa,
	             MODELO.nomeModelo, MARCA.nomeMarca, VEICULO.placa FROM VEICULO VEICULO
                 INNER JOIN EMPRESA 
                 ON VEICULO.idEmpresa = EMPRESA.idEmpresa
                 INNER JOIN MODELO
                 ON VEICULO.idModelo = MODELO.idModelo
                 INNER JOIN MARCA
	             ON MODELO.idMarca = MARCA.idMarca
                 WHERE idVeiculo = @idVeiculo";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculoDomain veiculoEncontrado = new VeiculoDomain
                        {
                            placa = rdr[3].ToString(),
                            empresa = new EmpresaDomain
                            {
                                nomeEmpresa = rdr[0].ToString()
                            },
                            modelo = new ModeloDomain
                            {
                                nomeModelo = rdr[1].ToString(),
                            }
                        };
                        return veiculoEncontrado;
                    }
                    return null;
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM VEICULO WHERE idVeiculo = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO VEICULO (idEmpresa,idModelo,placa) VALUES (@idEmpresa,@idModelo,@placa)";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idEmpresa", novoVeiculo.idEmpresa);
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@placa", novoVeiculo.placa);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"SELECT EMPRESA.nomeEmpresa,
	             MODELO.nomeModelo, MARCA.nomeMarca, VEICULO.placa FROM VEICULO VEICULO
                 INNER JOIN EMPRESA 
                 ON VEICULO.idEmpresa = EMPRESA.idEmpresa
                 INNER JOIN MODELO
                 ON VEICULO.idModelo = MODELO.idModelo
                 INNER JOIN MARCA
	             ON MODELO.idMarca = MARCA.idMarca";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain
                        {
                            placa = rdr[3].ToString(),
                            empresa = new EmpresaDomain
                            {
                                nomeEmpresa = rdr[0].ToString()
                            },
                            modelo = new ModeloDomain
                            {
                                nomeModelo = rdr[1].ToString(),
                                marca = new MarcaDomain
                                {
                                    noeMarca = rdr[2].ToString()
                                }
                            }
                        };
                        listaVeiculos.Add(veiculo);
                    }
                }
            }
            return listaVeiculos;
        }
    }
}