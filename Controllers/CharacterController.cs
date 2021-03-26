using Microsoft.AspNetCore.Mvc;
using RoBHo_GameEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterLogic _characterLogic;

        public CharacterController(ICharacterLogic characterLogic)
        {
            _characterLogic = characterLogic;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            try
            {
                var response = _characterLogic.GetAll();
            
                if (response == null || response.Count == 0)
                    return BadRequest(new { message = "no characters found" });

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.ToString() });
            }
        }
    }
}
