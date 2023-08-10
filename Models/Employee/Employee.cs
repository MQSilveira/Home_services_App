using System.Collections.Generic;

namespace WinFormsApp.Models.Employee
{
    public class Employee
    {
        // Atributos privadas da classe Employee
        private string name { get; set; }
        private string email { get; set; }
        private string cpf_cnpj { get; set; }
        private string password { get; set; }
        private string address { get; set; }
        private string skills { get; set; }
        private string valueSkills { get; set; }
        private string transport { get; set; }
        private int level { get; set; }
        private int isActive { get; set; }
        

        // Métodos públicos para acessar os atributos privados
        public string getName() => name;
        public string getEmail() => email;
        public string getCpfCnpj() => cpf_cnpj;
        public string getPassword() => password;
        public string getAddress() => address;
        public string getSkills() => skills;
        public string getValueSkills() => valueSkills;
        public string getTransport() => transport;
        public int getNivel() => level;
        public int getIsActive() => isActive;

        // Construtor da classe que recebe um objeto EmployeeVO
        public Employee(EmployeeVO employee)
        {
            // Atribui os valores do objeto EmployeeVO às propriedades correspondentes
            name = employee.name;
            email = employee.email;
            password = employee.password;
            cpf_cnpj = employee.cpf_cnpj;
            address = employee.address;
            skills = employee.skills;
            transport = employee.transport;
            level = (int)employee.level;
            isActive = 1;

            // Chama o método Create do Repository.Employee para salvar o objeto Employee no Banco de Dados
            Repository.EmployeeRepository.Create(this);
        }

        // Sobrescreve o método ToString para retornar uma representação em string do objeto Employee
        public override string ToString()
        {
            return
                $"Nome: {name}, Email: {email}, Senha: {password}, Endereco: {address}, Habilidades: {skills}, ValorHabilidade: {valueSkills}";
        }

        public static List<Models.Employee.EmployeeVO> ListEmployees()
        {
            return Repository.EmployeeRepository.ListEmployees();
        }
    }
}