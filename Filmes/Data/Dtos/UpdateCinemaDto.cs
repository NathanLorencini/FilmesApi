using System.ComponentModel.DataAnnotations;

namespace Filmes.Data.Dtos;

public class UpdateCinemaDto
{
    
    [Required(ErrorMessage = "O campo nome é obrigatório.")]
    public string Name { get; set; }
}