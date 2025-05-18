using CrudApplication.Models;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

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

                bool duplicado = false;
                MySqlCommand cmd = new MySqlCommand("select * from tbFuncionario where Email=@email", conexao);
                cmd.Parameters.AddWithValue("@email", funcionario.Email);
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        duplicado = true;
                    }
                }
                if (duplicado)
                {   
                    
                    Console.WriteLine("email já existente");
                }
                else
                {

                    MySqlCommand cmdInsert = new MySqlCommand("insert into tbFuncionario(Nome, Email, Senha) values (@nome, @email, @senha)", conexao);
                    cmdInsert.Parameters.Add("@nome", MySqlDbType.VarChar).Value = funcionario.Nome;
                    cmdInsert.Parameters.Add("@email", MySqlDbType.VarChar).Value = funcionario.Email;
                    cmdInsert.Parameters.Add("@senha", MySqlDbType.String).Value = funcionario.Senha;
                    cmdInsert.ExecuteNonQuery();
                }
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
                    MySqlCommand cmd = new MySqlCommand("Update tbFuncionario set  Email=@email, Senha=@senha" + " where IdFuncionario=@codigo", conexao);
                    cmd.Parameters.Add("@codigo", MySqlDbType.Int32).Value = funcionario.IdFuncionario;
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
        public IEnumerable<tbFuncionario> TodosFuncionarios()
        {
            List<tbFuncionario> Funcionariolist = new List<tbFuncionario>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbFuncionario", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);
                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Funcionariolist.Add(
                        new tbFuncionario
                        {
                            IdFuncionario = Convert.ToInt32(dr["IdFuncionario"]),
                            Nome = ((string)dr["Nome"]),
                            Email = ((string)dr["Email"]),
                            Senha = ((string)dr["Senha"]),
                        });
                }

                return Funcionariolist;
            }
        }
        public tbFuncionario ObterFuncionarioPorEmail( string email)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbFuncionario where Email=@email", conexao);
                cmd.Parameters.AddWithValue("@email", email);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;
                tbFuncionario funcionario = new tbFuncionario();

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    funcionario.Senha = (string)(dr["Senha"]);
                    funcionario.Email = (string)(dr["Email"]);
                }
                return funcionario;
            }
        }
        
        public tbFuncionario ObterFuncionarioPorId(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbFuncionario where IdFuncionario=@id", conexao);
                cmd.Parameters.AddWithValue("@id",id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;
                tbFuncionario funcionario = new tbFuncionario();

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    funcionario.IdFuncionario = Convert.ToInt32(dr["IdFuncionario"]);
                    funcionario.Nome = ((string)dr["Nome"]);
                    funcionario.Email = ((string)dr["Email"]);
                   funcionario.Senha = (string)(dr["Senha"]);
                }
                return funcionario;
            }
        }
        public void ExcluirFuncionario(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("delete from tbFuncionario where IdFuncionario=@codigo", conexao);
                cmd.Parameters.AddWithValue("@codigo", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }
   
    }
}
