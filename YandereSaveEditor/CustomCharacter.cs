using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace YandereSaveEditor
{
    public class CustomCharacter
    {
        public static void SetYanHair(string file, string HairID)
        {
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine("YanHair:" + HairID);
            sw.Close();
        }
        public static void SetYanHoodie(string file, string ocfile)
        {
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine("ActivateChildAl:Teacher_11:Hoodie:true");
            sw.WriteLine("Duplicate:Hoodie:YanHoodie"); //but why these lines?
            sw.WriteLine("ActivateChildAl:Teacher_11:Hoodie:false");
            sw.WriteLine("Attach:YanHoodie:YandereChan/Character/PelvisRoot/Hips");
            sw.WriteLine("RefLocalPosition:YanHoode:0:-0.9:0"); //position according to player, 0 is on top of head.
            sw.WriteLine("RefLocalRotation:YanHoodie:0:0:)"); //vector rotation.
            string[] patharray = Utility.SeperateIntoArray(file, char.Parse(@"\"));
            string texture = patharray.Last();
            sw.WriteLine("OpenTexture:" + texture);
            sw.WriteLine("Texture3:0:YanHoodie");
            sw.Close();
        }
        public static void SetCustomHair(string file, string ocfile)
        {
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine("DeliYanHair:PlayerHair:YandereChan");
            string[] patharray = Utility.SeperateIntoArray(file, char.Parse(@"\"));
            string texture = patharray.Last();
            sw.WriteLine("OpenTexture:" + texture);
            sw.WriteLine("Texture:0:PlayerHair");
            sw.WriteLine("Texture:1:PlayerHair");
            sw.WriteLine("Texture:2:PlayerHair");
            sw.Close();
        }
    }
}
