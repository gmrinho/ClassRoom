using System.Threading.Tasks;
using ClassRoom.Domain;

namespace ClassRoom.Persistence
{
    public interface IBlocoPersist
    {
        //Blocos
        Task<Bloco[]> GetAllBlocosByNomeAsync(string nome);
        Task<Bloco[]> GetAllBlocosAsync();
        Task<Bloco> GetAllBlocoByIdAsync(int blocoId);
    }
}