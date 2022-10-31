using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.Application.Dtos
{
    public class BlocoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!" )]
        [Display(Name ="Nome do Bloco")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório!" )]
        [Display(Name ="Status do Bloco")]
        public string StatusBloco { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório!" )]
        [Display(Name ="Local do bloco (ponto de referencia)")]
        public string Local { get; set; }
        
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage ="Não é uma imagem válida. (gif, jpg, jpeg, pmb ou png)")]
        public string ImageURL { get; set; }
        public int UserId { get; set; }

        public UserDto UserDto { get; set; }
        
        public IEnumerable<AulaDto> Aulas { get; set; }      
    }
}