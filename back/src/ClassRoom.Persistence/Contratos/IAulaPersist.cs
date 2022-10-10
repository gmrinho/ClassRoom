using System.Threading.Tasks;
using ClassRoom.Domain;

namespace ClassRoom.Persistence
{
    public interface IAulaPersist
    {
        Task<Aula[]> GetAulasByBlocoIdAsync(int blocoId);
        Task<Aula> GetAulaByIdsAsync(int blocoId, int aulaId);
    }
}