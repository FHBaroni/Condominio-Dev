using System.ComponentModel.DataAnnotations;

namespace CondominioDev.Api.DTO
{
    public class HabitantesDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "A renda é obrigatória")]
        public decimal Renda { get; set; }

        [Required(ErrorMessage = " O CPF é obrigatório")]
        public int CPF { get; set; }
    }
}
