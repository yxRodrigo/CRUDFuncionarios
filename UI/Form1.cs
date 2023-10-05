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
            // Ciclo de vida desta inst�ncia est� ligado ao ciclo de vida do formul�rio
            businessManager = new BusinessManager();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Obt�m dados dos campos de entrada.
            string nome = txtNome.Text;
            string cpf = txtCPF.Text;
            string email = txtEmail.Text;
            string endereco = txtEndereco.Text;

            // Verifica se algum campo obrigat�rio est� em branco.
            if (ConfereCampos())
            {
                return;
            }
            else if (businessManager.VerificarCPF(cpf)) // Verifica se o CPF j� existe no banco de dados.
            {
                MessageBox.Show("CPF j� existe no banco de dados.", "Aten��o:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimparCampos(); // Limpa os campos de entrada.
            }
            else
            {
                // Tenta cadastrar o funcion�rio no banco de dados.
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

            // Exiba um MessageBox de confirma��o.
            DialogResult result = MessageBox.Show("Tem certeza de que deseja atualizar os dados deste funcion�rio?", "Confirma��o", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verifique se o usu�rio clicou em "Sim".
            if (result == DialogResult.Yes)
            {
                // Chame o m�todo de atualiza��o da classe BusinessManager.
                if (businessManager.AtualizarFuncionario(funcionario))
                {
                    MessageBox.Show("Dados do funcion�rio atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnPesquisar_Click(btnPesquisar, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show($"Erro ao atualizar dados do funcion�rio:\n{businessManager.msg}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimparCampos();
                    tabelaFuncionarios.Rows.Clear();
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza de que deseja excluir este funcion�rio?", "Confirma��o", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verifique se o usu�rio clicou em "Sim".
            if (result == DialogResult.Yes)
            {
                if (businessManager.DeletarFuncionario(businessManager.Id))
                {
                    MessageBox.Show("Funcion�rio Deletado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Obt�m o CPF digitado pelo usu�rio.
            string cpf = txtCPF.Text;

            // Verifica se o campo de CPF est� vazio ou nulo.
            if (cpf.Length < 14)
            {
                MessageBox.Show("Digite um CPF v�lido.", "Aten��o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabelaFuncionarios.Rows.Clear();
                txtCPF.Focus();
                return;
            }

            try
            {
                // Chama o m�todo PesquisarFuncionario da classe BusinessManager para buscar um funcion�rio.
                BusinessFuncionario funcionario = businessManager.PesquisarFuncionario(cpf);

                if (funcionario != null)
                {
                    // Limpa a linha existente no DataGridView.
                    tabelaFuncionarios.Rows.Clear();

                    // Adiciona uma nova linha ao DataGridView com os dados do funcion�rio encontrado.
                    tabelaFuncionarios.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.Email, funcionario.Cpf, funcionario.Endereco);
                }
                else
                {
                    tabelaFuncionarios.Rows.Clear();
                    txtCPF.Focus();
                    MessageBox.Show("Funcion�rio n�o encontrado.", "Informa��o", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"N�o foi poss�vel fazer a pesquisa. {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabelaFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifique se a c�lula clicada est� em uma linha v�lida.
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tabelaFuncionarios.Rows[e.RowIndex];

                // Preencha os campos de texto com os valores das c�lulas da linha selecionada.
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