using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.Domain
{
    public class ProfessorBloco
    {
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public int BlocoId { get; set; }
        public Bloco Bloco { get; set; }

    }
}