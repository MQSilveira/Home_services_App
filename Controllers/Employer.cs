using WinFormsApp.Models.Employer;

namespace WinFormsApp.Controller
{
    public class Employer
    {
        // Método para criar um employer
        public static bool Create(EmployerVO employer)
        {
            // Verifica se o objeto employer é nulo
            if (employer == null)
            {
                Console.WriteLine("Erro: Tente novamente!");
                return false;
            }

            // Verifica se todos os campos obrigatórios estão preenchidos
            if (string.IsNullOrEmpty(employer.name) || string.IsNullOrEmpty(employer.email) || string.IsNullOrEmpty(employer.cpf_cnpj) || string.IsNullOrEmpty(employer.password) || string.IsNullOrEmpty(employer.email) || string.IsNullOrEmpty(employer.address) || string.IsNullOrEmpty(employer.repeatPassword))
            {
                // Console.WriteLine("Erro! Preencha todos os campos00000.");
                return false;
            }

            // Verifica se as senhas são iguais
            if (employer.password != employer.repeatPassword)
            {
                MessageBox.Show("Erro! As senhas não são iguais.");
                return false;
            }

            // Cria um novo objeto Employer com base no objeto EmployerVO fornecido
            new Models.Employer.Employer(employer);
            return true;
        }
    }
}
