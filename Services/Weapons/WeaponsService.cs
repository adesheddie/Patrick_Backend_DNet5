using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Patrick_Backend_DNet5.Dtos.Weapon;
using Rpg_project.Data;
using Rpg_project.Dtos.AddCharacterDtos;
using Rpg_project.Dtos.GetCharacterDTO;
using Rpg_project.Models;

namespace Patrick_Backend_DNet5.Services.Weapons
{
    public class WeaponsService : IWeaponsService
    {

        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public WeaponsService(DataContext dbContext, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _context = dbContext;

        }
        public int getUserId() => int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public DbContext DbContext { get; }

        public async Task<ServiceResponse<GetCharacterDTO>> AddWeapon(AddWeaponDTO new_weapon)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();

            try
            {

                var character = await _context.Characters.
                FirstOrDefaultAsync(x => x.Id == new_weapon.CharacterId && x.User.Id == getUserId());
                if (character == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Invalid ID";
                }

                var newWeapon = new Weapon
                {
                    Name = new_weapon.Name,
                    Damage = new_weapon.Damage,
                    Character = character
                };

                _context.Weapons.Add(newWeapon);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);


                return serviceResponse;
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }
        }

        public Task<ServiceResponse<int>> DeleteWeapon()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResponse<List<Weapon>>> GetAll(int characterId)
        {
            var serviceResponse = new ServiceResponse<List<Weapon>>();
            var result = await _context.Weapons.Where(x => x.Character.Id == characterId).ToListAsync();

            if (result == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No Results for this character ID";

            }
            else
            {
                serviceResponse.Data = result;

            }
            return serviceResponse;
        }

        public Task<ServiceResponse<int>> UpdateWeapon()
        {
            throw new System.NotImplementedException();
        }
    }

}