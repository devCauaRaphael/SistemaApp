using CrudApplication.Models;
using MySql.Data.MySqlClient;

namespace CrudApplication.Repositorios
{
        public class ProdutoRepositorio(IConfiguration configuration)
        {
            private readonly string _conexaoMySQL = configuration.GetConnectionString("ConexaoMySQL");

            public void CadastrarProduto(tbProduto produto)
            {
                using (var conexao = new MySqlConnection(_conexaoMySQL))
                {
                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into produto(NomeProduto, Descricao, Preco, Quantidade) values (@nomeProduto, @descricao, @preco, @quantidade)", conexao);
                    cmd.Parameters.Add("@nomeProduto", MySqlDbType.VarChar).Value = produto.NomeProduto;
                    cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = produto.Descricao;
                    cmd.Parameters.Add("@preco", MySqlDbType.Decimal).Value = produto.Preco;
                    cmd.Parameters.Add("@quantidade", MySqlDbType.Int32).Value = produto.Quantidade;
                    cmd.ExecuteNonQuery();
                    conexao.Close();
                }
            }
      }
}
