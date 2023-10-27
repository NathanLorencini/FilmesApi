using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmes.Models;

public class Sessao
{
    public int? FilmeId { get; set; }

    [ForeignKey(nameof(FilmeId))]

    public virtual Filme Filme { get; set; }

    public int? CinemaId { get; set; }

    [ForeignKey(nameof(CinemaId))]
    public virtual Cinema Cinema { get; set; }
}