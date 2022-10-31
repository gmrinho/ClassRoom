using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRoom.Application.Dtos
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        //Não esquece de comentar o "Token', quando for att o banco de dados e as tabelas.
        public string Token { get; set; }
    }
}