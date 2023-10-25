using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos;
using Filmes.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private FilmeContext _context;

    private IMapper _mapper;


    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    /// <summary>
    /// Adiciona um filme no Db
    /// </summary>
    /// <param name="filmeDto"> Este objeto exige alguns campos para ser criado.</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody]CreateFilmeDto filmeDto)
    {

        Filme filme = _mapper.Map<Filme>(filmeDto);

        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return  CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }


    /// <summary>
    /// Retorna os 100 primeiros itens
    /// </summary>
    /// <param name="skip">Tem como padrao, value 0</param>
    /// <param name="take">Tem como padrao, value 100</param>
    /// <returns></returns>
    /// <response code="200">Case of success</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public List<ReadFilmeDto> RecuperaFilmes([FromQuery]int skip = 0, [FromQuery] int take = 100)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }


    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id)!;
        
        if (filme is null) return NotFound();
        
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);

        return Ok(filmeDto);
    }


    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody]UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

        if (filme is null) return NotFound();

        _mapper.Map(filmeDto, filme);

        _context.SaveChanges();

        return NoContent();
    }


    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

        if (filme is null) return NotFound();


        var flimeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(flimeParaAtualizar, ModelState);

        if (!TryValidateModel(flimeParaAtualizar)) return ValidationProblem(ModelState);
        


        _mapper.Map(flimeParaAtualizar, filme);

        _context.SaveChanges();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

        if (filme is null) return NotFound();

        _context.Remove(filme);
        _context.SaveChanges();

        return NoContent();
    }
}