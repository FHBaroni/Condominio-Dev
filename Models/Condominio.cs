namespace CondominioDev.Api.Models
{
    public class Condominio
    {
        public int Id { get; set; }
        public decimal Orcamento { get; set; }
        public decimal GastoTotal { get; set; }
        public virtual List<Habitante> Habitante { get; set; }
        public Habitante MaiorCusto { get; set; }

        public Condominio(int id, decimal orcamento, decimal gastoTotal)
        {
            Id = id;
            Orcamento = orcamento;
            GastoTotal = gastoTotal;
        }
    }
}
