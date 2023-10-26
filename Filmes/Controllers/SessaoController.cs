using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Controllers;

public class SessaoController : ControllerBase
{
    private DbContext _context;

    private IMapper _mapper;


    public SessaoController(DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


}