using System.Data;
using MySql.Data.MySqlClient;

using System.Collections.Generic;

namespace WinFormsApp.Repository
{
    public class EmployeeRepository
    {
        private static MySqlConnection bdConn; // MySQL
        
        private static string con = "server=localhost;database=clean-db;user id=root;password=''"; // CONFIG DO 
        
        // Instância a lista de employeeVO
        public static List<Models.Employee.EmployeeVO> employeeVoList = new List<Models.Employee.EmployeeVO>();

        // Método para retornar uma lista de employeeVO
        public static List<Models.Employee.EmployeeVO> ListEmployees()
        {
            try
            {
                // Cria uma instância de MySqlConnection com a string de conexão definida em 'con'
                bdConn = new MySqlConnection(con);

                // Abre a conexão com o Banco de Dados
                bdConn.Open();

                // Consulta pegando id, name, skills, email, address e isActive de employee
                string query = "SELECT id, name, skills, email, address, isActive FROM employee";

                // Cria um objeto MySqlCommand com a consulta e a conexão
                MySqlCommand command = new MySqlCommand(query, bdConn);

                // Executa a consulta e obtém os resultados
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataSet bdDataSet = new DataSet();

                // Preenche o DataSet com os dados retornados pela consulta
                adapter.Fill(bdDataSet, "employee");

                // Exibe os resultados
                DataTable table = bdDataSet.Tables["employee"];

                foreach (DataRow row in table.Rows)
                {
                    // Obtém o valor das colunas 'id', 'name', 'email', 'skills', 'address' e 'isActive' de cada linha do DataTable
                    int id = Convert.ToInt32(row["id"]);
                    string name = row["name"].ToString();
                    string email = row["email"].ToString();
                    string skills = row["skills"].ToString();
                    string address = row["address"].ToString();
                    int isActive = Convert.ToInt32(row["isActive"]);

                    // Insere os valores obtidos em um objeto employeeVO que é adicionado a lista
                    Models.Employee.EmployeeVO employeeVO = new Models.Employee.EmployeeVO {
                        id = id,
                        name = name ?? name,
                        skills = skills ?? skills,
                        email = email ?? email, 
                        cpf_cnpj = null,
                        password = null,
                        repeatPassword = null,
                        address = address ?? address,
                        transport = null,
                        level = null,
                        isActive = isActive
                    };

                    // Verifica se o employeeVO já existe na lista, verificando a partir do id
                    if (employeeVO.isActive == 1 && !employeeVoList.Exists(e => e.id == employeeVO.id))
                    {
                        employeeVoList.Add(employeeVO);
                    }
                }
                // Fecha a conexão com o banco de dados
                bdConn.Close();
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra uma exceção durante a execução
                MessageBox.Show("Impossível estabelecer conexão. Tente novamente.");
            }
            // Retorna uma lista de EmployeeVO
            return employeeVoList;
        }

        public static void Create(Models.Employee.Employee employee)
        {
            // Verifica se o objeto employee é nulo
            if (employee == null)
            {
                // Exibe uma mensagem de erro caso o objeto employee seja nulo e retorna do método
                MessageBox.Show("Erro: Tente novamente!");
                return;
            }

            try
            {
                // Cria uma instância de MySqlConnection com a string de conexão definida em 'con'
                bdConn = new MySqlConnection(con);

                // Abre a conexão com o Banco de Dados
                bdConn.Open();

                // Cria a instrução SQL de inserção
                string query =
                    "INSERT INTO employee (name, email, cpf_cnpj, password, address, skills, valueSkills, level, isActive)" +
                    " VALUES " +
                    "(@name, @email, @cpf_cnpj, SHA2(@password, 256), @address, @skills, @valueSkills, @level, @isActive)";

                // Cria um objeto MySqlCommand com a instrução SQL e a conexão
                MySqlCommand command = new MySqlCommand(query, bdConn);

                // Define os parâmetros da instrução SQL com os valores do objeto employee
                command.Parameters.AddWithValue("@name", employee.getName());
                command.Parameters.AddWithValue("@email", employee.getEmail());
                command.Parameters.AddWithValue("@cpf_cnpj", employee.getCpfCnpj());
                command.Parameters.AddWithValue("@password", employee.getPassword());
                command.Parameters.AddWithValue("@address", employee.getAddress());
                command.Parameters.AddWithValue("@skills", employee.getSkills());
                command.Parameters.AddWithValue("@valueSkills", employee.getValueSkills());
                command.Parameters.AddWithValue("@level", employee.getNivel());
                command.Parameters.AddWithValue("@isActive", employee.getIsActive());

                // Executa a instrução SQL de inserção e retorna o número de linhas afetadas
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected < 0)
                {
                    // Exibe uma mensagem de erro caso ocorra um problema ao criar o employee
                    MessageBox.Show("Erro ao criar empregado. Tente novamente!");
                    return;
                }

                // Fecha a conexão com o banco de dados
                bdConn.Close();
            }
            catch (Exception ex)    // ERRO 
            {   
                // Exibe uma mensagem de erro caso ocorra uma exceção durante a execução
                MessageBox.Show("Impossível estabelecer conexão: " + ex.Message); //AQUI
            }
        }

        public static bool CheckAccess(string email, string password)
        {
            // Váriável que retorna se acesso foi concedido ou não 
            bool accessGranted = false;

            try
            {
                bdConn = new MySqlConnection(con);
                bdConn.Open();

                // Faz o select com a senha criptografada
                string query = "SELECT COUNT(*) FROM employee WHERE email = @email AND password = SHA2(@password, 256)";
                MySqlCommand command = new MySqlCommand(query, bdConn);

                // Informa os valores que serão inserido no select da linha anterior
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                
                // "executa" o select
                int count = Convert.ToInt32(command.ExecuteScalar());
                
                // Se teve alguma "alteração" na pesquisa, o acesso é concedido
                if (count > 0)
                {
                    accessGranted = true;
                }
                
                // Fecha a conexão
                bdConn.Close();
            }

            catch (Exception ex)
            {
                // Mensagem caso não consiga conectar com o banco
                MessageBox.Show("Impossível estabelecer conexão. Tente novamente");
            }
            
            // Retorna true ou false
            return accessGranted;
        }
    }
}