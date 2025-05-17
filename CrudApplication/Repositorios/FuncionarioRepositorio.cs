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
                MySqlCommand cmd = new MySqlCommand("insert into produto(Nome, Email, Senha) values (@nome, @email, @senha)", conexao);
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = funcionario.Nome;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = funcionario.Email;
                cmd.Parameters.Add("@senha", MySqlDbType.String).Value = funcionario.Senha;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }
    }
}
