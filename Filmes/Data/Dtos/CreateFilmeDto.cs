using System.ComponentModel.DataAnnotations;

namespace Filmes.Data.Dtos;

public class CreateFilmeDto
{
   
    [Required(ErrorMessage = "Titulo obrigatório")]
    public string Titulo { get; set; }


    [Required(ErrorMessage = "Genero obrigatório")]
    [StringLength(50, ErrorMessage = "O tamanho do genero não pode passar de 50 caracteres")]
    public string Genero { get; set; }


    [Required(ErrorMessage = "Duração obrigatório")]
    [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
    public int Duracao { get; set; }

}