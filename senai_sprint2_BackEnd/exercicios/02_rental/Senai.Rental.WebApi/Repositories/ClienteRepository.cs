using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string stringConexao = "Data Source=DESKTOP-773T9AI\\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";

        public void AtualizarIdCorpo(ClienteDomain clienteAtualizado)
        {
            if (clienteAtualizado.nomeCliente != null || clienteAtualizado.sobrenomeCliente != null || clienteAtualizado.CNH != null || clienteAtualizado.idCliente > 0)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE CLIENTE SET nomeCliente = @nomeCliente, sobrenomeCliente = @sobrenomeCliente, CNH = @CNH WHERE idCliente = @idCliente";
                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody))
                    {
                        cmd.Parameters.AddWithValue("@nomeCliente", clienteAtualizado.nomeCliente);
                        cmd.Parameters.AddWithValue("@sobrenomeCliente", clienteAtualizado.sobrenomeCliente);
                        cmd.Parameters.AddWithValue("@CNH", clienteAtualizado.CNH);
                        cmd.Parameters.AddWithValue("@idCliente", clienteAtualizado.idCliente);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        public ClienteDomain BuscarPorId(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT nomeCliente, sobrenomeCliente, CNH FROM CLIENTE WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        ClienteDomain clienteEncontrado = new ClienteDomain
                        {
                            nomeCliente = (rdr[0]).ToString(),
                            sobrenomeCliente = (rdr[1]).ToString(),
                            CNH = (rdr[2]).ToString()

                        };
                        return clienteEncontrado;
                    }
                }
                return null;
            }
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"INSERT INTO CLIENTE (nomeCliente, sobrenomeCliente, CNH) VALUES (@nomeCliente,@sobrenomeCliente,@CNH)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@CNH", novoCliente.CNH);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @idCliente";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaCliente = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT nomeCliente, sobrenomeCliente, CNH FROM CLIENTE";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain
                        {
                            nomeCliente = (rdr[0]).ToString(),
                            sobrenomeCliente = (rdr[1]).ToString(),
                            CNH = (rdr[2]).ToString()

                        };
                            
                        listaCliente.Add(cliente);

                    }
                        

                }

            }
            return listaCliente;

        }
    }
}
