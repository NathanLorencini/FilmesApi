using System.ComponentModel.DataAnnotations;

namespace Filmes.Models;

public class Sessao
{
    [Key]
    [Required]
    public int Id { get; set; }
}