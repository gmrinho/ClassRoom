using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ClassRoom.Application.Contratos;
using Microsoft.AspNetCore.Http;
using ClassRoom.Application.Dtos;
using System.Collections.Generic;
using ClassRoom.API.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace ClassRoom.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]   
    public class BlocosController : ControllerBase
    {

    private readonly IBlocoService _blocoService;
    private readonly IAccountService _accountService;

    public BlocosController(IBlocoService blocoService,
                            IAccountService accountService)
    {
            _blocoService= blocoService;
            _accountService = accountService;
    }  
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
          var blocos = await _blocoService.GetAllBlocosAsync(User.GetUserId());
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
          var bloco = await _blocoService.GetAllBlocoByIdAsync(User.GetUserId(), id);
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
          var bloco = await _blocoService.GetAllBlocosByNomeAsync(User.GetUserId(), nome);
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
          var bloco = await _blocoService.AddBlocos(User.GetUserId(), model);
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
          var bloco = await _blocoService.UpdateBloco(User.GetUserId(),id, model);
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
        var bloco = await _blocoService.GetAllBlocoByIdAsync(User.GetUserId(), id);
        if(bloco == null) return NoContent();       

        return await _blocoService.DeleteBloco(User.GetUserId(), id) ?
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

