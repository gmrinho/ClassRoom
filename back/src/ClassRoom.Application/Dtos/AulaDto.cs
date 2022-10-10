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
        [Required(ErrorMessage = "O campo {0} é obrigatório!" ),
        StringLength(50, MinimumLength = 5,
            ErrorMessage = "É permitido um minimo de 5 e um máximo de 50 caracteres neste campo.")]
        [Display(Name = "Nome da Aula")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório!" ),
        StringLength(50, MinimumLength = 3,
            ErrorMessage = "É permitido um minimo de 3 e um máximo de 50 caracteres neste campo.")]
        [Display(Name ="Nome do Curso")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!" ),
        StringLength(50, MinimumLength = 10,
            ErrorMessage = "É permitido um minimo de 3 e um máximo de 50 caracteres neste campo.")]
        [Display(Name ="Dia da aula")]        
        public string DataAula { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!" ),
        StringLength(50, MinimumLength = 2,
            ErrorMessage = "É permitido um minimo de 2 e um máximo de 50 caracteres neste campo.")]
        [Display(Name ="Professor")]        
        public string NomeProfessor { get; set; }
        public int BlocoId { get; set; }
        public BlocoDto Bloco { get; set; } 
    }
}