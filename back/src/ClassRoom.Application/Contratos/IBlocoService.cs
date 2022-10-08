using System.Threading.Tasks;
using ClassRoom.Domain;

namespace ClassRoom.Application.Contratos
{
    public interface IBlocoService
    {
        Task<Bloco> AddBlocos(Bloco model); 
        Task<Bloco>UpdateBloco(int blocoId, Bloco model); 
        Task<bool> DeleteBloco(int blocoId);
        
        Task<Bloco[]> GetAllBlocosAsync();
        Task<Bloco[]> GetAllBlocosByNomeAsync(string nome);
        Task<Bloco> GetAllBlocoByIdAsync(int blocoId);    
    }
}