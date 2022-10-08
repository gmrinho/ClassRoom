using System.Threading.Tasks;

namespace ClassRoom.Persistence
{
    public interface IGeralPersist
    {
        //metodos gerais
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T[] entity) where T: class;
        Task<bool> SaveChangesAsync();
    }
}