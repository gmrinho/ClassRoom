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
    public class BlocosController : ControllerBase
    {

    private readonly IBlocoService _blocoService;
    public BlocosController(IBlocoService blocoService)
    {
      _blocoService= blocoService;
    }  
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
          var blocos = await _blocoService.GetAllBlocosAsync();
          if(blocos == null) return NoContent();

          return Ok(blocos);
      }
      catch (Exception ex)
      {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
          $"Erro ao tentar recuperar blocos. Erro {ex.Message}");
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      try
      {  
          var bloco = await _blocoService.GetAllBlocoByIdAsync(id);
          if(bloco == null) return NoContent();

          return Ok(bloco);
      }
      catch (Exception ex)
      {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar blocos. Erro {ex.Message}");
      }
    }

     [HttpGet("{nome}/nome")]
    public async Task<IActionResult> GetByNome(string nome)
    {
      try
      {
          var bloco = await _blocoService.GetAllBlocosByNomeAsync(nome);
          if(bloco == null) return NoContent();

          return Ok(bloco);
      }
      catch (Exception ex)
      {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar blocos. Erro {ex.Message}");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post(BlocoDto model)
    {
      try
      {
          var bloco = await _blocoService.AddBlocos(model);
          if(bloco == null) return NoContent();

          return Ok(bloco);
      }
      catch (Exception ex)
      {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
          $"Erro ao tentar adicionar blocos. Erro {ex.Message}");
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, BlocoDto model)
    {
         {
      try
      {
          var bloco = await _blocoService.UpdateBloco(id, model);
          if(bloco == null) return NoContent();

          return Ok(bloco);
      }
      catch (Exception ex)
      {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
          $"Erro ao tentar atualizar blocos. Erro {ex.Message}");
      }
     }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        var bloco = await _blocoService.GetAllBlocoByIdAsync(id);
        if(bloco == null) return NoContent();       

        return await _blocoService.DeleteBloco(id) ?
            Ok("Deletado") :
            throw new Exception("Deu ruim");
      }
      catch (Exception ex)
      {         
          return this.StatusCode(StatusCodes.Status500InternalServerError, 
          $"Erro ao tentar deletar blocos. Erro {ex.Message}");
      }
    }  
  }
}

