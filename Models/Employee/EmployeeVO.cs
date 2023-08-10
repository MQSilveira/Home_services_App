namespace WinFormsApp.Models.Employee
{
    // Atributos do VO que será repassado para o back-end
    // OBS: Após o tipo do atributo tem um '?' isso significa que esse atributo pode ser nulo, pensando no Update
    public class EmployeeVO
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? cpf_cnpj { get; set; }
        public string? password { get; set; }
        public string? repeatPassword { get; set; }
        public string? address { get; set; }
        public string? skills { get; set; }
        public string? transport { get; set; }
        public int? level { get; set; }
        public int? isActive { get; set; }
    }
}