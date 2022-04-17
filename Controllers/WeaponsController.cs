using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patrick_Backend_DNet5.Dtos.Weapon;
using Patrick_Backend_DNet5.Services.Weapons;
using Rpg_project.Dtos.GetCharacterDTO;
using Rpg_project.Models;

namespace Patrick_Backend_DNet5.Controllers
{


    [Route("[Controller]")]
    [ApiController]
    [Authorize]
    public class WeaponsController : ControllerBase
    {


        private readonly IWeaponsService _weaponsService;

        public WeaponsController(IWeaponsService weaponsService)
        {
            _weaponsService = weaponsService;

        }



        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> AddWeapon(AddWeaponDTO new_weapon)
        {
            var result = await _weaponsService.AddWeapon(new_weapon);

            if (result.Success == false)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

    }
}