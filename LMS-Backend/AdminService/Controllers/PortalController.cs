using AdminService.Authentication;
using AdminService.Handlers;
using AdminService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace AdminService.Controllers
{
    [Route("/api/v1.0/lms/")]
    [ApiController]
    public class PortalController : ControllerBase
    {
        private readonly IPortalHandler _portalHandler;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public PortalController(IPortalHandler portalHandler, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this._portalHandler = portalHandler;
            this._jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult GetAuthentication(LoginModel loginModel)
        {
            var token = _jwtAuthenticationManager.Authenticate(loginModel.Email, loginModel.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                loginModel.Token = token;
                return Ok(loginModel);
            }
        }

        [AllowAnonymous]
        [Route("company/register")]
        [HttpPost]
        public ActionResult Register(Register register)
        {
            try
            {
                return Ok(_portalHandler.Register(register));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [AllowAnonymous]
        [Route("company/login")]
        [HttpPost]
        public ActionResult Login(Login login)
        {
            try
            {
                LoginModel loginModel = new LoginModel();

                var token = _jwtAuthenticationManager.Authenticate(login.Email, login.Password);
                if (token == null)
                {
                    return Unauthorized();
                }
                else
                {
                    loginModel.Token = token;
                }

                return Ok(_portalHandler.GetUser(login));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
