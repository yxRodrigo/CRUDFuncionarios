using MySql.Data.MySqlClient;
namespace Database
{
    public class ConexaoBanco : IDisposable // Permite a liberação apropriada dos recursos associados a uma instância dessa classe
                                            // quando ela não for mais necessária.
    {
        private MySqlConnection conexaoDisposable;
        private string enderecoServidor;

        public ConexaoBanco()
        {
            string servidor = Environment.GetEnvironmentVariable("SERVIDOR_CRUD");
            string bancoDados = Environment.GetEnvironmentVariable("BANCO_DADOS_CRUD");
            string usuario = Environment.GetEnvironmentVariable("USUARIO_CRUD");
            string senha = Environment.GetEnvironmentVariable("SENHA_CRUD");

            enderecoServidor = $"server={servidor};user id={usuario};database={bancoDados};password={senha}";

            // Inicialize a conexão no construtor
            conexaoDisposable = new MySqlConnection(enderecoServidor);
            conexaoDisposable.Open();
        }

        public static string msgErro;

        #region Implementando Interface IDisposable
        public void Dispose() // Para liberar explicitamente recursos associados a uma instância da classe.
        {
            Dispose(true); // Para liberar recursos gerenciados, como a conexão
            GC.SuppressFinalize(this); // Para evitar a liberação duplicada de recursos pelo coletor de lixo.
        }

        protected virtual void Dispose(bool disposing) // Chamado pelo método Dispose acima
        {                                              // é onde a liberação real de recursos ocorre. 
            if (disposing)
            {
                // Liberar recursos gerenciados
                if (conexaoDisposable != null)
                {
                    conexaoDisposable.Close();
                    conexaoDisposable.Dispose();
                }
            }
        }
        #endregion

        public bool Create(string nome, string cpf, string email, string endereco)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(enderecoServidor))
                {
                    conexao.Open();
                    string comandoSql = "INSERT INTO funcionarios (nome, email, cpf, endereco) VALUES (@Nome, @Email, @CPF, @Endereco)";
                    MySqlCommand comando = new MySqlCommand(comandoSql, conexao);
                    comando.Parameters.AddWithValue("@Nome", nome);
                    comando.Parameters.AddWithValue("@Email", email);
                    comando.Parameters.AddWithValue("@CPF", cpf);
                    comando.Parameters.AddWithValue("@Endereco", endereco);
                    comando.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                msgErro = "Erro ao cadastrar funcionário: " + ex.Message;
                return false;
            }
        }

        public FuncionarioDataDTO Read(string cpf)
        {
            using (MySqlConnection connection = new MySqlConnection(enderecoServidor))
            {
                connection.Open();
                string query = "SELECT * FROM funcionarios WHERE cpf = @CPF";
                MySqlCommand comando = new MySqlCommand(query, connection);
                comando.Parameters.AddWithValue("@CPF", cpf);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        FuncionarioDataDTO funcionarioData = new FuncionarioDataDTO
                        {
                            ID = reader.GetInt32("ID"),
                            Nome = reader.GetString("Nome"),
                            Email = reader.GetString("Email"),
                            CPF = reader.GetString("CPF"),
                            Endereco = reader.GetString("Endereco")
                        };
                        return funcionarioData;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public bool Update(int funcionarioId, string nome, string cpf, string email, string endereco)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(enderecoServidor))
                {
                    conexao.Open();
                    string comandoSql = "UPDATE funcionarios SET nome = @Nome, cpf = @CPF, email = @Email, endereco = @Endereco WHERE id = @FuncionarioId";
                    MySqlCommand comando = new MySqlCommand(comandoSql, conexao);
                    comando.Parameters.AddWithValue("@FuncionarioId", funcionarioId);
                    comando.Parameters.AddWithValue("@Nome", nome);
                    comando.Parameters.AddWithValue("@CPF", cpf);
                    comando.Parameters.AddWithValue("@Email", email);
                    comando.Parameters.AddWithValue("@Endereco", endereco);
                    comando.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                msgErro = "Erro ao atualizar funcionário: " + ex.Message;
                return false;
            }
        }

        public bool Delete(int funcionarioId)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(enderecoServidor))
                {
                    conexao.Open();
                    string comandoSql = "DELETE FROM funcionarios WHERE id = @FuncionarioId";
                    MySqlCommand comando = new MySqlCommand(comandoSql, conexao);
                    comando.Parameters.AddWithValue("@FuncionarioId", funcionarioId);
                    comando.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                msgErro = "Erro ao deletar funcionário: " + ex.Message;
                return false;
            }
        }

        public bool ConsultaCPF(string cpf)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(enderecoServidor))
                {
                    conexao.Open();
                    string query = "SELECT COUNT(*) FROM funcionarios WHERE cpf = @CPF";
                    MySqlCommand comando = new MySqlCommand(query, conexao);
                    comando.Parameters.AddWithValue("@CPF", cpf);
                    int count = Convert.ToInt32(comando.ExecuteScalar());

                    // Se count for maior que 0, o CPF já existe no banco de dados
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao verificar CPF duplicado: " + ex.Message);
                return false;
            }
        }
    }
}