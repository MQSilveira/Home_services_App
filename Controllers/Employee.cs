using WinFormsApp.Models;
using System.Collections.Generic;
using WinFormsApp.Models.Employee;
using WinFormsApp.Repository;

namespace WinFormsApp.Controller
{
    public static class Employee
    {
        // Método para criar um employee
        public static bool Create(EmployeeVO employee)
        {
            try
            {
                // Verifica se o objeto employee é nulo
                if (employee == null)
                {
                    MessageBox.Show("Erro: Tente novamente!");
                    return false;
                }

                // Verifica se todos os campos obrigatórios estão preenchidos
                if (string.IsNullOrEmpty(employee.name) || string.IsNullOrEmpty(employee.email) || string.IsNullOrEmpty(employee.password) || string.IsNullOrEmpty(employee.repeatPassword))
                {
                    //MessageBox.Show("Erro! Preencha todos os campos.");
                    return false;
                }

                // Verifica se as senhas são iguais
                if (employee.password != employee.repeatPassword)
                {
                    MessageBox.Show("Erro! As senhas não são iguais.");
                    return false;
                }

                // Cria um novo objeto Employee com base no objeto EmployeeVO fornecido
                new Models.Employee.Employee(employee);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro ao criar empregado: Tente novamente" + ex.Message);
                MessageBox.Show("Erro ao criar empregado. Tente novamente");
                return false;
            }
        }

        // Chama o método GetEmployees de Models.Employee
        public static System.Collections.Generic.List<EmployeeVO> GetEmployees(bool all, bool serviceDomestic, bool maintenanceDomestic, bool painting)
        {
            // Instância a lista de employees vindo do models
            List<Models.Employee.EmployeeVO> employeeVoList = Models.Employee.Employee.ListEmployees();

            // Instância a lista filtrada de employeeVO
            List<Models.Employee.EmployeeVO> filteredList = new List<Models.Employee.EmployeeVO>();
            
            foreach (EmployeeVO employee in employeeVoList)
            {
                if (all)
                {
                    // Se "todos" estiver marcado, adiciona o employee à lista
                    filteredList.Add(employee);
                }
                else
                {
                    // Verifica a habilidade específica do employee
                    if 
                    (
                        (serviceDomestic && employee.skills == "Serviços Domésticos") 
                        ||
                        (maintenanceDomestic && employee.skills == "Manutenção Doméstica") 
                        ||
                        (painting && employee.skills == "Pintura")
                    )
                    {
                        filteredList.Add(employee);
                    }
                }
            }
            return filteredList;
        }
    }
}
