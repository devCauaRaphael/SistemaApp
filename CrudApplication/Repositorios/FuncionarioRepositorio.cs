using CrudApplication.Models;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CrudApplication.Repositorios
{
    public class FuncionarioRepositorio(IConfiguration configuration)
    {
        private readonly string _conexaoMySQL = configuration.GetConnectionString("ConexaoMySQL");

        public void CadastrarFuncionario(tbFuncionario funcionario)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into funcionario(Nome, Email, Senha) values (@nome, @email, @senha)", conexao);
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = funcionario.Nome;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = funcionario.Email;
                cmd.Parameters.Add("@senha", MySqlDbType.String).Value = funcionario.Senha;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }
        public bool AtualizarFuncionario(tbFuncionario funcionario)
        {
            try
            {
                using (var conexao = new MySqlConnection(_conexaoMySQL))
                {
                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand("Update funcionario set Nome=@nome, Email=@email, Senha=@senha" + " where IdFuncionario=@codigo", conexao);
                    cmd.Parameters.Add("@codigo", MySqlDbType.Int32).Value = funcionario.IdFuncionario;
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = funcionario.Nome;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = funcionario.Email;
                    cmd.Parameters.Add("@senha", MySqlDbType.String).Value = funcionario.Senha;
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    return linhasAfetadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar funcionario: {ex.Message}");
                return false;
            }
        }
    }

}
