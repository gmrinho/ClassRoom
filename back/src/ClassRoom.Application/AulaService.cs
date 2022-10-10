using System;
using System.Threading.Tasks;
using AutoMapper;
using ClassRoom.Application.Contratos;
using ClassRoom.Application.Dtos;
using ClassRoom.Domain;
using ClassRoom.Persistence;
using System.Linq;

namespace ClassRoom.Application
{
    public class AulaService : IAulaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IAulaPersist _aulaPersist;
        private readonly IMapper _mapper;
        public AulaService(IGeralPersist geralPersist, IAulaPersist aulaPersist, IMapper mapper )
        {
            _mapper = mapper;
            _aulaPersist = aulaPersist;
            _geralPersist = geralPersist;
        }
        public async Task AddAula(int blocoId, AulaDto model)
        {
            try
            {
                var aula = _mapper.Map<Aula>(model);
                
                aula.BlocoId = blocoId;

                 _geralPersist.Add<Aula>(aula);
                 
                 await _geralPersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
          public async Task<AulaDto[]> SaveAula(int blocoId, AulaDto[] models)
        {
           try
           {
                var aulas = await _aulaPersist.GetAulasByBlocoIdAsync(blocoId);
                if (aulas == null) return null;

                foreach (var model in models)
                {
                    if (model.Id == 0)
                    {
                        await AddAula(blocoId, model);
                    }
                    else
                    {
                        var aula = aulas.FirstOrDefault(aula => aula.Id == model.Id);
                        model.BlocoId = blocoId;

                        _mapper.Map(model, aula);

                        _geralPersist.Update<Aula>(aula);
                
                        await _geralPersist.SaveChangesAsync();                      
                    }
                }
                   var aulaRetorno = await _aulaPersist.GetAulasByBlocoIdAsync(blocoId);
                   
                   return _mapper.Map<AulaDto[]>(aulaRetorno);
           }
           catch (Exception ex)
           {         
               
                throw new Exception(ex.Message);
           } 
        }

        public async Task<bool> DeleteAula(int blocoId, int aulaId)
        {
            try
           {
                var aula = await _aulaPersist.GetAulaByIdsAsync(blocoId, aulaId);
                if (aula == null) throw new Exception("O bloco para delete não foi encontrato");
                   
                _geralPersist.Delete<Aula>(aula);
                return ( await _geralPersist.SaveChangesAsync());
      
           }
           catch (Exception ex)
           {         
               
                throw new Exception(ex.Message);
           } 
        }

        public async Task<AulaDto> GetAulaByIdsAsync(int blocoId, int aulaId)
        {
            try
            {
                var aula = await _aulaPersist.GetAulaByIdsAsync(blocoId, aulaId);
                if(aula == null) return null;

                var resultado = _mapper.Map<AulaDto>(aula);
                return resultado;
            }
            
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<AulaDto[]> GetAulasByBlocoIdAsync(int blocoId)
        {
             try
            {
                var aulas = await _aulaPersist.GetAulasByBlocoIdAsync(blocoId);
                if(aulas == null) return null;
                
                var resultado = _mapper.Map<AulaDto[]>(aulas);
                return resultado;
            }
            
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

    }
}