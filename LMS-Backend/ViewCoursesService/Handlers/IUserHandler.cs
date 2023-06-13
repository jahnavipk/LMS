using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewCoursesService.DAO;
using ViewCoursesService.Models;

namespace ViewCoursesService.Handlers
{
    public interface IUserHandler
    {
        List<CourseDAO> GetAllCourses(CourseDetails course);
    }
}
