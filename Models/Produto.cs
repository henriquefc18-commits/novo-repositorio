using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace produtoapi2.Models;

public class Produto
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    [StringLength(255)]
    public string Descricao { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Preco { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Quantidade { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}

