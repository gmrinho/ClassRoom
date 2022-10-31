using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.Application.Dtos
{
    public class AulaDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!" )]
        [Display(Name = "Nome da Aula")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório!" )]
        [Display(Name ="Nome do Curso")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!" )]
        [Display(Name ="Dia da aula")]        
        public string DataAula { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório!" )]
        [Display(Name ="Professor")]        
        public string NomeProfessor { get; set; }
        public int BlocoId { get; set; }
        public BlocoDto Bloco { get; set; } 
    }
}