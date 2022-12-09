using ExamKickOff.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamKickOff.Functions
{
    internal class ProcessCSV
    {
        public ProcessCSV() { }

        public  void ReadAndProcessCSV()
        {
            CSVToModel cSVToModel = new CSVToModel();

            List<ExamRoomSchedule> examRoomSchedules = new List<ExamRoomSchedule>();
            string examCSVFile = ConfigurationSettings.AppSettings.Get("ROExamCSVFile");

            var lines = File.ReadAllLines(examCSVFile);

            //take the csv header as dictionary key 
            var header = lines.First().Split(',');

            var dicList = new List<Dictionary<string, string>>();

            //loop through all the lines except header
            foreach (string line in lines.Skip(1))
            {
                var data = line.Split(",");
                var dict = new Dictionary<string, string>();
                for (int i = 0; i < header.Length; i++)
                {
                    dict.Add(header[i], data[i]);
                }
                dicList.Add(dict);
                var examSchedule = cSVToModel.GetExamScheduleFromDictionary(dict);
                examRoomSchedules.Add(examSchedule);

            }
            var result = examRoomSchedules;

        }
    }
}
