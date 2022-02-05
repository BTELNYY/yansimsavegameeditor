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
        public static void SetTopic(string id, string topicid, string value)
        {
            try
            {
                string[] topics = { "-1 ","0" ,"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27" };
                string[] topicvalues = { };
                foreach (string topic in topics)
                {
                    string s = GetTopicValue(id, topic);
                    topicvalues = topicvalues.Append(s).ToArray();
                }
                DebugConsole.WriteLineColor(string.Join(',', topicvalues), ConsoleColor.White);
                topicvalues[int.Parse(topicid) - 1] = value;
                //aww shit, here we go again.
                string name = GetTopicValue(id, "0");
                string jsonid = GetTopicValue(id, "-1");
                string output = "{\"ID\":\"" + jsonid + "\",\"Name\":\"" + name + "\"";
                if (id == "100")
                {
                    int counter = 1;

                    foreach (string s in topicvalues)
                    {
                        if (counter > 25)
                        {
                            output += $",\"{string.Empty}\":\"{s}\"";
                        }
                        else
                        {
                            output += $",\"{counter}\":\"{s}\"";
                        }
                        counter++;
                    }
                    UtilityScript.WriteInfo(output, "test");
                    UtilityScript.LineChange(output, UtilityScript.GetTopics(), int.Parse(id));
                }
                else
                {
                    int counter = 1;
                    foreach (string s in topicvalues)
                    {
                        if (counter > 25)
                        {
                            output += $",\"{string.Empty}\":\"{s}\"";
                        }
                        else
                        {
                            output += $",\"{counter}\":\"{s}\"";
                        }
                        counter++;
                    }
                    UtilityScript.WriteInfo(output, "test");
                    UtilityScript.LineChange(output, UtilityScript.GetTopics(), int.Parse(id));
                }
            }
            catch (Exception ex)
            {
                UtilityScript.WriteError(ex.ToString(), "Error");
            }
        }
    }
}

    

public class student
    {
        //very crappy way to make an object BUT i am not going to write a proper set; get; and ToString; methods for all of this code that is used like twice.
        //btelnyy here, this code is used more then twice.
        //DO NOT CHANGE THE ORDER OF THE STATEMENTS. I WILL BREAK YOU BACK
        public string ID { get; }
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