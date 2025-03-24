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
    public class VendasBLL
    {
        public void Incluir(VendaInformation venda)
        {
            if (venda.Data.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório");
            }
            //E-mail é sempre com letras minúsculas
            venda.Nome = venda.Nome.ToLower();
            //se tudo está OK, chama a rotina para inserir
            ProdutosDAL obj = new ProdutosDAL();
            VendaInformation venda1 = venda;
            obj.Incluir(venda);
        }
        public void Alterar(VendaInformation venda)
        {
            if (venda.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório");
            }
            //E-mail é sempre com letras minúsculas
            venda.Nome = venda.Nome.ToLower();
            //se tudo está OK, chama a rotina para inserir o produto
            ProdutosDAL obj = new ProdutosDAL();
            obj.Alterar(venda);
        }
        public void Excluir(int codigo)
        {
            if (codigo < 1)
            {
                throw new Exception("Selecione um produto antes de excluí-lo");
            }
            VendasDAL obj = new VendasDAL();
            obj.Excluir(codigo);
        }
        public DataTable Listagem(string filtro)
        {
            VendasDAL obj = new VendasDAL();
            return obj.Listagem(filtro);
        }

    }
}
    }
}
