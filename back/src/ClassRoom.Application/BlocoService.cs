using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRoom.Application.Contratos;
using ClassRoom.Domain;
using ClassRoom.Persistence;

namespace ClassRoom.Application
{
    public class BlocoService : IBlocoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IBlocoPersist _blocoPersist;
        public BlocoService(IGeralPersist geralPersist, IBlocoPersist blocoPersist)
        {
            _blocoPersist = blocoPersist;
            _geralPersist = geralPersist;
        }
        public async Task<Bloco> AddBlocos(Bloco model)
        {
            try
            {
                 _geralPersist.Add<Bloco>(model);
                 if ( await _geralPersist.SaveChangesAsync())
                 {
                     return await _blocoPersist.GetAllBlocoByIdAsync(model.Id, false);
                 }
                 return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
          public async Task<Bloco> UpdateBloco(int blocoId, Bloco model)
        {
           try
           {
                var bloco = await _blocoPersist.GetAllBlocoByIdAsync(blocoId, false);
                if (bloco == null) return null;
                
                model.Id = bloco.Id;

                _geralPersist.Update(model);
                if ( await _geralPersist.SaveChangesAsync())
                 {
                     return await _blocoPersist.GetAllBlocoByIdAsync(model.Id, false);
                 }
                 return null;
           }
           catch (Exception ex)
           {         
               
                throw new Exception(ex.Message);
           } 
        }

        public async Task<bool> DeleteBloco(int blocoId)
        {
            try
           {
                var bloco = await _blocoPersist.GetAllBlocoByIdAsync(blocoId, false);
                if (bloco == null) throw new Exception("O bloco para delete não foi encontrato");
                   
                _geralPersist.Delete<Bloco>(bloco);
                return ( await _geralPersist.SaveChangesAsync());
      
           }
           catch (Exception ex)
           {         
               
                throw new Exception(ex.Message);
           } 
        }

        public async Task<Bloco> GetAllBlocoByIdAsync(int blocoId, bool includeProfessores = false)
        {
            try
            {
                var blocos = await _blocoPersist.GetAllBlocoByIdAsync(blocoId, includeProfessores);
                if(blocos == null) return null;
                return blocos;
            }
            
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Bloco[]> GetAllBlocosAsync(bool includeProfessores = false)
        {
            try
            {
                var blocos = await _blocoPersist.GetAllBlocosAsync(includeProfessores);
                if(blocos == null) return null;
                return blocos;
            }
            
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Bloco[]> GetAllBlocosByNomeAsync(string nome, bool includeProfessores = false)
        {
             try
            {
                var blocos = await _blocoPersist.GetAllBlocosByNomeAsync(nome, includeProfessores);
                if(blocos == null) return null;
                return blocos;
            }
            
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}