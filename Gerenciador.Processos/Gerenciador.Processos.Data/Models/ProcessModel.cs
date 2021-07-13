using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gerenciador.Processos.Data.Models
{
    [Table("processes")]
    public class ProcessModel
    {
        public long Id { get; init; }

        [Column("customer_id")]
        public long CustomerId { get; set; }

        public string Number { get; set; }

        public string State { get; set; }

        public decimal Amount { get; set; }

        public bool Active { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
