using Microsoft.AspNetCore.Mvc;
using PollerBackEnd.Models.Core;
using PollerBackEnd.Services.Core;
using System;
using System.Threading.Tasks;

namespace PollerBackEnd.Controllers
{
    [ApiController]
    [Route("signup")]
    public class SignUpController : ControllerBase
    {
        private readonly SignUpService _service;

        public SignUpController(SignUpService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterNewUser(User user)
        {
            try
            {
                await _service.RegisterNewUserAsync(user);
                return Ok("Signup succcess");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}