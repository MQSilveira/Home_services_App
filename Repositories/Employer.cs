using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WinFormsApp.Repository
{
    public class EmployerRepository
    {
        private static MySqlConnection bdConn; // MySQL
        private static string con = "server=localhost;database=clean-db;user id=root;password=''"; // CONFIG DO 

        // Lista estática de objetos Employer
        private static List<Models.Employer.Employer> employerList = new List<Models.Employer.Employer>();

        public static void Create(Models.Employer.Employer employer)
        {
            // Verifica se o objeto employer é nulo
            if (employer == null)
            {
                // Exibe uma mensagem de erro caso o objeto employer seja nulo e retorna do método
                MessageBox.Show("Erro: Tente novamente!");
                return;
            }

            try
            {
                // Cria uma instância de MySqlConnection com a string de conexão definida em 'con'
                bdConn = new MySqlConnection(con);

                // Abre a conexão com o Banco Dados
                bdConn.Open();

                // Cria a instrução SQL de inserção
                string query =
                    "INSERT INTO employer (name, email, cpf_cnpj, password, address, level, isActive)" +
                    " VALUES " +
                    "(@name, @email, @cpf_cnpj, SHA2(@password, 256), @address, @level, @isActive)";

                // Cria um objeto MySqlCommand com a instrução SQL e a conexão
                MySqlCommand command = new MySqlCommand(query, bdConn);

                // Define os parâmetros da instrução SQL com os valores do objeto employer
                command.Parameters.AddWithValue("@name", employer.getName());
                command.Parameters.AddWithValue("@email", employer.getEmail());
                command.Parameters.AddWithValue("@cpf_cnpj", employer.getCpfCnpj());
                command.Parameters.AddWithValue("@password", employer.getPassword());
                command.Parameters.AddWithValue("@address", employer.getAddress());
                command.Parameters.AddWithValue("@level", employer.getLevel());
                command.Parameters.AddWithValue("@isActive", employer.getIsActive());

                // Executa a instrução SQL de inserção e retorna o número de linhas afetadas
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected < 0)
                {
                    // Erro caso ocorra um problema ao criar o employer
                    MessageBox.Show("Erro. Tente novamente!");
                    return;
                }

                // Fecha a conexão com o banco de dados
                bdConn.Close();
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra uma exceção durante a execução
                MessageBox.Show("Impossível estabelecer conexão: " + ex.Message);
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
                string query = "SELECT COUNT(*) FROM employer WHERE email = @email AND password = SHA2(@password, 256)";
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
                MessageBox.Show("Impossível estabelecer conexão: " + ex.Message);
            }
            
            // Retorna true ou false
            return accessGranted;
        }
    }
}