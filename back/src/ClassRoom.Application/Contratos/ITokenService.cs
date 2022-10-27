using System.Threading.Tasks;
using ClassRoom.Application.Dtos;

namespace ClassRoom.Persistence.Contratos
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDto userUpdateDto);
    }
}