using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSM_Application.Identity.Interface;
using FSM_ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSM_BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var token = await _authService.Login(userName, password);
            
            return Ok(new { JetToken = token });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authService.Register(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
