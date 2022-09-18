using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public DbSet<Professor> Professores { get; set; }
        public DbSet<ProfessorBloco> ProfessorBlocos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfessorBloco>()
                .HasKey(pb => new {pb.BlocoId, pb.ProfessorId});
        }

    }
}