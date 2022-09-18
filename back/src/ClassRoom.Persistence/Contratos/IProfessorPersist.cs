using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRoom.Domain;

namespace ClassRoom.Persistence
{
    public interface IProfessorPersist
    {
        //Professores
        Task<Professor[]> GetAllProfessorByNomeAsync(string nome, bool includeBlocos);
        Task<Professor[]> GetAllProfessorAsync(bool includeBlocos);
        Task<Professor> GetAllProfessorByIdAsync(int professorId, bool includeBlocos);


    }
}