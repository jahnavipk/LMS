using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewCoursesService.DAO
{
    public class LMSDBSettings : ILMSDBSettings
    {
        public string LMSCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string LMSCourse { get; set; }
    }
}
