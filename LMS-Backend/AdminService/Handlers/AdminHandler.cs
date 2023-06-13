using AdminService.DAO;
using AdminService.Helpers;
using AdminService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Handlers
{
    public class AdminHandler : IAdminHandler
    {
        public readonly IAdminHelper _adminHelper;

        public AdminHandler(IAdminHelper adminHelper)
        {
            this._adminHelper = adminHelper;

        }

        public bool AddCourse(AddCourse addCourse)
        {
            return _adminHelper.AddCourse(addCourse);
        }

        public bool DeleteCourse(string courseId)
        {
            return _adminHelper.DeleteCourse(courseId);
        }

        public List<CourseDAO> GetAllCourses(string isActive)
        {
            return _adminHelper.GetAllCourses(isActive);
        }


        public bool Activate(string courseId)
        {
            return _adminHelper.Activate(courseId);
        }
    }
}
