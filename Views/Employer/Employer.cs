using System;
using System.Windows.Forms;
using WinFormsApp.Models.Employer;
using Employer = WinFormsApp.Controller.Employer;

namespace WinFormsApp
{
    public partial class EmployerForm : Form
    {
        // Elementos visuais do formulário
        private Label labelName;
        private Label labelEmail;
        private Label labelCPF_CNPJ;
        private Label labelPassword;
        private Label labelAddress;
        private Label labelRepeatPassword;
        private TextBox inputName;
        private TextBox inputEmail;
        private TextBox inputCPF_CNPJ;
        private TextBox inputPassword;
        private TextBox inputAddress;
        private TextBox inputRepeatPassword;
        private Button submitButton;
        private int level;

        // Construtor da classe
        public EmployerForm(int radioButtonValue)
        {
            InitializeComponent();
            this.level = radioButtonValue;
            Color colorBackground = ColorTranslator.FromHtml("#E4F1F7");
            this.BackColor = colorBackground;
            ConfigureForm();
        }
        
        // Configura o formulário atual
        private void ConfigureForm()
        {
            this.Text = "Cadastrar empregador";
            this.Size = new System.Drawing.Size(800, 600);
        }

        // Inicializa os componentes da interface do usuário
        private void InitializeComponent()
        {
            // Cria e configura os elementos visuais
            labelName = new Label();
            labelName.Text = "Nome";
            labelName.Location = new System.Drawing.Point(97, 95);

            inputName = new TextBox();
            inputName.Location = new System.Drawing.Point(97, 130);
            inputName.Name = "inputName";
            inputName.Size = new System.Drawing.Size(200, 20);

            labelCPF_CNPJ = new Label();
            labelCPF_CNPJ.Text = "CPF ou CNPJ";
            labelCPF_CNPJ.Location = new System.Drawing.Point(97, 191);

            inputCPF_CNPJ = new TextBox();
            inputCPF_CNPJ.Location = new System.Drawing.Point(97, 226);
            inputCPF_CNPJ.Name = "inputCPF_CNPJ";
            inputCPF_CNPJ.Size = new System.Drawing.Size(200, 20);

            labelPassword = new Label();
            labelPassword.Text = "Senha";
            labelPassword.Location = new System.Drawing.Point(97, 286);

            inputPassword = new TextBox();
            inputPassword.Location = new System.Drawing.Point(97, 321);
            inputPassword.Name = "inputPassword";
            inputPassword.Size = new System.Drawing.Size(200, 20);
            inputPassword.UseSystemPasswordChar = true;

            labelEmail = new Label();
            labelEmail.Text = "E-mail";
            labelEmail.Location = new System.Drawing.Point(457, 97);

            inputEmail = new TextBox();
            inputEmail.Location = new System.Drawing.Point(457, 132);
            inputEmail.Name = "inputEmail";
            inputEmail.Size = new System.Drawing.Size(200, 20);

            labelAddress = new Label();
            labelAddress.Text = "Endereço";
            labelAddress.Location = new System.Drawing.Point(457, 193);

            inputAddress = new TextBox();
            inputAddress.Location = new System.Drawing.Point(457, 228);
            inputAddress.Name = "inputAddress";
            inputAddress.Size = new System.Drawing.Size(200, 20);

            labelRepeatPassword = new Label();
            labelRepeatPassword.Text = "Repetir Senha";
            labelRepeatPassword.Location = new System.Drawing.Point(457, 288);

            inputRepeatPassword = new TextBox();
            inputRepeatPassword.Location = new System.Drawing.Point(457, 323);
            inputRepeatPassword.Name = "inputRepeatPassword";
            inputRepeatPassword.Size = new System.Drawing.Size(200, 20);
            inputRepeatPassword.UseSystemPasswordChar = true;

            submitButton = new Button();
            submitButton.Text = "Cadastrar";
            submitButton.Location = new System.Drawing.Point(275, 415);
            submitButton.BackColor = Color.White;
            submitButton.Size = new System.Drawing.Size(200, 30);
            submitButton.Click += SubmitForm;

            // Adiciona os elementos visuais ao formulário
            Controls.Add(labelName);
            Controls.Add(inputName);
            Controls.Add(labelCPF_CNPJ);
            Controls.Add(inputCPF_CNPJ);
            Controls.Add(labelPassword);
            Controls.Add(inputPassword);
            Controls.Add(labelEmail);
            Controls.Add(inputEmail);
            Controls.Add(labelAddress);
            Controls.Add(inputAddress);
            Controls.Add(labelRepeatPassword);
            Controls.Add(inputRepeatPassword);
            Controls.Add(submitButton);
        }
        
        // Realiza a validação dos campos obrigatórios
        private void SetupValidation(List<TextBox> requiredInputs)
        {
            foreach (TextBox inputControl in requiredInputs)
            {
                if (string.IsNullOrEmpty(inputControl.Text))
                {
                    MessageBox.Show("Preencha todos os campos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Manipula o evento de clique do botão "Cadastrar"
        private void SubmitForm(object sender, EventArgs e)
        {
            // Cria uma lista com os campos de entrada obrigatórios
            List<TextBox> requiredInputs = new List<TextBox>
            {
                inputName,
                inputEmail,
                inputCPF_CNPJ,
                inputPassword,
                inputAddress,
                inputRepeatPassword
            };

            // Configura a validação dos campos obrigatórios
            SetupValidation(requiredInputs);
            
            // Cria um objeto EmployerVO com os dados fornecidos pelo usuário
            EmployerVO employer = new EmployerVO
            {
                name = inputName.Text,
                email = inputEmail.Text,
                cpf_cnpj = inputCPF_CNPJ.Text,
                password = inputPassword.Text,
                repeatPassword = inputRepeatPassword.Text,
                address = inputAddress.Text,
                level = level
            };

            // Chama o método Employer.Create para criar o usuário
            bool createSuccess = Employer.Create(employer);
            if (!createSuccess)
            {
                // MessageBox.Show("Falha ao cadastrar usuário!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Exibe uma mensagem de sucesso e limpa o formulário
            MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            
            // Fechar o formulário atual e abrir o formulário de login
            this.Close();
            Login loginForm = new Login();
            loginForm.ShowDialog();
        }
        
        // Limpa os campos do formulário
        private void ClearForm()
        {
            inputName.Text = "";
            inputEmail.Text = "";
            inputCPF_CNPJ.Text = "";
            inputPassword.Text = "";
            inputAddress.Text = "";
            inputRepeatPassword.Text = "";
        }
    }
}