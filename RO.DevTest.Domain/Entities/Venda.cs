using System;

namespace RO.DevTest.Domain.Entities
{
    public class Venda
    {
        public Guid Id { get; set; }

        public Guid ClienteId { get; set; }
        public Cliente Cliente{ get; set; }

        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
