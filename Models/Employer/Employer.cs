namespace WinFormsApp.Models.Employer;

public class Employer
{
    // Atributos privadas da classe Employer
    private string name { get; set; }
    private string email { get; set; }
    private string cpf_cnpj { get; set; }
    private string password { get; set; }
    private string address { get; set; }
    private int level { get; set; }
    private int isActive { get; set; }

    // Métodos públicos para acessar os atributos privados
    public string getName() => name;
    public string getEmail() => email;
    public string getCpfCnpj() => cpf_cnpj;
    public string getPassword() => password;
    public string getAddress() => address;
    public int getLevel() => level;
    public int getIsActive() => isActive;

    // Construtor da classe que recebe um objeto EmployerVO
    public Employer(EmployerVO employer)
    {
        // Atribui os valores do objeto EmployerVO às propriedades correspondentes
        this.name = employer.name;
        email = employer.email;
        password = employer.password;
        cpf_cnpj = employer.cpf_cnpj;
        address = employer.address;
        level = (int)employer.level;
        isActive = 1;

        // Chama o método Create do Repository.Employer para salvar o objeto Employer no Banco de Dados
        Repository.EmployerRepository.Create(this);
    }

    // Sobrescreve o método ToString para retornar uma representação em string do objeto Employer
    public override string ToString()
    {
        return $"Nome: {name}, Email: {email}, Senha: {password}, Endereco: {address}, Nivel: {level}";
    }
}