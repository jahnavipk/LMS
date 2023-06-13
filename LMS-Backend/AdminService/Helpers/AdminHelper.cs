using AdminService.DAO;
using AdminService.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Helpers
{
    public class AdminHelper : IAdminHelper
    {

        private readonly IMongoCollection<CourseDAO> _addCourse;


        public AdminHelper(ILMSDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("LMSData");
            _addCourse = database.GetCollection<CourseDAO>("CourseDetails");
        }

        public bool AddCourse(AddCourse addCourse)
        {
            try
            {
                CourseDAO addCourseDAO = new CourseDAO();
                addCourseDAO.Technology = addCourse.Technology;
                addCourseDAO.CourseName = addCourse.CourseName;
                addCourseDAO.CourseStartDate = addCourse.CourseStartDate;
                addCourseDAO.CourseEndDate = addCourse.CourseEndDate;
                addCourseDAO.IsDelete = 1;
                _addCourse.InsertOne(addCourseDAO);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteCourse(string courseId)
        {
            try
            {
                var filter = Builders<CourseDAO>.Filter.Eq(e => e.Id, courseId);
                var update = Builders<CourseDAO>.Update.Set(t => t.IsDelete, 0);
                _addCourse.UpdateOne(filter, update);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Activate(string courseId)
        {
            try
            {
                var filter = Builders<CourseDAO>.Filter.Eq(e => e.Id, courseId);
                var update = Builders<CourseDAO>.Update.Set(t => t.IsDelete, 1);
                _addCourse.UpdateOne(filter, update);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseDAO> GetAllCourses(string isActive)
        {
            try
            {
                if (string.IsNullOrEmpty(isActive))
                {
                    return _addCourse.Find(x => true).ToList();
                }
                else if (isActive == "1")
                {
                    return _addCourse.Find(d => d.IsDelete == 1).ToList();
                }
                else if (isActive == "0")
                {
                    return _addCourse.Find(d => d.IsDelete == 0).ToList();
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
