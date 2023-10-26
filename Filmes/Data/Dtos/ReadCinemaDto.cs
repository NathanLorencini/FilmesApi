using System.ComponentModel.DataAnnotations;

namespace Filmes.Data.Dtos;

public class ReadCinemaDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ReadEnderecoDto ReadEnderecoDto { get; set; }

    public ICollection<ReadSessaoDto> Sessoes { get; set; }
}