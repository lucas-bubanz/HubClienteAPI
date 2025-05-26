using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    public class Endereco
    {
        [Key]
        [Column("codigo_endereco")]
        public Guid CodigoEndereco { get; set; }

        [Column("logradouro")]
        public string? Logradouro { get; set; }

        [Column("complemento")]
        public string? Complemento { get; set; }

        [Column("bairro")]
        public string? Bairro { get; set; }

        [Column("localidade")]
        public string? Localidade { get; set; }

        [Column("uf")]
        public string? Uf { get; set; }

        [Column("estado")]
        public string? Estado { get; set; }

        [Column("regiao")]
        public string? Regiao { get; set; }

        [Column("cliente_id")]
        public Guid CodigoCliente { get; set; }

        public Cliente? Cliente { get; set; }            
    }
}