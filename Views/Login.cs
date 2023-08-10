using WinFormsApp.Repository;

namespace WinFormsApp
{
    public class Login : Form
    {
        // Elementos visuais do formulário
        private Label labelUser;
        private Label labelPassword;
        private TextBox inputUser;
        private TextBox inputPassword;
        private Button btnEnter;
        private RadioButton employeeRadioButton;
        private RadioButton employerRadioButton;


        // Construtor da classe que recebe os métodos ConfigureForm e InitializeComponent
        public Login()
        {
            ConfigureForm();
            InitializeComponent();
        }

        // Configura o formulário
        private void ConfigureForm()
        {
            this.Text = "Login";
            this.Size = new System.Drawing.Size(800, 600);
            Color corFundo = ColorTranslator.FromHtml("#E4F1F7");
            this.BackColor = corFundo;
        }

        // Inicializa os componentes da interface do usuário
        private void InitializeComponent()
        {
            // Cria e configura os elementos visuais
            labelUser = new Label();
            labelUser.Text = "E-mail:";
            labelUser.Location = new System.Drawing.Point(272, 145);

            inputUser = new TextBox();
            inputUser.Location = new System.Drawing.Point(272, 180);
            inputUser.Name = "inputUser";
            inputUser.Size = new System.Drawing.Size(200, 20);

            labelPassword = new Label();
            labelPassword.Text = "Senha:";
            labelPassword.Location = new System.Drawing.Point(272, 250);

            inputPassword = new TextBox();
            inputPassword.Location = new System.Drawing.Point(272, 285);
            inputPassword.Name = "inputPassword";
            inputPassword.Size = new System.Drawing.Size(200, 20);
            inputPassword.UseSystemPasswordChar = true;

            // Cria e configura o radiobutton para employee
            employeeRadioButton = new RadioButton();
            employeeRadioButton.Text = "Empregado";
            employeeRadioButton.Location = new System.Drawing.Point(272, 320);
            Controls.Add(employeeRadioButton);

            // Cria e configura o radiobutton para employer
            employerRadioButton = new RadioButton();
            employerRadioButton.Text = "Empregador";
            employerRadioButton.Location = new System.Drawing.Point(383, 320);
            Controls.Add(employerRadioButton);

            btnEnter = new Button();
            btnEnter.Text = "Entrar";
            btnEnter.Location = new System.Drawing.Point(331, 389);
            btnEnter.BackColor = Color.White;
            btnEnter.Click += BtnEnterClick;

            // Adiciona os elementos visuais ao formulário
            Controls.Add(labelUser);
            Controls.Add(inputUser);
            Controls.Add(labelPassword);
            Controls.Add(inputPassword);
            Controls.Add(btnEnter);
        }

        // Manipula o evento de clique do botão Entrar
        private void BtnEnterClick(object sender, EventArgs e)
        {
            // Obtém o usuário e a senha digitados
            string user = inputUser.Text;
            string password = inputPassword.Text;

            // Verifica qual radiobutton está selecionado
            if (!employeeRadioButton.Checked && !employerRadioButton.Checked)
            {
                MessageBox.Show("Selecione se você é um empregado ou empregador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (employeeRadioButton.Checked && EmployeeRepository.CheckAccess(user, password))
            {
                // Login bem-sucedido
                MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Inserir proxima tela");
                return;
            }
            if (employerRadioButton.Checked && EmployerRepository.CheckAccess(user, password))
            {
                // Login bem-sucedido
                MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetEmployeeByAbility getEmployeeByAbility = new GetEmployeeByAbility(this);
                this.Close();
                getEmployeeByAbility.Show();
                return;
            }

            // Login inválido
            MessageBox.Show("Usuário ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }
}