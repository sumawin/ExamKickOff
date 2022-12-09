using ExamKickOff.Model;
using Newtonsoft.Json;
using System.Configuration;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Security.Policy;
using System.Xml;
using ExamKickOff.Functions;
using ExamKickOff.Model;
namespace ExamKickOff
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            //Processing CSV File
            ProcessCSV processCSV = new ProcessCSV();
            processCSV.ReadAndProcessCSV();            
            Application.Run(new Form1());
        }      


    }
}