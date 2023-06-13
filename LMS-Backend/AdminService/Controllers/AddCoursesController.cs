using AdminService.Handlers;
using AdminService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace AdminService.Controllers
{
    [Route("/api/v1.0/lms/")]
    [ApiController]
    public class AddCoursesController : ControllerBase
    {
        private readonly IAdminHandler _adminHandler;
        public AddCoursesController(IAdminHandler adminHandler)
        {
            this._adminHandler = adminHandler;
        }

        [Authorize]
        [Route("courses/addcourse")]
        [HttpPost]
        public ActionResult AddCourse(AddCourse addCourse)
        {
            try
            {
                return Ok(_adminHandler.AddCourse(addCourse));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [Route("courses/getCourse")]
        [HttpGet]
        public ActionResult GetCourse(string isActive)
        {
            try
            {
                return Ok(_adminHandler.GetAllCourses(isActive));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
