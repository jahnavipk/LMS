using AdminService.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Controllers
{
    [Route("/api/v1.0/lms/")]
    [ApiController]
    public class DeleteCoursesController : ControllerBase
    {
        private readonly IAdminHandler _adminHandler;
        public DeleteCoursesController(IAdminHandler adminHandler)
        {
            this._adminHandler = adminHandler;
        }

        [Route("courses/delete/{courseId}")]
        [HttpDelete]
        public ActionResult DeleteCourse(string courseId)
        {
            try
            {
                return Ok(_adminHandler.DeleteCourse(courseId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [Route("courses/activate/{courseId}")]
        [HttpGet]
        public ActionResult ActivateCourse(string courseId)
        {
            try
            {
                return Ok(_adminHandler.Activate(courseId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
