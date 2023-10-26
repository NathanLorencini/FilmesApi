using System.ComponentModel.DataAnnotations;

namespace Filmes.Data.Dtos;

public class CreateCinemaDto
{

    [Required(ErrorMessage = "O campo nome é obrigatório.")]
    public string Name { get; set; }

    public int EnderecoId { get; set; }
}