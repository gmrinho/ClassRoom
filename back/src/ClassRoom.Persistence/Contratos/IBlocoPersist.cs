using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRoom.Domain;

namespace ClassRoom.Persistence
{
    public interface IBlocoPersist
    {
        //Blocos
        Task<Bloco[]> GetAllBlocosByNomeAsync(string nome, bool includeProfessores = false);
        Task<Bloco[]> GetAllBlocosAsync(bool includeProfessores = false);
        Task<Bloco> GetAllBlocoByIdAsync(int blocoId, bool includeProfessores = false);
    }
}