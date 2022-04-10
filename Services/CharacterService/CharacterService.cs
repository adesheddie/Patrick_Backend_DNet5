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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Rpg_project.Sevices.CharacterService
{

    // this service needs to be injected in startup.cs
    public class CharacterService : ICharacterService
    {

        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataContext _context { get; }

        public CharacterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }


        public int getUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO new_character)
        {
            Characters character = _mapper.Map<Characters>(new_character);

            character.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == getUserId());

            _context.Characters.Add(character);

            await _context.SaveChangesAsync();

            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            serviceResponse.Data = await _context.Characters.
            Where(w => w.User.Id == getUserId())
            .Select(c => _mapper.Map<GetCharacterDTO>(c)).ToListAsync();
            return serviceResponse;
        }



        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAll()
        {

            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            var result = await _context.Characters.Where(c => c.User.Id == getUserId()).ToListAsync();

            serviceResponse.Data = result.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponse;

        }



        public async Task<ServiceResponse<GetCharacterDTO>> GetSingle(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();

            var result = await _context.Characters.FirstOrDefaultAsync(x => x.Id == id && x.User.Id == getUserId());

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

                var result = await _context.Characters.FirstOrDefaultAsync(x => x.Id == character.Id);

                if (!String.IsNullOrEmpty(character.Name)) result.Name = character.Name;
                if (!String.IsNullOrEmpty((character.Class).ToString())) result.Class = character.Class;
                if (character.Skills != null) result.Skills = character.Skills;
                if (character.Defence != null) result.Defence = character.Defence;

                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Characters.Select(x => _mapper.Map<GetCharacterDTO>(x)).ToListAsync();
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
                Characters character = await _context.Characters.FirstOrDefaultAsync(x => x.Id == id);


                if (character == null)
                {

                    serviceResponse.Success = false;
                    serviceResponse.Message = "Invalid ID";

                    return serviceResponse;
                }
                _context.Characters.Remove(character);

                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Characters.Select(x => _mapper.Map<GetCharacterDTO>(x)).ToListAsync();
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