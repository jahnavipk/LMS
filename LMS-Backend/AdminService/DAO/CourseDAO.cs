using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.DAO
{
    public class CourseDAO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string Technology { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public DateTime CourseStartDate { get; set; }
        [Required]
        public DateTime CourseEndDate { get; set; }

        public int IsDelete { get; set; }
    }
}
