using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamKickOff.Model
{
    internal class ExamRoomSchedule
    {
        public DateTime ExamStartTime { get; set; }
        public int Duration { get; set; }
        public string CourseId { get; set; }
        public string Section { get; set; }
        public string InstructorName { get; set; }
        public string BuildingName { get; set; }
        public string ExamVenue { get; set; }
        public Int32 NumOfStudents { get; set; }
        public string InvigilatorName { get; set; }
        public string SpecialAccess { get; set; }
        public bool NeedITSupport { get; set; }
        public Dictionary<string, string> lstdictionary { get; set; }

    }
}
