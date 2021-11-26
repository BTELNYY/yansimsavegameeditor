using System;
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
        public static string Delete(string JSONPath, string name)
        {
            string JSON = @" {""ID"":""100"",""Name"":""Info - chan"",""RealName"":"" d "",""Gender"":""1"",""Class"":""1"",""Seat"":""1"",""Club"":""99"",""Persona"":""99"",""Crush"":""1"",""BreastSize"":""1"",""Strength"":""99"",""Hairstyle"":""1"",""Color"":""White"",""Eyes"":""Black"",""EyeType"":""N / A"",""Stockings"":""None"",""Accessory"":""1"",""ScheduleTime"":""1"",""ScheduleDestination"":""Nothing"",""ScheduleAction"":""Nothing"",""Info"":""Trying to look up my information? Dont bother. There is nothing that you need to know about me. Youre a client, and Im a provider. Thats all we need to know about each other.""} ";



            student nir = JsonConvert.DeserializeObject<student>(JSON);
            Utility.WriteError(nir.ID.ToString(), nir.Name.ToString());
            return "";



        }
    }

    public class student
    {
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
        [ScheduleTime] => 7_7_8_13.0000_13.375_15.5_16_99
        [ScheduleDestination] => Spawn_Locker_Patrol_Seat_LunchSpot_Seat_Clean_Patrol
        [ScheduleAction] => Stand_Stand_Patrol_Sit_Eat_Sit_Clean_Patrol
        */



    }
}
