using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewCoursesService.DAO;
using ViewCoursesService.Helpers;
using ViewCoursesService.Models;

namespace ViewCoursesService.Handlers
{
    public class UserHandler : IUserHandler
    {
        public readonly IUserHelper _userHelper;

        public UserHandler(IUserHelper userHelper)
        {
            this._userHelper = userHelper;
        }

        public List<CourseDAO> GetAllCourses(CourseDetails course)
        {
            return _userHelper.GetAllCourses(course);
        }
    }
}
