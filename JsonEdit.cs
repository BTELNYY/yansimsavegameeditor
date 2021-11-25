using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
