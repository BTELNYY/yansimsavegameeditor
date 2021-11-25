using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace YanSimSaveEditor
{
    public class JSONEdit
    {
        public static string Delete(string JSONPath, string name)
        {


            student product = new student();

            product.Name = "Apple";
            Utility.WriteError(JsonConvert.SerializeObject(product), "test");
           return JsonConvert.SerializeObject(product);

            

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
        public double Bustsize { get; set; }
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
