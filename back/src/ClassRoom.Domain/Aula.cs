using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRoom.Domain
{
    public class Aula
    {  
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Curso { get; set; }
        public DateTime? DataAula { get; set; }
        public string NomeProfessor { get; set; }
        public int BlocoId { get; set; }
        public Bloco Bloco { get; set; }
        
    }
}