using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ClassRoom.Application.Contratos;
using Microsoft.AspNetCore.Http;
using ClassRoom.Application.Dtos;
using System.Collections.Generic;


namespace ClassRoom.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   
    public class AulasController : ControllerBase
    {

    private readonly IAulaService _aulaService;
    public AulasController(IAulaService aulaService)
    {
      _aulaService = aulaService;
    }  
    
    [HttpGet("{blocoId}")]
    public async Task<IActionResult> Get(int blocoId)
    {
      try
      {
          var aulas = await _aulaService.GetAulasByBlocoIdAsync(blocoId);
          if(aulas == null) return NoContent();

          return Ok(aulas);
      }
      catch (Exception ex)
      {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
          $"Erro ao tentar recuperar Aulas. Erro {ex.Message}");
      }
    }

    [HttpPut("{blocoId}")]
    public async Task<IActionResult> SaveAulas(int blocoId, AulaDto[] model)
    {
         {
      try
      {
          var aulas = await _aulaService.SaveAula(blocoId, model);
          if(aulas == null) return NoContent();

          return Ok(aulas);
      }
      catch (Exception ex)
      {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
          $"Erro ao tentar salvar aulas. Erro {ex.Message}");
      }
     }
    }
    [HttpDelete("{blocoId}/{aulaId}")]
    public async Task<IActionResult> Delete(int blocoId, int aulaId)
    {
      try
      {
        var aula = await _aulaService.GetAulaByIdsAsync(blocoId, aulaId);
        if(aula == null) return NoContent();       

        return await _aulaService.DeleteAula(aula.BlocoId, aula.Id) ?
            Ok("Deletado") :
            throw new Exception("Deu ruim");
      }
      catch (Exception ex)
      {         
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
          $"Erro ao tentar deletar aulas. Erro {ex.Message}");
      }
    }  
  }
}

