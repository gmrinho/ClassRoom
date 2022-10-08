using Microsoft.EntityFrameworkCore;
using ClassRoom.Domain;

namespace ClassRoom.Persistence
{
    public class ClassRoomContext : DbContext
    {
        public ClassRoomContext(DbContextOptions<ClassRoomContext> options) 
            : base(options){}
        public DbSet<Bloco> Blocos { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        
    }
}