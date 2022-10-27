using System.Threading.Tasks;
using ClassRoom.Application.Dtos;

namespace ClassRoom.Application.Contratos
{
    public interface IBlocoService
    {
        Task<BlocoDto> AddBlocos(int userId, BlocoDto model); 
        Task<BlocoDto>UpdateBloco(int userId, int blocoId, BlocoDto model); 
        Task<bool> DeleteBloco(int userId, int blocoId);
        
        Task<BlocoDto[]> GetAllBlocosAsync(int userId);
        Task<BlocoDto[]> GetAllBlocosByNomeAsync(int userId, string nome);
        Task<BlocoDto> GetAllBlocoByIdAsync(int userId, int blocoId);    
    }
}