using System.ComponentModel.DataAnnotations;

namespace Filmes.Data.Dtos;

public class ReadCinemaDto
{
    public int Id { get; set; }

    public string Name { get; set; }
}