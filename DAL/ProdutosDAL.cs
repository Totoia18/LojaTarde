using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Modelos;

namespace DAL
{
    public class ProdutosDAL
    {
            public void Incluir(ProdutoInformation produto)
            {
                //conexão
                SqlConnection cn = new SqlConnection();
                try
                {
                    cn.ConnectionString = Dados.StringDeConexao();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;

                    //define que usaremos stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //executar a stored procedure
                    cmd.CommandText = "insere_produto";

                    //parâmetros da stored procedure
                    SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                    pcodigo.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(pcodigo);

                    SqlParameter pnome = new SqlParameter("@nome", SqlDbType.VarChar, 100);
                    pnome.Value = produto.Nome;
                    cmd.Parameters.Add(pnome);

                    SqlParameter ppreco = new SqlParameter("@preco", SqlDbType.Decimal, 80);
                    ppreco.Value = produto.Preco;
                    cmd.Parameters.Add(ppreco);

                    SqlParameter pestoque = new SqlParameter("@estoque", SqlDbType.Decimal, 100);
                    pestoque.Value = produto.Estoque;
                    cmd.Parameters.Add(pestoque);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    produto.Codigo = (Int32)cmd.Parameters["@codigo"].Value;

                }
                catch (Exception ex)
                {
                    throw new Exception("Servidor SQL erro: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }

            }
            public void Alterar(ProdutoInformation produto)
            {
                //conexão
                SqlConnection cn = new SqlConnection();
                try
                {
                    cn.ConnectionString = Dados.StringDeConexao();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;

                    //define que usaremos stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //executar a stored procedure
                    cmd.CommandText = "insere_produto";

                    //parâmetros da stored procedure
                    SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                    pcodigo.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(pcodigo);

                    SqlParameter pnome = new SqlParameter("@nome", SqlDbType.VarChar, 100);
                    pnome.Value = produto.Nome;
                    cmd.Parameters.Add(pnome);

                    SqlParameter ppreco= new SqlParameter("@preco", SqlDbType.Decimal, 80);
                    ppreco.Value = produto.Preco;
                    cmd.Parameters.Add(ppreco);

                    SqlParameter pestoque = new SqlParameter("@estoque", SqlDbType.Decimal, 100);
                    pestoque.Value = produto.Estoque;
                    cmd.Parameters.Add(pestoque);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                   produto.Codigo = (Int32)cmd.Parameters["@codigo"].Value;

                }
                catch (Exception ex)
                {
                    throw new Exception("Servidor SQL erro: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }

            }
            public void Excluir(int codigo)
            {
                //conexão
                SqlConnection cn = new SqlConnection();
                try
                {
                    cn.ConnectionString = Dados.StringDeConexao();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "exclui_produto";

                    //parâmetros da stored procedure
                    SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                    pcodigo.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(pcodigo);

                    cn.Open();
                    int resultado = cmd.ExecuteNonQuery();
                    if (resultado != 1)
                    {
                        throw new Exception("Nãõ foi possivel excluir o cliente " + codigo);
                    }
                }

                catch (Exception ex)
                {
                    throw new Exception("Servidor SQL erro:  " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }

            }
            public DataTable Listagem(string filtro)
            {
                SqlConnection cn = new SqlConnection();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                try
                {
                    cn.ConnectionString = Dados.StringDeConexao();
                    //adapter
                    da.SelectCommand = new SqlCommand();
                    da.SelectCommand.CommandText = "seleciona_cliente";
                    da.SelectCommand.Connection = cn;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //parâmetro filtro
                    SqlParameter pfiltro;
                    pfiltro = da.SelectCommand.Parameters.Add("@filtro", SqlDbType.Text);
                    pfiltro.Value = filtro;
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }

            }

        }
    }



