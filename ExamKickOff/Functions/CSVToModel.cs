using ExamKickOff.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace ExamKickOff.Functions
{
    internal class CSVToModel
    {
        public CSVToModel() { }
        public  ExamRoomSchedule GetExamScheduleFromDictionary(Dictionary<string, string> dict)
        {
            ExamRoomSchedule schedule = new ExamRoomSchedule();

            var dte = ParseExamStartTime(dict["Exam Date"], dict["Start Time"]);
            schedule.ExamStartTime = dte;


            string[] duration = checkNullEmpty(dict["Duration"]).Split(' ');
            int hours = Convert.ToInt32(duration[0]);
            schedule.Duration = ConvertToMin(hours);

            string courseId = checkNullEmpty(dict["Subject"]) + checkNullEmpty(dict["Catalog Nbr"]);
            schedule.CourseId= courseId;

            schedule.Section = checkNullEmpty(dict["Section"]);

            schedule.InstructorName = checkNullEmpty(dict["Instructor Name"]);

            schedule.BuildingName = checkNullEmpty(dict["Bldg"]);

            schedule.ExamVenue = checkNullEmpty(dict["Venue"]);

            int NumOfStudents = Convert.ToInt32(checkNullEmpty(dict["Nbr of Students"]));

            schedule.NumOfStudents = NumOfStudents;

            schedule.InvigilatorName = checkNullEmpty(dict["Invigilator"]);

            schedule.SpecialAccess = "";//need to check which column corresponds to this property;

            bool isNeedITSupport= checkNullEmpty(dict["Invigilator"])=="Y"?true: false;

            schedule.NeedITSupport = isNeedITSupport;

            schedule.lstdictionary = dict;
           
            return schedule;


        }
        public static int ConvertToMin(int Hours)
        {
            return Hours * 60;
        }

        public string checkNullEmpty(string? item)
        {
            if (string.IsNullOrEmpty(item))
               return "";
            else return item.Trim();            
        }

        public DateTime ParseExamStartTime(string date,string time)
        {          

            string[] dateString = date.Split('/');
            DateTime enter_date = Convert.ToDateTime(dateString[1] + "/" + dateString[0] + "/" + dateString[2]);
            var dateTime = enter_date.ToShortDateString() + " " + time;
            
            var dtc = DateTime.Parse(dateTime); 

            return dtc;
        }
    }
}
