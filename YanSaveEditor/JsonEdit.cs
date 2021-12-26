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
        //do not touch this code Ben, loaf wrote it.
        //public static string path = Utility.GetJSON(); //this lets us use the 1980s students too.
        public static student GetInfo(int StudentId)
        {
            try
            {
                //gets the line with the correct student.
                string line = File.ReadLines(UtilityScript.GetJSON()).ElementAt(StudentId);
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
                Log.Error("Error while getting student JSON:" + e.ToString());
                UtilityScript.WriteError(e.ToString(), "Error");
                return tempstudent;
            }
        }
        public static string WriteInfo(student tempstudent)
        {
            //accepts student object and writes it to json file
            try
            {

                string Json = JsonConvert.SerializeObject(tempstudent);
                if (UtilityScript.ToInteger(tempstudent.ID) != 100)
                {
                    //if not last student, serialized object requires a comma.
                    Json = Json + ",";
                }
                //this next part gets the full json script as an arrey and replaces the specific line with the serialized student object
                string[] arrLine = File.ReadAllLines(UtilityScript.GetJSON());
                arrLine[UtilityScript.ToInteger(tempstudent.ID)] = Json;
                File.WriteAllLines(UtilityScript.GetJSON(), arrLine);
                return "success";

            }
            catch (Exception e)
            {
                //returns error as string
                UtilityScript.WriteError("ERROR", e.ToString());
                Log.Error("Error while writing student JSON:" + e.ToString());
                return "failed: got to horny jail *bonk*";
            }
        }
    }

    public class student
    {
        //very crappy way to make an object BUT i am not going to write a proper set; get; and ToString; methods for all of this code that is used like twice.
        //btelnyy here, this code is used more then twice.
        //DO NOT CHANGE THE ORDER OF THE STATEMENTS. I WILL BREAK YOU BACK
        public string ID { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public string Seat { get; set; }
        public string Club { get; set; }
        public string Persona { get; set; }
        public string Crush { get; set; }
        public string BreastSize { get; set; }
        public string Strength { get; set; }
        public string Hairstyle { get; set; }
        public string Color { get; set; }
        public string Eyes { get; set; }
        public string EyeType { get; set; }
        public string Stockings { get; set; }
        public string Accessory { get; set; }
        public string ScheduleTime { get; set; }
        public string ScheduleDestination { get; set; }
        public string ScheduleAction { get; set; }
        public string Info { get; set; }


        /*
        leftover code - just to make debugging simpler (not even code just a mess - ignore if not Loaflove\r 
        [ScheduleTime] => 7_7_8_13.0000_13.375_15.5_16_99
        [ScheduleDestination] => Spawn_Locker_Patrol_Seat_LunchSpot_Seat_Clean_Patrol
        [ScheduleAction] => Stand_Stand_Patrol_Sit_Eat_Sit_Clean_Patrol
        */



    }
}
