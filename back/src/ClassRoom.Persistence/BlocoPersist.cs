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
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            
        }
        public async Task<Bloco[]> GetAllBlocosAsync(int userId)
        {
           IQueryable<Bloco> querry = _context.Blocos
                .Include(b => b.Aulas);
            querry = querry.AsNoTracking().Where(b => b.UserId == userId).OrderBy(b => b.Id);

            return await querry.ToArrayAsync();
        }

        public async Task<Bloco[]> GetAllBlocosByNomeAsync(int userId, string nome)
        {
             IQueryable<Bloco> querry = _context.Blocos
                .Include(b => b.Aulas);  

            querry = querry.AsNoTracking().OrderBy(b => b.Id)
                          .Where(b => b.Nome.ToLower().Contains(nome.ToLower()) && 
                                      b.UserId == userId);
                               
            return await querry.ToArrayAsync();
        }
        
        public async Task<Bloco> GetAllBlocoByIdAsync(int userId, int blocoId)
        {
            IQueryable<Bloco> querry = _context.Blocos
                .Include(b => b.Aulas);
            querry = querry.AsNoTracking().OrderBy(b => b.Id)
                    .Where(b => b.Id == blocoId && b.UserId == userId);

            return await querry.FirstOrDefaultAsync();
        }
    }     
}