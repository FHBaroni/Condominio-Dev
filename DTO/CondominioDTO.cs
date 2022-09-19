using CondominioDev.Api.Models;

namespace CondominioDev.Api.DTO
{
    public class CondominioDTO
    {
        public decimal OrcamentoGasto { get; set; }
        public decimal Orcamento { get; set; }
        public decimal GastoTotal { get; set; }
        public Habitante MaiorCusto { get; set; }
    }
}
