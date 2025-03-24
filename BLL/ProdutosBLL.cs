using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data;

namespace BLL
{
    public class ProdutosBLL
    {
        //o nome do produto é obrigatório

        public void Incluir(ProdutoInformation produto)
        {
            if (produto.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório");
            }
            //E-mail é sempre com letras minúsculas
            produto.Nome = produto.Nome.ToLower();
            //se tudo está OK, chama a rotina para inserir
            ProdutosDAL obj = new ProdutosDAL();
            obj.Incluir(produto);
        }
        public void Alterar(ProdutoInformation produto)
        {
            if (produto.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório");
            }
            //E-mail é sempre com letras minúsculas
            produto.Nome = produto.Nome.ToLower();
            //se tudo está OK, chama a rotina para inserir o produto
            ProdutosDAL obj = new ProdutosDAL();
            obj.Alterar(produto);
        }
        public void Excluir(int codigo)
        {
            if (codigo < 1)
            {
                throw new Exception("Selecione um produto antes de excluí-lo");
            }
            ProdutosDAL obj = new ProdutosDAL();
            obj.Excluir(codigo);
        }
        public DataTable Listagem(string filtro)
        {
            ProdutosDAL obj = new ProdutosDAL();
            return obj.Listagem(filtro);
        }

    }
}
