using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YanSimSaveEditor
{
    internal class Globals
    {
        //tool global values for debugging and logging
        public static string[] errorArray = { "DefaultException" };
        public static readonly string[] arguments = Environment.GetCommandLineArgs();
        //startup args......
        public static bool debugConsole
        {
            get
            {
                if (arguments.Contains("-debugConsole"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool noDebug
        {
            get
            {
                if (arguments.Contains("-noDebug"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool noLogPrint
        {
            get
            {
                if (arguments.Contains("-noLogPrint"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool debug
        {
            get
            {
                if (arguments.Contains("-debug"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //handles the profile operations to speed up execution.
        public static string? profile { get; set; }
        //handles the student operations
        public static string? student { get; set; }











        //hair storage
        public static string[] newhair = { "PonyTail", "MaleHair0", "Succubus1", "Succubus2", "NewKuudereHair", "HorudaHair", "SuitorMaleHair1", "FeminineMaleHair", "ShyMaleHair", "SpikyMaleHair ", "RaibaruHair", "OsanaHair", "AmaiHair", "DramaQueenHair", "OccultHair1", "???", "???", "???", "SisterHair", "???", "SCPHairMesh", "CookingClubHair1", "CookingClubHair2", "CookingClubHair3", "CookingClubHair4", "CookingClubHair5", "DramaMaleHair1", "DramaMaleHair2", "28", "DramaFemaleHair1", "NewKokonaHair", "OccultHair2", "OccultHair4", "OccultHair6", "FemaleMartialHair3", "FemaleMartialHair5", "GameLeaderHair", "37", "PippiHair", "MidoriHair", "WaifuHair", "GeijuHair", "PenBoy", "PencilBoy", "MarkerGirl", "PaintbrushGirl", "MaleMartialHair1", "MaleMartialHair2", "MaleMartialHair3", "FemaleMartialHair1", "FemaleMartialHair2", "MusicHair1", "MusicHair2", "MusicHair3", "MusicHair4", "MusicHair5", "FredHair", "ShaggyHair", "ScoobyHair", "DaphneHair", "VelmaHair", "ScienceHair_1", "ScienceHair_2", "ScienceHair_3", "ScienceHair_4", "ScienceHair_5", "SportsHair1", "SportsHair2", "SportsHair3", "SportsHair4", "SportsHair5", "GardeningClubLeaderHair", "SunFlowerHair", "SakuraHair", "VioletHair", "CamelliaHair", "EyeScar_Delinquent_Hair", "CheekScar_Delinquent_Hair", "ForeheadScar_Delinquent_Hair", "MouthScar_Delinquent_Hair", "NoseScar_Delinquent_Hair", "Bully_Musume", "Bully_Kashiko", "Bully_Hana", "Bully_Kokoro", "Bully_Hoshiko", "TurtleHair", "TigerHair", "BirdHair", "DragonHair", "NurseHair", "FemaleTeacherHair1", "FemaleTeacherHair2", "FemaleTeacherHair3", "FemaleTeacherHair4", "FemaleTeacherHair5", "FemaleTeacherHair6", "PETeacher", "98", "99", "100" }; //the zero is needed to insure that extra code doesnt get written, arrays start at 0.
        public static string[] oldhair = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100" };
    }
}
