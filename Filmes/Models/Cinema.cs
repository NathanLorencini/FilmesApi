using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmes.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório.")]
    public string Name { get; set; }

    public int  EnderecoId { get; set; }
    
    [ForeignKey(nameof(EnderecoId))]
    public virtual Endereco Endereco { get; set; }
} 