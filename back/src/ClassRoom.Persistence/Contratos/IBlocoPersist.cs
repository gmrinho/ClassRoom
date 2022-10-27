using System.Threading.Tasks;
using ClassRoom.Domain;

namespace ClassRoom.Persistence
{
    public interface IBlocoPersist
    {
        //Blocos
        Task<Bloco[]> GetAllBlocosByNomeAsync(int userId, string nome);
        Task<Bloco[]> GetAllBlocosAsync(int userId);
        Task<Bloco> GetAllBlocoByIdAsync(int userId,int blocoId);
    }
}