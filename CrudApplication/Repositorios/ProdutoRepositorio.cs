using CrudApplication.Models;
using MySql.Data.MySqlClient;
using System.Data;

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
                    MySqlCommand cmd = new MySqlCommand("insert into tbProduto(NomeProduto, Descricao, Preco, Quantidade) values (@nomeProduto, @descricao, @preco, @quantidade)", conexao);
                    cmd.Parameters.Add("@nomeProduto", MySqlDbType.VarChar).Value = produto.NomeProduto;
                    cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = produto.Descricao;
                    cmd.Parameters.Add("@preco", MySqlDbType.Decimal).Value = produto.Preco;
                    cmd.Parameters.Add("@quantidade", MySqlDbType.Int32).Value = produto.Quantidade;
                    cmd.ExecuteNonQuery();
                    conexao.Close();
                }
            }
        public bool AtualizarProduto(tbProduto produto)
        {
            try
            {
                using (var conexao = new MySqlConnection(_conexaoMySQL))
                {
                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand("Update tbPoduto set NomeProduto=@nomeProduto, Descricao=@descricao, Preco=@preco, Quantidade=@quantidade" + " where IdProduto=@codigo", conexao);
                    cmd.Parameters.Add("@codigo", MySqlDbType.Int32).Value = produto.IdProduto;
                    cmd.Parameters.Add("@nomeProduto", MySqlDbType.VarChar).Value = produto.NomeProduto;
                    cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = produto.Descricao;
                    cmd.Parameters.Add("@preco", MySqlDbType.Decimal).Value = produto.Preco;
                    cmd.Parameters.Add("@quantidade", MySqlDbType.Int32).Value = produto.Quantidade;
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    return linhasAfetadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar produto: {ex.Message}");
                return false;
            }
        }
        public IEnumerable<tbProduto> TodosProdutos()
        {
            List<tbProduto> Produtolist = new List<tbProduto>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbProduto", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);
                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Produtolist.Add(
                        new tbProduto
                        {
                            IdProduto = Convert.ToInt32(dr["IdProduto"]),
                            NomeProduto = ((string)dr["NomeProduto"]),
                            Descricao = ((string)dr["Descricao"]),
                            Preco = ((decimal)dr["Preco"]),
                            Quantidade = Convert.ToInt32(dr["Quantidade"]),
                        });
                }

                return Produtolist;
            }

        }
        public tbProduto ObterProduto(int Codigo)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbProduto where IdProduto=@codigo", conexao);
                cmd.Parameters.AddWithValue("@codigo", Codigo);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;
                tbProduto produto = new tbProduto();

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    produto.IdProduto = Convert.ToInt32(dr["IdProduto"]);
                    produto.NomeProduto = ((string)dr["NomeProduto"]);
                    produto.Descricao = ((string)dr["Descricao"]);
                    produto.Preco = (decimal)(dr["Preco"]);
                    produto.Quantidade = Convert.ToInt32(dr["Quantidade"]);
                }
                return produto;
            }
        }
        public void ExcluirProduto(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("delete from tbProduto where IdProduto=@codigo", conexao);
                cmd.Parameters.AddWithValue("@codigo", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }
    }
}
