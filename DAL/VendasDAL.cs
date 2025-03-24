using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace DAL
{
    public class VendasDAL
    {
        public void Incluir(VendaInformation venda)
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
                cmd.CommandText = "insere_venda";

                //parâmetros da stored procedure
                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pdata = new SqlParameter("@data", SqlDbType.DateTime);
                pdata.Value = venda.Data;
                cmd.Parameters.Add(pdata);

                SqlParameter pquantidade = new SqlParameter("@quantidade", SqlDbType.Int);
                pquantidade.Value = venda.Quantidade;
                cmd.Parameters.Add(pquantidade);

                SqlParameter pfaturado = new SqlParameter("@faturado", SqlDbType.Bit);
                pfaturado.Value = venda.Faturado;
                cmd.Parameters.Add(pfaturado);

                SqlParameter pcodigocliente = new SqlParameter("@codigocliente", SqlDbType.Int);
                pcodigocliente.Value = venda.Codigocliente;
                cmd.Parameters.Add(pcodigocliente);

                SqlParameter pcodigoproduto = new SqlParameter("@codicoproduto", SqlDbType.Int);
                pcodigoproduto.Value = venda.Codigoproduto;
                cmd.Parameters.Add(pcodigoproduto);

                cn.Open();
                cmd.ExecuteNonQuery();

                venda.Codigo = (Int32)cmd.Parameters["@codigo"].Value;

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
        public void Alterar(VendaInformation venda)
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
                cmd.CommandText = "insere_venda";

                //parâmetros da stored procedure
                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pdata = new SqlParameter("@data", SqlDbType.DateTime);
                pdata.Value = venda.Data;
                cmd.Parameters.Add(pdata);

                SqlParameter pquantidade = new SqlParameter("@quantidade", SqlDbType.Int);
                pquantidade.Value = venda.Quantidade;
                cmd.Parameters.Add(pquantidade);

                SqlParameter pfaturado = new SqlParameter("@faturado", SqlDbType.Bit);
                pfaturado.Value = venda.Faturado;
                cmd.Parameters.Add(pfaturado);

                SqlParameter pcodigocliente = new SqlParameter("@codigocliente", SqlDbType.Int);
                pcodigocliente.Value = venda.Codigocliente;
                cmd.Parameters.Add(pcodigocliente);

                SqlParameter pcodigoproduto = new SqlParameter("@codigoproduto", SqlDbType.Int);
                pcodigoproduto.Value = venda.Codigoproduto;
                cmd.Parameters.Add(pcodigoproduto);

                cn.Open();
                cmd.ExecuteNonQuery();

                venda.Codigo = (Int32)cmd.Parameters["@codigo"].Value;

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
                da.SelectCommand.CommandText = "seleciona_vendas";
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
    
