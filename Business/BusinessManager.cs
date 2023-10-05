using Business.Business;
using Database;

namespace Business
{
    public class BusinessManager
    {
        public string msg;
        public int Id;

        public bool CadastrarFuncionario(string nome, string cpf, string email, string endereco)
        {
            using (ConexaoBanco conexaoBanco = new ConexaoBanco())
            {
                if (conexaoBanco.Create(nome, cpf, email, endereco))
                {
                    msg = "Funcionário cadastrado com sucesso!";
                    return true;
                }
                else
                {
                    msg = ConexaoBanco.msgErro;
                    return false;
                }
            }
        }

        public BusinessFuncionario PesquisarFuncionario(string cpf)
        {
            using (ConexaoBanco conexaoBanco = new ConexaoBanco())
            {
                try
                {
                    FuncionarioDataDTO funcionarioData = conexaoBanco.Read(cpf);

                    if (funcionarioData != null)
                    {
                        BusinessFuncionario funcionario = new BusinessFuncionario
                        {
                            Id = funcionarioData.ID,
                            Nome = funcionarioData.Nome,
                            Email = funcionarioData.Email,
                            Endereco = funcionarioData.Endereco,
                            Cpf = funcionarioData.CPF
                        };

                        return funcionario;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool AtualizarFuncionario(BusinessFuncionario funcionario)
        {
            using (ConexaoBanco conexaoBanco = new ConexaoBanco())
            {
                if (conexaoBanco.Update(funcionario.Id, funcionario.Nome, funcionario.Cpf, funcionario.Email, funcionario.Endereco))
                {
                    return true;
                }
                else 
                {
                    msg = ConexaoBanco.msgErro;    
                    return false;
                }
            }
        }

        public bool DeletarFuncionario(int funcionarioId)
        {
            using (ConexaoBanco conexaoBanco = new ConexaoBanco())
            {
                if (conexaoBanco.Delete(funcionarioId))
                {
                    return true;
                }
                else
                {
                    msg = ConexaoBanco.msgErro;
                    return false;
                }
            }
        }

        public bool VerificarCPF(string cpf)
        {
            using (ConexaoBanco conexaobanco = new ConexaoBanco())
            {
                if (conexaobanco.ConsultaCPF(cpf))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}