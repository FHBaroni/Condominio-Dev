namespace CondominioDev.Api.Models
{
    public class Habitante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DataNacimento { get; set; }
        public decimal Renda { get; set; }
        public int CPF { get; set; }
        public decimal CustoCondominio { get; set; }
        public virtual Condominio Condominio { get; set; }
        public virtual int CondominioId { get; set; }
    }
}
