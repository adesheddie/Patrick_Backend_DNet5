using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Rpg_project.Models;
using System.Threading.Tasks;
using Rpg_project.Dtos.GetCharacterDTO;
using Rpg_project.Dtos.AddCharacterDtos;
using AutoMapper;
using Rpg_project.Dtos;
using Rpg_project.Data;

namespace Rpg_project.Sevices.CharacterService
{

    // this service needs to be injected in startup.cs
    public class CharacterService : ICharacterService
    {

        private readonly IMapper _mapper;
        public DataContext _context { get; }

        public CharacterService(IMapper mapper,DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        private readonly List<Characters> characters = new List<Characters>{

            new Characters(),
            new Characters{Id=1,Name = "adesh"}
        };


        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO new_character)
        {
            Characters character = _mapper.Map<Characters>(new_character);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);

            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponse;
        }



        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAll()
        {

            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            var result = characters.Select(s => _mapper.Map<GetCharacterDTO>(s)).ToList();

            serviceResponse.Data = result;
            return serviceResponse;

        }



        public async Task<ServiceResponse<GetCharacterDTO>> GetSingle(string name)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();

            var result = characters.FirstOrDefault(x => x.Name == name);

            if (result == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Not Found";
            }

            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(result);

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> UpdateCharacter(UpdateCharacterDTO character)
        {

            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            try
            {

                var result = characters.FirstOrDefault(x => x.Id == character.Id);

                if (!String.IsNullOrEmpty(character.Name)) result.Name = character.Name;
                if (!String.IsNullOrEmpty((character.Class).ToString())) result.Class = character.Class;
                if (character.Skills != null) result.Skills = character.Skills;
                if (character.Defence != null) result.Defence = character.Defence;

                serviceResponse.Data = characters.Select(x => _mapper.Map<GetCharacterDTO>(x)).ToList();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }

        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            try
            {
                var result = characters.FirstOrDefault(x => x.Id == id);


                if (result == null)
                {

                    serviceResponse.Success = false;
                    serviceResponse.Message = "Invalid ID";

                    return serviceResponse;
                }
                characters.Remove(result);

                serviceResponse.Data = characters.Select(x => _mapper.Map<GetCharacterDTO>(x)).ToList();
                return serviceResponse;

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }



        }
    }

}