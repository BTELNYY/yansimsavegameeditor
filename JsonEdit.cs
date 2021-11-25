using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace YanSimSaveEditor
{
    public class JSONEdit
    {
        public static string Delete(string JSONPath, string name)
        {
     

            //creates a key
            try
            {
                return "succeeded";
            }
            catch (Exception e)
            {
                //returns error as string
                return e.ToString();
            }
        }
    }

    public class student
    {
        private int ID;
        private string Name;
        private string RealName;
        private int Gender;
        private int Seat;
        private int Class;
        private int Club;
        private int persona;
        private int Crush;
        private double bustSize;
        private int Strength;
        private int HairStyle;
        private string Color;
        private string Eyes;
        private string EyeType;
        private string Stockings;
        private int Accessory;
        private string Info;
        /*
         [ScheduleTime] => 7_7_8_13.0000_13.375_15.5_16_99
             [ScheduleDestination] => Spawn_Locker_Patrol_Seat_LunchSpot_Seat_Clean_Patrol
 [ScheduleAction] => Stand_Stand_Patrol_Sit_Eat_Sit_Clean_Patrol
        */


        public static string Delete(string JSONPath, string name)
        {


            //creates a key
            try
            {
                return "succeeded";
            }
            catch (Exception e)
            {
                //returns error as string
                return e.ToString();
            }
        }
    }
}
