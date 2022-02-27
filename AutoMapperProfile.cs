using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Rpg_project.Dtos.AddCharacterDtos;
using Rpg_project.Dtos.GetCharacterDTO;
using Rpg_project.Models;

namespace Rpg_project
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile(){
            CreateMap<Characters,GetCharacterDTO>();
            CreateMap<AddCharacterDTO,Characters>();
        }
        
    }
}