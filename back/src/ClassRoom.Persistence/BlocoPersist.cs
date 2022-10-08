using System.Linq;
using System.Threading.Tasks;
using ClassRoom.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClassRoom.Persistence
{
    public class BlocoPersist : IBlocoPersist
    {
        private readonly ClassRoomContext _context;
        public BlocoPersist(ClassRoomContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            
        }
        public async Task<Bloco[]> GetAllBlocosAsync()
        {
           IQueryable<Bloco> querry = _context.Blocos
                .Include(b => b.Aulas);
            querry = querry.AsNoTracking().OrderBy(b => b.Id);

            return await querry.ToArrayAsync();
        }

        public async Task<Bloco[]> GetAllBlocosByNomeAsync(string nome)
        {
             IQueryable<Bloco> querry = _context.Blocos
                .Include(b => b.Aulas);       
            return await querry.ToArrayAsync();
        }
        
        public async Task<Bloco> GetAllBlocoByIdAsync(int blocoId)
        {
            IQueryable<Bloco> querry = _context.Blocos
                .Include(b => b.Aulas);
            querry = querry.AsNoTracking().OrderBy(b => b.Id)
                    .Where(b => b.Id == blocoId);

            return await querry.FirstOrDefaultAsync();
        }
    }     
}