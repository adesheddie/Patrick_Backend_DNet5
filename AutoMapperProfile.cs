using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Patrick_Backend_DNet5.Dtos.Skills;
using Patrick_Backend_DNet5.Dtos.Weapon;
using Patrick_Backend_DNet5.Models;
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
            CreateMap<Weapon,GetWeaponDTO>();
            CreateMap<Skill,GetSkillDTO>();
        }
        
    }
}