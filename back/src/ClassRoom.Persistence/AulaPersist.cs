using System.Linq;
using System.Threading.Tasks;
using ClassRoom.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClassRoom.Persistence
{
    public class AulaPersist : IAulaPersist
    {
        private readonly ClassRoomContext _context;
        public AulaPersist(ClassRoomContext context)
        {
            _context = context;          
        }

        public async Task<Aula> GetAulaByIdsAsync(int blocoId, int aulaId)
        {
           IQueryable<Aula> query = _context.Aulas;

           query = query.AsNoTracking()
                        .Where(aula => aula.BlocoId == blocoId
                                    && aula.Id == aulaId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aula[]> GetAulasByBlocoIdAsync(int blocoId)
        {
           IQueryable<Aula> query = _context.Aulas;

           query = query.AsNoTracking()
                        .Where(aula => aula.BlocoId == blocoId);
            
            return await query.ToArrayAsync();
    }     
 }
}