﻿namespace CondominioDev.Api.Models
{
    public class Condominio
    {
        public int Id { get; set; }
        public decimal Orcamento { get; set; }
        public decimal GastoTotal { get; set; }
        public virtual List<Habitante> Habitante { get; set; }      
        public Condominio(int id)
        {
            Id = id;          
        }
    }
}
