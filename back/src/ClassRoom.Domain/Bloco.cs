using System.Collections.Generic;
using ClassRoom.Domain.Identity;

namespace ClassRoom.Domain
{
    public class Bloco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string StatusBloco { get; set; }
        public string Local { get; set; }
        public string ImageURL { get; set; }       
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Aula> Aulas { get; set; }      
    }
}