using Employee = WinFormsApp.Controller.Employee;
using WinFormsApp.Models.Employee;

namespace WinFormsApp
{
    public partial class EmployeeForm : Form
    {
        private Label labelName;
        private Label labelEmail;
        private Label labelCPF_CNPJ;
        private Label labelPassword;
        private Label labelAddress;
        private Label labelSkills;
        private Label labelValueTransport;
        private Label labelRepeatPassword;
        private TextBox inputName;
        private TextBox inputEmail;
        private TextBox inputCPF_CNPJ;
        private TextBox inputPassword;
        private TextBox inputAddress;
        private ComboBox comboBoxSkills;
        private ComboBox inputValueTransport;
        private TextBox inputRepeatPassword;
        private Button submitButton;
        private int level;

        // Construtor da classe que recebe os métodos ConfigureForm e InitializeComponent e this.nivel(que vem do SelectTypeUser por parâmetro) 
        public EmployeeForm(int radioButtonValue)
        {
            InitializeComponent();
            this.level = radioButtonValue;
            ConfigureForm();
        }
        
        // Configura o formulário atual
        private void ConfigureForm()
        {
            this.Text = "Cadastrar empregado";
            this.Size = new System.Drawing.Size(800, 600);
            Color colorBackground = ColorTranslator.FromHtml("#E4F1F7");
            this.BackColor = colorBackground;
        }

        // Inicializa os componentes da interface do empregado
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

            labelEmail = new Label();
            labelEmail.Text = "E-mail";
            labelEmail.Location = new System.Drawing.Point(97, 191);

            inputEmail = new TextBox();
            inputEmail.Location = new System.Drawing.Point(97, 226);
            inputEmail.Name = "inputEmail";
            inputEmail.Size = new System.Drawing.Size(200, 20);

            labelCPF_CNPJ = new Label();
            labelCPF_CNPJ.Text = "CPF ou CNPJ";
            labelCPF_CNPJ.Location = new System.Drawing.Point(97, 286);

            inputCPF_CNPJ = new TextBox();
            inputCPF_CNPJ.Location = new System.Drawing.Point(97, 321);
            inputCPF_CNPJ.Name = "inputCPF_CNPJ";
            inputCPF_CNPJ.Size = new System.Drawing.Size(200, 20);

            labelPassword = new Label();
            labelPassword.Text = "Senha";
            labelPassword.Location = new System.Drawing.Point(97, 379);

            inputPassword = new TextBox();
            inputPassword.Location = new System.Drawing.Point(97, 414);
            inputPassword.Name = "inputPassword";
            inputPassword.Size = new System.Drawing.Size(200, 20);
            inputPassword.UseSystemPasswordChar = true;

            labelAddress = new Label();
            labelAddress.Text = "Endereço";
            labelAddress.Location = new System.Drawing.Point(457, 97);

            inputAddress = new TextBox();
            inputAddress.Location = new System.Drawing.Point(457, 132);
            inputAddress.Name = "inputAddress";
            inputAddress.Size = new System.Drawing.Size(200, 20);

            labelSkills = new Label();
            labelSkills.Text = "Habilidades";
            labelSkills.Location = new System.Drawing.Point(457, 193);

            comboBoxSkills = new ComboBox();
            comboBoxSkills.Location = new System.Drawing.Point(457, 228);
            comboBoxSkills.Name = "comboBoxSkills";
            comboBoxSkills.Size = new System.Drawing.Size(200, 20);
            comboBoxSkills.DropDownStyle = ComboBoxStyle.DropDownList;

            // Adicionar as habilidades ao ComboBox com valores associados
            comboBoxSkills.Items.Add(new KeyValuePair<string, int>("Serviços Domésticos", 0));
            comboBoxSkills.Items.Add(new KeyValuePair<string, int>("Manutenção Doméstica", 1));
            comboBoxSkills.Items.Add(new KeyValuePair<string, int>("Pintura", 2));
            comboBoxSkills.Items.Add(new KeyValuePair<string, int>("Todos", 3));

            // Definir propriedades para exibir o nome da habilidade no ComboBox
            comboBoxSkills.DisplayMember = "Key";

            // Definir valor padrão para "Serviços Domésticos"
            comboBoxSkills.SelectedIndex = 0;


            labelValueTransport = new Label();
            labelValueTransport.Text = "Transporte";
            labelValueTransport.Location = new System.Drawing.Point(457, 288);

            inputValueTransport = new ComboBox();
            inputValueTransport.Location = new System.Drawing.Point(457, 323);
            inputValueTransport.Name = "inputValueTransport";
            inputValueTransport.Size = new System.Drawing.Size(200, 20);

            // Adicionar opções "Sim" e "Não" ao ComboBox
            inputValueTransport.Items.Add(new KeyValuePair<string, int>("Sim", 0));
            inputValueTransport.Items.Add(new KeyValuePair<string, int>("Não", 1));
            inputValueTransport.DropDownStyle = ComboBoxStyle.DropDownList;
            
            inputValueTransport.DisplayMember = "Key";

            // Definir valor padrão para "Não"
            inputValueTransport.SelectedIndex = 0;


            labelRepeatPassword = new Label();
            labelRepeatPassword.Text = "Repetir Senha";
            labelRepeatPassword.Location = new System.Drawing.Point(457, 381);

            inputRepeatPassword = new TextBox();
            inputRepeatPassword.Location = new System.Drawing.Point(457, 416);
            inputRepeatPassword.Name = "inputRepeatPassword";
            inputRepeatPassword.Size = new System.Drawing.Size(200, 20);
            inputRepeatPassword.UseSystemPasswordChar = true;

            submitButton = new Button();
            submitButton.Text = "Cadastrar";
            submitButton.Location = new System.Drawing.Point(270, 497);
            submitButton.Size = new System.Drawing.Size(200, 30);
            submitButton.BackColor = Color.White;
            submitButton.Click += SubmitForm;
            
            // Adiciona os elementos visuais ao formulário
            Controls.Add(labelName);
            Controls.Add(inputName);
            Controls.Add(labelEmail);
            Controls.Add(inputEmail);
            Controls.Add(labelCPF_CNPJ);
            Controls.Add(inputCPF_CNPJ);
            Controls.Add(labelPassword);
            Controls.Add(inputPassword);
            Controls.Add(labelAddress);
            Controls.Add(inputAddress);
            Controls.Add(labelSkills);
            Controls.Add(comboBoxSkills);
            Controls.Add(labelValueTransport);
            Controls.Add(inputValueTransport);
            Controls.Add(labelRepeatPassword);
            Controls.Add(inputRepeatPassword);
            Controls.Add(submitButton);
        }
        
        // Manipula o evento de clique do botão de envio
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
            
            // Cria um objeto EmployeeVO com os dados fornecidos pelo usuário
            EmployeeVO employee = new EmployeeVO
            {
                name = inputName.Text,
                email = inputEmail.Text,
                cpf_cnpj = inputCPF_CNPJ.Text,
                password = inputPassword.Text,
                repeatPassword = inputRepeatPassword.Text,
                address = inputAddress.Text,
                skills = comboBoxSkills.Text,
                transport = inputValueTransport.Text,
                
                level = level
            };
            
            // Chama o método Employee.Create para criar o usuário
            bool createSuccess = Employee.Create(employee);
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
        
        // Método de validação dos campos obrigatórios
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

        // Limpa todos os campos do formulário
        private void ClearForm()
        {
            inputName.Text = "";
            inputEmail.Text = "";
            inputCPF_CNPJ.Text = "";
            inputPassword.Text = "";
            inputAddress.Text = "";
            comboBoxSkills.SelectedIndex = -1;
            inputValueTransport.Text = "";
            inputRepeatPassword.Text = "";
        }
    }
}