using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClassRoom.API.Models;
using ClassRoom.API.Data;

namespace ClassRoom.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   
    public class BlocoController : ControllerBase
    {

    private readonly DataContext _context;
    public BlocoController(DataContext context)
    {
            _context = context;

    }  
    
    [HttpGet]
    public IEnumerable<Bloco> Get()
    {
      return _context.Blocos;
    }

    [HttpGet("{id}")]
    public Bloco GetById(int id)
    {
      return _context.Blocos.FirstOrDefault(bloco => bloco.BlocoId == id);
    }

    [HttpPost]
    public string Post()
    {
      return "Aqui tem um Post";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
      return $"Aqui tem um Put com id = {id}";
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
      return $"Aqui tem um Delete com id = {id}";
    }
  }
}

