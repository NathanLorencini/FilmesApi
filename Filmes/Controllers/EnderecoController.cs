using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos;
using Filmes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;


    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AddEndereco(CreateEnderecoDto enderecoDto)
    {
        var endereco = _mapper.Map<Endereco>(enderecoDto);

        _context.Enderecos.Add(endereco);

        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = endereco.Id }, endereco);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

        if (endereco is null) return NotFound();

        var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

        return Ok(enderecoDto);
    }


    [HttpGet]
    public List<ReadEnderecoDto> GetAll()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos);
    }


    [HttpPut("{id}")]
    public IActionResult Update(int id, ReadEnderecoDto enderecoDto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

        if (endereco is null) return NotFound();

        _mapper.Map(enderecoDto, endereco);

        _context.SaveChanges();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

        if(endereco is null) return NotFound();

        _context.Remove(endereco);

        _context.SaveChanges();

        return NoContent();
    }
}