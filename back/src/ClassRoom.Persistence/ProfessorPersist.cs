using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRoom.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClassRoom.Persistence
{
    public class ProfessorPersist : IProfessorPersist
    {
        private readonly ClassRoomContext _context;
        public ProfessorPersist(ClassRoomContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;           
        }
        public async Task<Professor[]> GetAllProfessorAsync(bool includeBlocos = false)
        {
             IQueryable<Professor> querry = _context.Professores;

            if (includeBlocos)
            {
                querry = querry
                    .Include(b => b.ProfessorBlocos)
                    .ThenInclude(pb => pb.Bloco);
            }
            querry = querry.AsNoTracking().OrderBy(b => b.Id);

            return await querry.ToArrayAsync();
        }

        public async Task<Professor> GetAllProfessorByIdAsync(int professorId, bool includeBlocos = false)
        {
             IQueryable<Professor> querry = _context.Professores;

            if (includeBlocos)
            {
                querry = querry
                    .Include(pro => pro.ProfessorBlocos)
                    .ThenInclude(pb => pb.Bloco);
            }
            querry = querry.AsNoTracking().OrderBy(pro => pro.Id)
                .Where(pro => pro.Id == professorId);

            return await querry.FirstOrDefaultAsync();
        }

        public async Task<Professor[]> GetAllProfessorByNomeAsync(string nome, bool includeBlocos)
        {
            IQueryable<Professor> querry = _context.Professores;

            if (includeBlocos)
            {
                querry = querry
                    .Include(pro => pro.ProfessorBlocos)
                    .ThenInclude(pb => pb.Bloco);
            }
            querry = querry.AsNoTracking().OrderBy(pro => pro.Id)
                .Where(pro => pro.Nome.ToLower().Contains(nome.ToLower()));

            return await querry.ToArrayAsync();
        }
    }
}