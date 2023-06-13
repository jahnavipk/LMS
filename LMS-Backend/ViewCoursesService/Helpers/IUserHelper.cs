using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewCoursesService.DAO;
using ViewCoursesService.Models;

namespace ViewCoursesService.Helpers
{
    public interface IUserHelper
    {
        List<CourseDAO> GetAllCourses(CourseDetails course);
    }
}
