using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmes.Models;

public class Sessao
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public int FilmeId { get; set; }

    public virtual Filme Filme { get; set; }

    [Required]
    public int? CinemaId { get; set; }

    [ForeignKey(nameof(CinemaId))]
    public virtual Cinema Cinema { get; set; }
}