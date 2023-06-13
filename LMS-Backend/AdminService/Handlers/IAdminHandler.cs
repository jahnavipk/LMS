﻿using AdminService.DAO;
using AdminService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Handlers
{
    public interface IAdminHandler
    {
       
        bool AddCourse(AddCourse addCourse);

        bool DeleteCourse(string courseId);

        bool Activate(string courseId);

        List<CourseDAO> GetAllCourses(string isActive);
        
    }
}
