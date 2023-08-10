using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp
{
    public class SelectTypeUser : Form
    {
        private RadioButton employeeRadioButton;
        private RadioButton employerRadioButton;
        private Button loginButton;


        // Construtor que recebe os métodos ConfigureForm e InitializeComponent
        public SelectTypeUser()
        {
            ConfigureForm();
            InitializeComponent();
        }

        // Configura o formulário atual
        private void ConfigureForm()
        {
            this.Text = "Selecionar tipo de usuário";
            this.Size = new System.Drawing.Size(800, 600);

            Image BackgroundImage = Image.FromFile("Image/background.jpeg");
            this.BackgroundImage = BackgroundImage;
            this.BackgroundImageLayout = ImageLayout.Stretch; 
        }

        // Adiciona os radio buttons ao formulário
        private void InitializeComponent()
        {
            Color corFundo = ColorTranslator.FromHtml("#79BCDA");

            // Botão para acessar o Login:
            loginButton = new Button();
            loginButton.Text = "Login";
            loginButton.Size = new System.Drawing.Size(200, 25);
            loginButton.Location = new System.Drawing.Point(75, 300);
            loginButton.Click += Login;
            loginButton.BackColor = Color.White;
            this.Controls.Add(loginButton);

            // Radio button do empregado que será adicionado o valor de 0
            employeeRadioButton = new RadioButton();
            employeeRadioButton.Text = "Empregado";
            employeeRadioButton.Location = new System.Drawing.Point(75, 200);
            employeeRadioButton.Tag = 0;
            employeeRadioButton.ForeColor = Color.White;
            employeeRadioButton.BackColor = corFundo;
            employeeRadioButton.CheckedChanged += EmployeeRadioButton_CheckedChanged;
            employeeRadioButton.Size = new System.Drawing.Size(200, 50);
            this.Controls.Add(employeeRadioButton);

            // Radio button do empregador que será adicionado o valor de 1
            employerRadioButton = new RadioButton();
            employerRadioButton.Text = "Empregador";
            employerRadioButton.Location = new System.Drawing.Point(75, 240);
            employerRadioButton.Tag = 1;
            employerRadioButton.ForeColor = Color.White;
            employerRadioButton.BackColor = corFundo;
            employerRadioButton.CheckedChanged += EmployeeRadioButton_CheckedChanged;
            employerRadioButton.Size = new System.Drawing.Size(200, 50);
            this.Controls.Add(employerRadioButton);

            // Tamanho do texto para empregado e empregador
            Font radioButtonFont = new Font(this.Font.FontFamily, 12, FontStyle.Regular);

            //Aplica a fonte aos radio buttons    
            employeeRadioButton.Font = radioButtonFont;
            employerRadioButton.Font = radioButtonFont;
        }

        // Abre janela Login //
        private void Login(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.FormClosed += EmployeeForm_FormClosed;
            this.Hide();
            loginForm.ShowDialog();
        
        }

        // Manipula o evento de mudança de seleção do radio button
        private void EmployeeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked)
            {
                // Fecha o formulário atual
                this.Hide();

                // Obtém o valor do radioButton selecionado
                int radioButtonValue = (int)radioButton.Tag;

                if (radioButtonValue == 0)
                {
                    // Abre o novo formulário EmployeeForm passando o valor do radioButtonValue como parâmetro
                    EmployeeForm employeeForm = new EmployeeForm(radioButtonValue);
                    employeeForm.FormClosed += EmployeeForm_FormClosed;
                    employeeForm.Show();
                }
                else
                {
                    // Abre o novo formulário EmployerForm passando o valor do radioButtonValue como parâmetro
                    EmployerForm employerForm = new EmployerForm(radioButtonValue);
                    employerForm.FormClosed += EmployerForm_FormClosed;
                    employerForm.Show();
                }
            }
        }

        // Manipula o evento de fechamento do formulário EmployeeForm
        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Exibe novamente o formulário atual (SelectTypeUser) quando o EmployeeForm for fechado
            this.Show();
        }

        // Manipula o evento de fechamento do formulário EmployerForm
        private void EmployerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Exibe novamente o formulário atual (SelectTypeUser) quando o EmployerForm for fechado
            this.Show();
        }
    }
}