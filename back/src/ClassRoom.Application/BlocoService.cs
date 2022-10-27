using System;
using System.Threading.Tasks;
using AutoMapper;
using ClassRoom.Application.Contratos;
using ClassRoom.Application.Dtos;
using ClassRoom.Domain;
using ClassRoom.Persistence;

namespace ClassRoom.Application
{
    public class BlocoService : IBlocoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IBlocoPersist _blocoPersist;
        private readonly IMapper _mapper;
        public BlocoService(IGeralPersist geralPersist, IBlocoPersist blocoPersist, IMapper mapper )
        {
            _mapper = mapper;
            _blocoPersist = blocoPersist;
            _geralPersist = geralPersist;
        }
        public async Task<BlocoDto> AddBlocos(int userId, BlocoDto model)
        {
            try
            {
                var bloco = _mapper.Map<Bloco>(model);
                bloco.UserId = userId;
                 _geralPersist.Add<Bloco>(bloco);                
                 
                 if ( await _geralPersist.SaveChangesAsync())
                 {
                    var blocoRetorno = await _blocoPersist.GetAllBlocoByIdAsync(userId, bloco.Id);
                    
                    return _mapper.Map<BlocoDto>(blocoRetorno);
                 }
                 return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
          public async Task<BlocoDto> UpdateBloco(int userId,int blocoId, BlocoDto model)
        {
           try
           {
                var bloco = await _blocoPersist.GetAllBlocoByIdAsync(userId, blocoId);
                if (bloco == null) return null;
                
                model.Id = bloco.Id;
                model.UserId = userId;

                _mapper.Map(model, bloco);

                _geralPersist.Update<Bloco>(bloco);
                
                if ( await _geralPersist.SaveChangesAsync())
                 {
                   var eventoRetorno = await _blocoPersist.GetAllBlocoByIdAsync(userId, model.Id);
                   
                   return _mapper.Map<BlocoDto>(eventoRetorno);
                 }
                 return null;
           }
           catch (Exception ex)
           {         
               
                throw new Exception(ex.Message);
           } 
        }

        public async Task<bool> DeleteBloco(int userId, int blocoId)
        {
            try
           {
                var bloco = await _blocoPersist.GetAllBlocoByIdAsync(userId, blocoId);
                if (bloco == null) throw new Exception("O bloco para delete não foi encontrato");
                   
                _geralPersist.Delete<Bloco>(bloco);
                return ( await _geralPersist.SaveChangesAsync());
      
           }
           catch (Exception ex)
           {         
               
                throw new Exception(ex.Message);
           } 
        }

        public async Task<BlocoDto> GetAllBlocoByIdAsync(int userId, int blocoId)
        {
            try
            {
                var blocos = await _blocoPersist.GetAllBlocoByIdAsync(userId, blocoId);
                if(blocos == null) return null;

                var resultado = _mapper.Map<BlocoDto>(blocos);
                return resultado;
            }
            
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<BlocoDto[]> GetAllBlocosAsync(int userId)
        {
            try
            {
                var blocos = await _blocoPersist.GetAllBlocosAsync(userId);
                if(blocos == null) return null;
                
                var resultado = _mapper.Map<BlocoDto[]>(blocos);
                return resultado;
            }
            
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<BlocoDto[]> GetAllBlocosByNomeAsync(int userId, string nome)
        {
             try
            {
                var blocos = await _blocoPersist.GetAllBlocosByNomeAsync(userId, nome);
                if(blocos == null) return null;
                
                var resultado = _mapper.Map<BlocoDto[]>(blocos);
                return resultado;
            }
            
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}