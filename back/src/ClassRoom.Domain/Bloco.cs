using System.Collections.Generic;

namespace ClassRoom.Domain
{
    public class Bloco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string StatusBloco { get; set; }
        public string Local { get; set; }
        public string ImageURL { get; set; }
        public IEnumerable<Aula> Aulas { get; set; }
        public IEnumerable<Professor> Professores { get; set; }
        public IEnumerable <ProfessorBloco> ProfessorBlocos { get; set; }
    }
}