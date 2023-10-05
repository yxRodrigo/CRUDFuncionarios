using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Business;
using Business.Business;

namespace Funcionarios
{
    public partial class Form1 : Form
    {
        private BusinessManager businessManager;
        public Form1()
        {
            InitializeComponent();
            // Ciclo de vida desta instância está ligado ao ciclo de vida do formulário
            businessManager = new BusinessManager();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Obtém dados dos campos de entrada.
            string nome = txtNome.Text;
            string cpf = txtCPF.Text;
            string email = txtEmail.Text;
            string endereco = txtEndereco.Text;

            // Verifica se algum campo obrigatório está em branco.
            if (ConfereCampos())
            {
                return;
            }
            else if (businessManager.VerificarCPF(cpf)) // Verifica se o CPF já existe no banco de dados.
            {
                MessageBox.Show("CPF já existe no banco de dados.", "Atenção:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimparCampos(); // Limpa os campos de entrada.
            }
            else
            {
                // Tenta cadastrar o funcionário no banco de dados.
                if (businessManager.CadastrarFuncionario(nome, cpf, email, endereco))
                {
                    MessageBox.Show(businessManager.msg, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos(); // Limpa os campos de entrada.
                }
                else
                {
                    MessageBox.Show(businessManager.msg, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (ConfereCampos())
            {
                return;
            }

            // Crie um objeto BusinessFuncionario com os dados da linha selecionada.
            BusinessFuncionario funcionario = new BusinessFuncionario
            {
                Id = businessManager.Id,
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Endereco = txtEndereco.Text,
                Cpf = txtCPF.Text
            };

            // Exiba um MessageBox de confirmação.
            DialogResult result = MessageBox.Show("Tem certeza de que deseja atualizar os dados deste funcionário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verifique se o usuário clicou em "Sim".
            if (result == DialogResult.Yes)
            {
                // Chame o método de atualização da classe BusinessManager.
                if (businessManager.AtualizarFuncionario(funcionario))
                {
                    MessageBox.Show("Dados do funcionário atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnPesquisar_Click(btnPesquisar, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show($"Erro ao atualizar dados do funcionário:\n{businessManager.msg}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimparCampos();
                    tabelaFuncionarios.Rows.Clear();
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza de que deseja excluir este funcionário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verifique se o usuário clicou em "Sim".
            if (result == DialogResult.Yes)
            {
                if (businessManager.DeletarFuncionario(businessManager.Id))
                {
                    MessageBox.Show("Funcionário Deletado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    tabelaFuncionarios.Rows.Clear();
                }
                else
                {
                    MessageBox.Show(businessManager.msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            // Obtém o CPF digitado pelo usuário.
            string cpf = txtCPF.Text;

            // Verifica se o campo de CPF está vazio ou nulo.
            if (cpf.Length < 14)
            {
                MessageBox.Show("Digite um CPF válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabelaFuncionarios.Rows.Clear();
                txtCPF.Focus();
                return;
            }

            try
            {
                // Chama o método PesquisarFuncionario da classe BusinessManager para buscar um funcionário.
                BusinessFuncionario funcionario = businessManager.PesquisarFuncionario(cpf);

                if (funcionario != null)
                {
                    // Limpa a linha existente no DataGridView.
                    tabelaFuncionarios.Rows.Clear();

                    // Adiciona uma nova linha ao DataGridView com os dados do funcionário encontrado.
                    tabelaFuncionarios.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.Email, funcionario.Cpf, funcionario.Endereco);
                }
                else
                {
                    tabelaFuncionarios.Rows.Clear();
                    txtCPF.Focus();
                    MessageBox.Show("Funcionário não encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível fazer a pesquisa. {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabelaFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifique se a célula clicada está em uma linha válida.
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tabelaFuncionarios.Rows[e.RowIndex];

                // Preencha os campos de texto com os valores das células da linha selecionada.
                businessManager.Id = Convert.ToInt32(row.Cells["ID"].Value);
                txtNome.Text = row.Cells["Nome"].Value.ToString();
                txtEndereco.Text = row.Cells["Endereco"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtCPF.Text = row.Cells["CPF"].Value.ToString();
            }
        }

        private bool ConfereCampos()
        {
            string nome = txtNome.Text;
            string cpf = txtCPF.Text;
            string email = txtEmail.Text;
            string endereco = txtEndereco.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(endereco))
            {
                MessageBox.Show("Favor preencher todos os campos corretamente.", "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimparCampos(); // Limpa os campos de entrada.
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtCPF.Focus();
        }
    }
}