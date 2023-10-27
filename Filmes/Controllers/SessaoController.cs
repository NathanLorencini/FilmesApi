using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos;
using Filmes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
    private FilmeContext _context;

    private IMapper _mapper;


    public SessaoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult Add(CreateSessaoDto sessaoDto)
    {
        Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

        _context.Sessao.Add(sessao);

        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { filmeId = sessao.FilmeId, cinemaId = sessao.CinemaId}, sessao);
    }


    [HttpGet("{filmeId}/{cinemaId}")]
    public IActionResult GetById(int filmeId, int cinemaId)
    {
        var sessao = _context.Sessao.FirstOrDefault(x => x.FilmeId == filmeId && x.CinemaId == cinemaId);

        if (sessao is null) return NotFound();

        var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

        return Ok(sessaoDto);
    }


    [HttpGet]
    public List<ReadSessaoDto> GetAll()
    {
        return _mapper.Map<List<ReadSessaoDto>>(_context.Sessao.ToList());
    }
    
}