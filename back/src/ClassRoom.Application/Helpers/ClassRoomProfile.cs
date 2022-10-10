using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassRoom.Application.Dtos;
using ClassRoom.Domain;

namespace ClassRoom.Application.Helpers
{
    public class ClassRoomProfile : Profile
    {
        public ClassRoomProfile()
        {
            CreateMap<Bloco, BlocoDto>().ReverseMap();
            CreateMap<Aula, AulaDto>().ReverseMap();
        }
    }
}