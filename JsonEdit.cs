using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace YanSimSaveEditor
{
    public static class JSONEdit
    {
        static string path = @".\YandereSimulator_Data\StreamingAssets\JSON\Students.json";
        public static student GetInfo(int StudentId)
        {
            

            try
            {
                //gets the line with the correct student.
                string line = File.ReadLines(path).ElementAt(StudentId);
                if (line.EndsWith(@","))
                {
                    //removes the comma at the end if it exists
                    line = line.Remove(line.Length - 1);
                }
               //deserializes the line int a student object
                student tempstudent = JsonConvert.DeserializeObject<student>(line);
                return tempstudent;
            }
            catch (Exception e)
            {
                student tempstudent = new student();
                //returns error as string
                Utility.WriteError("ERROR", e.ToString());
                return tempstudent;
            }
        }
        public static string WriteInfo(student tempstudent)
        {
            //accepts student object and writes it to json file
            try
            {

                string Json = JsonConvert.SerializeObject(tempstudent);
                if (tempstudent.ID != 100)
                {
                    //if not last student, serialized object requires a comma.
                    Json = Json + ",";
                }
                //this next part gets the full json script as an arrey and replaces the specific line with the serialized student object
                string[] arrLine = File.ReadAllLines(path);
                arrLine[tempstudent.ID] = Json;
                File.WriteAllLines(path, arrLine);
                return "success";

            }
            catch (Exception e)
            {
                //returns error as string
                Utility.WriteError("ERROR", e.ToString());
                return "failed: got to horny jail *bonk*";
            }
        }
    }

    public class student
    {
        //very crappy way to make an object BUT i am not going to write a proper set; get; and ToString; methods for all of this code that is used like twice.
        public string ScheduleTime { get; set; }
        public string ScheduleDestination { get; set; }
        public string ScheduleAction { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
        public int Gender { get; set; }
        public int Seat { get; set; }
        public int Club { get; set; }
        public int Class { get; set; }
        public int Persona { get; set; }
        public int Crush { get; set; }
        public double BreastSize { get; set; }
        public int Strength { get; set; }
        public int HairStyle { get; set; }
        public string Color { get; set; }
        public string Eyes { get; set; }
        public string Eyetype { get; set; }
        public string Stockings { get; set; }
        public int Accessory { get; set; }
        public string Info { get; set; }
        

        /*
        leftover code - just to make debugging simpler (not even code just a mess - ignore if not Loaflove\r 
        [ScheduleTime] => 7_7_8_13.0000_13.375_15.5_16_99
        [ScheduleDestination] => Spawn_Locker_Patrol_Seat_LunchSpot_Seat_Clean_Patrol
        [ScheduleAction] => Stand_Stand_Patrol_Sit_Eat_Sit_Clean_Patrol
        */



    }
}
