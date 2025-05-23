using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    public class Cliente
    {
        [Key]
        [Column("codigo_cliente")]
        public Guid CodigoCliente { get; set; }

        [Column("nome_cliente")]
        public string? NomeCliente { get; set; }

        [Column("email_cliente")]
        public string? EmailCliente { get; set; }

        [Required]
        [Column("cep_cliente")]
        public string? CepCliente { get; set; }

        public Endereco? Endereco { get; set; }
    }
}