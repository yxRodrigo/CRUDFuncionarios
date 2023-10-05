using Database;

namespace Business
{
    namespace Business
    {
        public class BusinessFuncionario
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Endereco { get; set; }
            public string Cpf { get; set; }

            public BusinessFuncionario()
            {
            }

            public BusinessFuncionario(int id, string nome, string email, string endereco, string cpf)
            {
                Id = id;
                Nome = nome;
                Email = email;
                Endereco = endereco;
                Cpf = cpf;
            }
        }
    }
}