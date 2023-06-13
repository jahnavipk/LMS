using Microsoft.AspNetCore.Mvc;
using System;
using ViewCoursesService.Handlers;
using ViewCoursesService.Models;

namespace ViewCoursesService.Controllers
{
    [Route("/api/v1.0/lms/courses/")]
    [ApiController]
    public class SearchCoursesController : ControllerBase
    {
        private readonly IUserHandler _userHandler;

        public SearchCoursesController(IUserHandler userHandler)
        {
            this._userHandler = userHandler;
        }

        [Route("info/get")]
        [HttpPost]
        public ActionResult TechnologyInfo(CourseDetails course)
        {
            try
            {
                return Ok(_userHandler.GetAllCourses(course));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
