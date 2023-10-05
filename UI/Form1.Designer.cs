namespace Funcionarios
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblNome = new Label();
            lblEmail = new Label();
            lblCPF = new Label();
            lblEndereco = new Label();
            txtNome = new TextBox();
            txtEndereco = new TextBox();
            btnCadastrar = new Button();
            btnAtualizar = new Button();
            btnExcluir = new Button();
            lblTitulo = new Label();
            btnPesquisar = new Button();
            tabelaFuncionarios = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            CPF = new DataGridViewTextBoxColumn();
            Endereco = new DataGridViewTextBoxColumn();
            txtCPF = new MaskedTextBox();
            txtEmail = new TextBox();
            ((System.ComponentModel.ISupportInitialize)tabelaFuncionarios).BeginInit();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNome.Location = new Point(113, 123);
            lblNome.Margin = new Padding(10);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(60, 19);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblEmail.Location = new Point(113, 169);
            lblEmail.Margin = new Padding(10);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(62, 19);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "E-mail:";
            // 
            // lblCPF
            // 
            lblCPF.AutoSize = true;
            lblCPF.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCPF.Location = new Point(114, 76);
            lblCPF.Margin = new Padding(10);
            lblCPF.Name = "lblCPF";
            lblCPF.Size = new Size(48, 19);
            lblCPF.TabIndex = 2;
            lblCPF.Text = "CPF:";
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblEndereco.Location = new Point(113, 215);
            lblEndereco.Margin = new Padding(10);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(89, 19);
            lblEndereco.TabIndex = 3;
            lblEndereco.Text = "Endereço:";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNome.Location = new Point(208, 119);
            txtNome.Margin = new Padding(10);
            txtNome.MaxLength = 100;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(289, 26);
            txtNome.TabIndex = 3;
            // 
            // txtEndereco
            // 
            txtEndereco.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEndereco.Location = new Point(208, 211);
            txtEndereco.Margin = new Padding(10);
            txtEndereco.MaxLength = 200;
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(289, 26);
            txtEndereco.TabIndex = 5;
            // 
            // btnCadastrar
            // 
            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCadastrar.Location = new Point(110, 269);
            btnCadastrar.Margin = new Padding(10);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(125, 40);
            btnCadastrar.TabIndex = 6;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.FlatStyle = FlatStyle.Flat;
            btnAtualizar.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAtualizar.Location = new Point(241, 269);
            btnAtualizar.Margin = new Padding(10);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(125, 40);
            btnAtualizar.TabIndex = 7;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnExcluir.Location = new Point(372, 269);
            btnExcluir.Margin = new Padding(10);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(125, 40);
            btnExcluir.TabIndex = 8;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = SystemColors.ActiveCaption;
            lblTitulo.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = SystemColors.WindowText;
            lblTitulo.Location = new Point(196, 23);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(213, 22);
            lblTitulo.TabIndex = 8;
            lblTitulo.Text = "CRUD FUNCIONÁRIOS";
            // 
            // btnPesquisar
            // 
            btnPesquisar.FlatStyle = FlatStyle.Flat;
            btnPesquisar.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnPesquisar.Location = new Point(372, 69);
            btnPesquisar.Margin = new Padding(10);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(125, 32);
            btnPesquisar.TabIndex = 2;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // tabelaFuncionarios
            // 
            tabelaFuncionarios.AllowUserToAddRows = false;
            tabelaFuncionarios.AllowUserToDeleteRows = false;
            tabelaFuncionarios.AllowUserToResizeColumns = false;
            tabelaFuncionarios.AllowUserToResizeRows = false;
            tabelaFuncionarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaFuncionarios.Columns.AddRange(new DataGridViewColumn[] { ID, Nome, Email, CPF, Endereco });
            tabelaFuncionarios.Location = new Point(14, 331);
            tabelaFuncionarios.Name = "tabelaFuncionarios";
            tabelaFuncionarios.RowTemplate.Height = 25;
            tabelaFuncionarios.Size = new Size(600, 67);
            tabelaFuncionarios.TabIndex = 10;
            tabelaFuncionarios.CellClick += tabelaFuncionarios_CellClick;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.Width = 50;
            // 
            // Nome
            // 
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            Nome.Width = 125;
            // 
            // Email
            // 
            Email.HeaderText = "E-mail";
            Email.Name = "Email";
            Email.Width = 150;
            // 
            // CPF
            // 
            CPF.HeaderText = "CPF";
            CPF.Name = "CPF";
            // 
            // Endereco
            // 
            Endereco.HeaderText = "Endereço";
            Endereco.Name = "Endereco";
            Endereco.Width = 150;
            // 
            // txtCPF
            // 
            txtCPF.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCPF.Location = new Point(208, 76);
            txtCPF.Margin = new Padding(10);
            txtCPF.Mask = "000.000.000-00";
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(127, 26);
            txtCPF.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(208, 165);
            txtEmail.Margin = new Padding(10);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(289, 26);
            txtEmail.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 405);
            Controls.Add(txtEmail);
            Controls.Add(txtCPF);
            Controls.Add(tabelaFuncionarios);
            Controls.Add(btnPesquisar);
            Controls.Add(lblTitulo);
            Controls.Add(btnExcluir);
            Controls.Add(btnAtualizar);
            Controls.Add(btnCadastrar);
            Controls.Add(txtEndereco);
            Controls.Add(txtNome);
            Controls.Add(lblEndereco);
            Controls.Add(lblCPF);
            Controls.Add(lblEmail);
            Controls.Add(lblNome);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Funcionários";
            ((System.ComponentModel.ISupportInitialize)tabelaFuncionarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Label lblEmail;
        private Label lblCPF;
        private Label lblEndereco;
        private TextBox txtNome;
        private TextBox txtEndereco;
        private Button btnCadastrar;
        private Button btnAtualizar;
        private Button btnExcluir;
        private Label lblTitulo;
        private Button btnPesquisar;
        private DataGridView tabelaFuncionarios;
        private MaskedTextBox txtCPF;
        private TextBox txtEmail;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn CPF;
        private DataGridViewTextBoxColumn Endereco;
    }
}