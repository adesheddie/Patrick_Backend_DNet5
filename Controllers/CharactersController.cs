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

namespace Rpg_project.Controllers
{


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

            return Ok(await _characterService.GetAll());

        }

        [HttpGet("{name}")]  // we specify the route param


        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> GetSingle(string name)
        {


            return Ok(await _characterService.GetSingle(name));

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

    }


}