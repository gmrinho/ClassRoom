using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.Domain
{
    public class Aula
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Curso { get; set; }
        public DateTime? DataAula { get; set; }
        public int BlocoId { get; set; }
        public Bloco Bloco { get; set; }
    }
}