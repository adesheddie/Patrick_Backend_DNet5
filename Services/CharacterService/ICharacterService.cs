using System.Collections.Generic;
using System.Threading.Tasks;
using Patrick_Backend_DNet5.Dtos.Skills;
using Rpg_project.Dtos;
using Rpg_project.Dtos.AddCharacterDtos;
using Rpg_project.Dtos.GetCharacterDTO;
using Rpg_project.Models;

namespace Rpg_project.Sevices.CharacterService
{

    // this service needs to be injected in startup.cs
    public interface ICharacterService
    {


        Task<ServiceResponse<List<GetCharacterDTO>>> GetAll();

        Task<ServiceResponse<GetCharacterDTO>> GetSingle(int id);

        Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO new_character);

        Task<ServiceResponse<List<GetCharacterDTO>>> UpdateCharacter(UpdateCharacterDTO character);

        Task <ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter (int id);


        Task <ServiceResponse<GetCharacterDTO>> AddSkill (AddSkillDTO newSkill);

    }


}