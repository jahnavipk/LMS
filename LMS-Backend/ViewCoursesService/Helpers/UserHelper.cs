using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewCoursesService.DAO;
using ViewCoursesService.Models;

namespace ViewCoursesService.Helpers
{
    public class UserHelper: IUserHelper
    {
        private readonly IMongoCollection<CourseDAO> _courseDAO;


        public UserHelper(ILMSDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("LMSData");
            _courseDAO = database.GetCollection<CourseDAO>("CourseDetails");
        }

        public List<CourseDAO> GetAllCourses(CourseDetails course)
        {
            try
            {
                if (!string.IsNullOrEmpty(course.Technology) && !string.IsNullOrEmpty(course.StartDate) && !string.IsNullOrEmpty(course.EndDate))
                {
                    return _courseDAO.Find(x => x.Technology == course.Technology && x.CourseStartDate >= Convert.ToDateTime(course.StartDate) && x.CourseEndDate <= Convert.ToDateTime(course.EndDate) && x.IsDelete == 1).ToList();
                }
                else if (!string.IsNullOrEmpty(course.Technology) && string.IsNullOrEmpty(course.StartDate) && string.IsNullOrEmpty(course.EndDate))
                {
                    return _courseDAO.Find(x => x.Technology == course.Technology && x.IsDelete == 1).ToList();
                }
                else if (!string.IsNullOrEmpty(course.Technology) && !string.IsNullOrEmpty(course.StartDate.ToString()) && string.IsNullOrEmpty(course.EndDate.ToString()))
                {
                    return _courseDAO.Find(x => x.Technology == course.Technology && x.CourseStartDate >= Convert.ToDateTime(course.StartDate) && x.IsDelete == 1).ToList();
                }
                else if (!string.IsNullOrEmpty(course.Technology) && string.IsNullOrEmpty(course.StartDate.ToString()) && !string.IsNullOrEmpty(course.EndDate.ToString()))
                {
                    return _courseDAO.Find(x => x.Technology == course.Technology && x.CourseEndDate <= Convert.ToDateTime(course.EndDate) && x.IsDelete == 1).ToList();
                }
                else
                {
                    List<CourseDAO> courseDAOs = new List<CourseDAO>();
                    return courseDAOs;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
