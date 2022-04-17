using System;
using System.Collections.Generic;
using Rpg_project.Models;

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Rpg_project.Sevices.CharacterService;
using System.Threading.Tasks;
using Rpg_project.Dtos.AddCharacterDtos;
using Rpg_project.Dtos.GetCharacterDTO;
using Rpg_project.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Patrick_Backend_DNet5.Dtos.Skills;

namespace Rpg_project.Controllers
{

    // below will add authorization in all APIs (  [Authorize]  )
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {

        public ICharacterService _characterService { get; }

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;

        }



        [HttpGet]
        //  [HttpGet("GetAll")] // we can use this to customize the endpoint
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> Get()
        {
            // Note : extract ID from token via claims, here the User is derived from baseController.
            // var id = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value); // **************** old way *********************
            return Ok(await _characterService.GetAll());

        }
        // [AllowAnonymous] // allowing particular API without token
        [HttpGet("{id}")]  // we specify the route param


        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> GetSingle(int id)
        {


            return Ok(await _characterService.GetSingle(id));

        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {



            return Ok(await _characterService.AddCharacter(newCharacter));


        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> UpdateCharacter(UpdateCharacterDTO character)
        {

            var response = await _characterService.UpdateCharacter(character);

            if (response.Data == null) return BadRequest(response);

            return Ok(response);

        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> DeleteCharacter(int id)
        {

            var response = await _characterService.DeleteCharacter(id);

            if (response.Data == null) return BadRequest(response);

            return Ok(response);

        }


        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> AddSkill(AddSkillDTO newSkill)
        {

            return Ok(await _characterService.AddSkill(newSkill));
        }

    }


}