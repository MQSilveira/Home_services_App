using System;
using System.Windows.Forms;
using WinFormsApp.Models.Employee;

namespace WinFormsApp
{
    public class GetEmployeeByAbility : Form
    {
        private Form parent;
        private Label labelSkills;
        private CheckBox checkBoxDomesticService;
        private CheckBox checkBoxDomesticMaintenance;
        private CheckBox checkBoxPainting;
        private CheckBox checkBoxAll;
        private ListBox listaEmployee;
        private Button buttonSearch;
        List<Models.Employee.EmployeeVO> filteredList = new List<Models.Employee.EmployeeVO>();

        public GetEmployeeByAbility (Form parent)
        {
            ConfigureForm();
            InitializeComponent();

            this.parent = parent;
            FormClosed += OnClose;
        }
    
        private void ConfigureForm()
        {
            this.Text = "Buscar por habilidade(s)";
            this.Size = new System.Drawing.Size(800,600);
        }

        private void InitializeComponent()
        {
            //Cria e configura elementos visuais
            labelSkills = new Label();
            labelSkills.Text = "Selecionone a(s) habilidade(s) que procura:";
            labelSkills.Location = new System.Drawing.Point(50, 50);
            labelSkills.Size = new System.Drawing.Size(400, 20);

            checkBoxDomesticService = new CheckBox();
            checkBoxDomesticService.Name = "cbDomesticService";
            checkBoxDomesticService.Text = "Serviços Domésticos";
            checkBoxDomesticService.Location = new System.Drawing.Point(50, 80);
            checkBoxDomesticService.Size = new System.Drawing.Size(120, 20);

            checkBoxDomesticMaintenance = new CheckBox();
            checkBoxDomesticMaintenance.Name = "cbDomesticMaintenance";
            checkBoxDomesticMaintenance.Text = "Manutenção Doméstica";
            checkBoxDomesticMaintenance.Location = new System.Drawing.Point(checkBoxDomesticService.Location.X+150, 80);
            checkBoxDomesticMaintenance.Size = new System.Drawing.Size(120, 20);

            checkBoxPainting = new CheckBox();
            checkBoxPainting.Name = "cbPainting";
            checkBoxPainting.Text = "Pintura";
            checkBoxPainting.Location = new System.Drawing.Point(checkBoxDomesticMaintenance.Location.X+150, 80);
            checkBoxPainting.Size = new System.Drawing.Size(120, 20);

            checkBoxAll = new CheckBox();
            checkBoxAll.Name = "cbAll";
            checkBoxAll.Text = "Todos";
            checkBoxAll.Location = new System.Drawing.Point(checkBoxPainting.Location.X+150, 80);
            checkBoxAll.Size = new System.Drawing.Size(120, 20);
            checkBoxAll.CheckedChanged += CheckBoxTodosIsChecked;

            buttonSearch = new Button();
            buttonSearch.Text = "Buscar";
            buttonSearch.Location = new System.Drawing.Point(50,110);
            buttonSearch.Click += SearchButtonClick;

            listaEmployee = new ListBox();
            listaEmployee.FormattingEnabled = true;
            listaEmployee.Location = new System.Drawing.Point(50,140);
            listaEmployee.Name = "lstEmployee";
            listaEmployee.Size = new System.Drawing.Size(200, 200);
            listaEmployee.TabIndex = 0;
            listaEmployee.Click += EmployeeListItemClick;

            // Adiciona os elementos visuais ao formulário
            Controls.Add(labelSkills);
            Controls.Add(checkBoxDomesticService);
            Controls.Add(checkBoxDomesticMaintenance);
            Controls.Add(checkBoxPainting);
            Controls.Add(checkBoxAll);  
            Controls.Add(buttonSearch);
            Controls.Add(listaEmployee);
        }

        // Evento que verifica se o check box "Todos" está checado
        private void CheckBoxTodosIsChecked(object sender, EventArgs e)
        {
            // Verifica se a opção "Todos" está checada
            bool checkedAll = checkBoxAll.Checked;
        
            // Marca e desabilita as outras opções se "Todos" estiver marcado
            if (checkedAll) {
                checkBoxDomesticService.Checked = true;
                checkBoxDomesticMaintenance.Checked = true;
                checkBoxPainting.Checked = true;
            
                checkBoxDomesticService.Enabled = false;
                checkBoxDomesticMaintenance.Enabled = false;
                checkBoxPainting.Enabled = false;
            }
            else 
            {
                checkBoxDomesticService.Checked = false;
                checkBoxDomesticMaintenance.Checked = false;
                checkBoxPainting.Checked = false;

                checkBoxDomesticService.Enabled = true;
                checkBoxDomesticMaintenance.Enabled = true;
                checkBoxPainting.Enabled = true;
            }
        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            // Limpar os itens existentes na lista
            listaEmployee.Items.Clear();
            // this.ClearForm();

            // Verificar se os check boxes estão checados
            bool checkedAll = checkBoxAll.Checked;
            bool checkedServicoDomestico = checkBoxDomesticService.Checked;
            bool checkedDomesticMaintenance = checkBoxDomesticMaintenance.Checked;
            bool checkedPainting = checkBoxPainting.Checked;
            
            // Insere os objetos EmployeeVO vindo de Controller.Employee na listaEmployees
            filteredList = WinFormsApp.Controller.Employee.GetEmployees(checkedAll, checkedServicoDomestico, checkedDomesticMaintenance, checkedPainting);
            
            foreach (Models.Employee.EmployeeVO employee in filteredList) {
                this.listaEmployee.Items.Add(employee.name);
            }
        }

        // Método que envia uma menssage box dando opção de diálogo com employee ao clicar
        private void EmployeeListItemClick(object sender, EventArgs e)
        {
            //Se o index selecionado não for inexistente executa a função
            if (listaEmployee.SelectedIndex >= 0)
            {
                //Define o employee selecionado
                Models.Employee.EmployeeVO employeeSelected = filteredList[listaEmployee.SelectedIndex];

                // Envia uma mensagem perguntando se deseja enviar mensagem para o employee selecionado
                int action = UserInteractionWithEmployee(
                    "Opções de Interação",
                    $"Escolha uma opção de interação com {employeeSelected.name}"
                );

                if (action == 1)
                {
                    MessageBox.Show($"Você enviou uma solicitação de contrato para {employeeSelected.name}");
                }
                else if (action == 2)
                {
                    MessageBox.Show($"Você entrou em contato com {employeeSelected.name} e conversaram :D");
                }
                else if (action == 3)
                {
                    MessageBox.Show($"Ação cancelada pelo usuário");
                }
            };
        }

        private int UserInteractionWithEmployee(string title, string message)
        {
            int action = 0;

            // Instância novo formulario
            Form formChatEmployee = new Form();
            formChatEmployee.Text = title;
            formChatEmployee.Size = new System.Drawing.Size(320, 250);
            formChatEmployee.FormBorderStyle = FormBorderStyle.FixedDialog;
            formChatEmployee.StartPosition = FormStartPosition.CenterParent;
            formChatEmployee.MinimizeBox = false;
            formChatEmployee.MaximizeBox = false;

            // Adiciona elementos e atributos ao formulario
            Label labelMessage = new Label();
            labelMessage.Text = message;
            labelMessage.Location = new Point(10, 10);
            labelMessage.AutoSize = true;

            Button buttonHire = new Button();
            buttonHire.Text = "Contratar";
            buttonHire.TextAlign = ContentAlignment.MiddleCenter;
            buttonHire.Location = new Point(10, 50);
            buttonHire.Size = new System.Drawing.Size(120, 30);
            buttonHire.DialogResult = DialogResult.OK;
            buttonHire.Click += (sender, e) => { action = 1;};

            Button buttonSendMessage = new Button();
            buttonSendMessage.Text = "Enviar Mensagem";
            buttonSendMessage.TextAlign = ContentAlignment.MiddleCenter;
            buttonSendMessage.Location = new Point(10, 100);
            buttonSendMessage.Size = new System.Drawing.Size(120, 30);
            buttonSendMessage.DialogResult = DialogResult.OK;
            buttonSendMessage.Click += (sender, e) => { action = 2;};

            Button buttonCancel = new Button();
            buttonCancel.Text = "Cancelar";
            buttonCancel.TextAlign = ContentAlignment.MiddleCenter;
            buttonCancel.Location = new Point(10, 150);
            buttonCancel.Size = new System.Drawing.Size(120, 30);
            buttonCancel.DialogResult = DialogResult.OK;
            buttonCancel.Click += (sender, e) => { action = 3;};

            // Adiciona os elementos a tela
            formChatEmployee.Controls.Add(labelMessage);
            formChatEmployee.Controls.Add(buttonHire);
            formChatEmployee.Controls.Add(buttonSendMessage);
            formChatEmployee.Controls.Add(buttonCancel);

            // Exibe o formulário como diálogo modal, obrigando o usuário a interagir
            formChatEmployee.ShowDialog();
            
            // Retorna a resposta do botão que foi clicado
            return action;
        }

        private void OnClose(object sender, FormClosedEventArgs e){
            this.parent.Show();
        }
    }
}