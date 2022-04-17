using System.Collections.Generic;
using System.Threading.Tasks;
using Patrick_Backend_DNet5.Dtos.Weapon;
using Rpg_project.Dtos.GetCharacterDTO;
using Rpg_project.Models;
namespace Patrick_Backend_DNet5.Services.Weapons
{
    public interface IWeaponsService
    {
        Task<ServiceResponse<List<Weapon>>> GetAll(int characterId);

        Task<ServiceResponse<GetCharacterDTO>> AddWeapon(AddWeaponDTO new_character);

        Task<ServiceResponse<int>> UpdateWeapon();

        Task<ServiceResponse<int>> DeleteWeapon();
    }
}