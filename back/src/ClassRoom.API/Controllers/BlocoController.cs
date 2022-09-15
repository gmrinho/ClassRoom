using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClassRoom.API.Models;

namespace ClassRoom.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   
    public class BlocoController : ControllerBase
    {
    public IEnumerable<Bloco> _bloco = new Bloco[] 
    {
        new Bloco()
        {
          BlocoId = 1,
          Nome = "Bloco 1",
          StatusBloco = "Ativo",
          Local = "Próximo ao Refeitório",
          ImageURL = "Foto da peste do bloco.jpg"
        },
        new Bloco()
        {
          BlocoId = 2,
          Nome = "Bloco 2",
          StatusBloco = "Em reforma",
          Local = "Próximo ao Naaf",
          ImageURL = "Foto da peste do bloco.jpg" 
        }     
    };
    public BlocoController()
    {

    }  
    
    [HttpGet]
    public IEnumerable<Bloco> Get()
    {
      return _bloco;
    }

    [HttpGet("{id}")]
    public IEnumerable<Bloco> GetById(int id)
    {
      return _bloco.Where(bloco => bloco.BlocoId == id);
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

