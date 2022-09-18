using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRoom.Domain;

namespace ClassRoom.Application.Contratos
{
    public interface IBlocoService
    {
        Task<Bloco> AddBlocos(Bloco model); 
        Task<Bloco>UpdateBloco(int blocoId, Bloco model); 
        Task<bool> DeleteBloco(int blocoId);
        
        Task<Bloco[]> GetAllBlocosAsync(bool includeProfessores = false);
        Task<Bloco[]> GetAllBlocosByNomeAsync(string nome, bool includeProfessores = false);
        Task<Bloco> GetAllBlocoByIdAsync(int blocoId, bool includeProfessores = false);    
    }
}