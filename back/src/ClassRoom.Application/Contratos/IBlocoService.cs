using System.Threading.Tasks;
using ClassRoom.Application.Dtos;

namespace ClassRoom.Application.Contratos
{
    public interface IBlocoService
    {
        Task<BlocoDto> AddBlocos(BlocoDto model); 
        Task<BlocoDto>UpdateBloco(int blocoId, BlocoDto model); 
        Task<bool> DeleteBloco(int blocoId);
        
        Task<BlocoDto[]> GetAllBlocosAsync();
        Task<BlocoDto[]> GetAllBlocosByNomeAsync(string nome);
        Task<BlocoDto> GetAllBlocoByIdAsync(int blocoId);    
    }
}