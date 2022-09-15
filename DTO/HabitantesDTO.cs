namespace CondominioDev.Api.DTO
{
    public class HabitantesDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DataNacimento { get; set; }
        public decimal Renda { get; set; }
        public int CPF { get; set; }

    }
}
