using System;
using System.ComponentModel.DataAnnotations;

namespace RO.DevTest.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public int Estoque { get; set; }
    }
}
