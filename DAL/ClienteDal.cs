﻿using System.Data;
using Microsoft.Data.SqlClient;
using Modelos;


namespace DAL
{
    public class ClienteDal
    {
        public void Incluir(ClienteInformation cliente)
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
                cmd.CommandText = "insere_cliente";

                //parâmetros da stored procedure
                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.VarChar, 100);
                pnome.Value = cliente.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pemail = new SqlParameter("@email", SqlDbType.VarChar, 80);
                pemail.Value = cliente.Email;
                cmd.Parameters.Add(pemail);

                SqlParameter ptelefone = new SqlParameter("@telefone", SqlDbType.VarChar, 100);
                ptelefone.Value = cliente.Telefone;
                cmd.Parameters.Add(ptelefone);

                cn.Open();
                cmd.ExecuteNonQuery();

                cliente.Codigo = (Int32)cmd.Parameters["@codigo"].Value;

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
        public void Alterar(ClienteInformation cliente)
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
                cmd.CommandText = "insere_cliente";

                //parâmetros da stored procedure
                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.VarChar, 100);
                pnome.Value = cliente.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pemail = new SqlParameter("@email", SqlDbType.VarChar, 80);
                pemail.Value = cliente.Email;
                cmd.Parameters.Add(pemail);

                SqlParameter ptelefone = new SqlParameter("@telefone", SqlDbType.VarChar, 100);
                ptelefone.Value = cliente.Telefone;
                cmd.Parameters.Add(ptelefone);

                cn.Open();
                cmd.ExecuteNonQuery();

                cliente.Codigo = (Int32)cmd.Parameters["@codigo"].Value;

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
                cmd.CommandText = "exclui_cliente";

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