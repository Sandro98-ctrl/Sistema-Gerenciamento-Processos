using System.ComponentModel.DataAnnotations.Schema;

namespace Gerenciador.Processos.Data.Models
{
    [Table("customers")]
    public class CustomerModel
    {
        public long Id { get; init; }

        public string Name { get; set; }

        public string Cnpj { get; set; }

        public string State { get; set; }
    }
}
