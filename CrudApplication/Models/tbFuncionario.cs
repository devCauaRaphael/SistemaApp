namespace CrudApplication.Models
{
    public class tbFuncionario
    {
        public int ?IdFuncionario { get; set; }
        public string ?Email { get; set; }
        public string ?Nome { get; set; }
        public string ?Senha { get; set; }
        public List<tbFuncionario> ?ListaFuncionario { get; set; }
    }
}
