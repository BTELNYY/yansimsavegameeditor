using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
#nullable disable
namespace YandereSaveEditor
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
        public static student GetInfoForCustom(int StudentId)
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
        public static string WriteInfoForCustom(student tempstudent)
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
        public static string GetTopicValue(string id, string topicid)
        {
            try
            {
                string path = UtilityScript.GetTopics();
                StreamReader sr = new StreamReader(path);
                string content = sr.ReadToEnd(); //reads all the content in the file
                string[] lines = UtilityScript.SeperateIntoArray(content, '\n');
                //seperate all the lines in the file by the newline character.
                string line = lines[int.Parse(id)];
                line = line.TrimEnd(','); //trim the end comma as it will screw with code
                line = line.Trim('{', '}');
                string[] pairs = UtilityScript.SeperateIntoArray(line, ',');
                //gives us a array of pairs which we can then use to get our specific topic id.
                string pair = pairs[int.Parse(topicid) + 1]; //ignores the ID and Name elements
                string[] elements = UtilityScript.SeperateIntoArray(pair, ':');
                //gives us a array with 2 elements, the Key, and the Value, the key is not important.
                string value = elements[1];
                //remove the ""
                value = value.Trim('"');
                sr.Close();
                return value;
            }
            catch (Exception e)
            {
                UtilityScript.WriteError("Error when getting topics by ID \n \n " + e.ToString(), "Error");
                Log.Error($"Error when getting topics. Student ID: {id}, Topic ID: {topicid} Error: {e}");
                return "0";
            }
        }
        public static string SetTopic(topic topic)
        {
            try
            {

                string Json = JsonConvert.SerializeObject(topic);
                if (UtilityScript.ToInteger(topic.ID) != 100)
                {
                    //if not last student, serialized object requires a comma.
                    Json = Json + ",";
                }
                //this next part gets the full json script as an arrey and replaces the specific line with the serialized student object
                string[] arrLine = File.ReadAllLines(UtilityScript.GetTopics());
                arrLine[UtilityScript.ToInteger(topic.ID)] = Json;
                File.WriteAllLines(UtilityScript.GetTopics(), arrLine);
                return "success";
            }
            catch (Exception ex)
            {
                UtilityScript.WriteError(ex.ToString(), "Error");
                Log.Error("Failed when writing topics json " + ex.ToString());
                return "error";
            }
        }
        public static topic GetTopic(int StudentId)
        {
            try
            {
                //gets the line with the correct student.
                string line = File.ReadLines(UtilityScript.GetTopics()).ElementAt(StudentId);
                Log.Debug("Getting JSON line with ID " + StudentId.ToString());
                if (line.EndsWith(@","))
                {
                    //removes the comma at the end if it exists
                    line = line.Remove(line.Length - 1);
                }
                //deserializes the line int a student object
                topic tempstudent = JsonConvert.DeserializeObject<topic>(line);
                return tempstudent;
            }
            catch (Exception e)
            {
                topic tempstudent = new topic();
                //returns error as string
                Log.Error("Error while getting topic JSON:" + e.ToString());
                UtilityScript.WriteError(e.ToString(), "Error");
                return tempstudent;
            }
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
public class topic
{
    [JsonProperty("ID")]
    public string ID { get; set; }

    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("1")]
    public string one { get; set; }

    [JsonProperty("2")]
    public string two { get; set; }

    [JsonProperty("3")]
    public string three { get; set; }

    [JsonProperty("4")]
    public string four { get; set; }

    [JsonProperty("5")]
    public string five { get; set; }

    [JsonProperty("6")]
    public string six { get; set; }

    [JsonProperty("7")]
    public string seven { get; set; }

    [JsonProperty("8")]
    public string eight { get; set; }

    [JsonProperty("9")]
    public string nine { get; set; }

    [JsonProperty("10")]
    public string ten { get; set; }

    [JsonProperty("11")]
    public string eleven { get; set; }

    [JsonProperty("12")]
    public string twelve { get; set; }

    [JsonProperty("13")]
    public string thirteen { get; set; }

    [JsonProperty("14")]
    public string fourteen { get; set; }

    [JsonProperty("15")]
    public string fifteen { get; set; }

    [JsonProperty("16")]
    public string sixteen { get; set; }

    [JsonProperty("17")]
    public string seventeen { get; set; }

    [JsonProperty("18")]
    public string eighteen { get; set; }

    [JsonProperty("19")]
    public string nineteen { get; set; }

    [JsonProperty("20")]
    public string twenty { get; set; }

    [JsonProperty("21")]
    public string twentyone { get; set; }

    [JsonProperty("22")]
    public string twentytwo { get; set; }

    [JsonProperty("23")]
    public string twentythree { get; set; }

    [JsonProperty("24")]
    public string twentyfour { get; set; }

    [JsonProperty("25")]
    public string twentyfive { get; set; }

    [JsonProperty("")]
    public string twentysix { get; set; }

    [JsonProperty(" ")]
    public string twentyseven { get; set; }

}