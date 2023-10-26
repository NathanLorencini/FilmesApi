using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos;
using Filmes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {

        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AddCinema([FromBody]CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = cinema.Id }, cinemaDto);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

            if (cinema is null)  return NotFound();

            var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);

            return Ok(cinemaDto);
        }


        [HttpGet]
        public List<ReadCinemaDto> GetAll()
        {
            return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.Include(x => x.Endereco).ToList());
        }


        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, UpdateCinemaDto updateCinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(x=> x.Id == id);
            
            if (cinema is null) return NotFound();
            

            _mapper.Map(updateCinemaDto, cinema);

            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var cinema = GetById(id);

            if (cinema is null) return NotFound();

            _context.Remove(cinema);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
