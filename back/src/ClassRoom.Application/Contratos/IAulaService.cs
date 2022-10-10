using System.Threading.Tasks;
using ClassRoom.Application.Dtos;

namespace ClassRoom.Application.Contratos
{
    public interface IAulaService
    {
        Task<AulaDto[]>SaveAula(int aulaId, AulaDto[] model); 
        Task<bool> DeleteAula(int blocoId, int loteId);
        Task<AulaDto[]> GetAulasByBlocoIdAsync(int blocoId);
        Task<AulaDto> GetAulaByIdsAsync(int blocoId, int aulaId);    
    }
}