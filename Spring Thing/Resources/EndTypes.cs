using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    public class EndTypes
    {
        public static List<string> Ends;

        static EndTypes()
        {
            string CEG = @"CEG";
            string CENG = @"CENG";
            string OEG = @"OEG";
            string OENG = @"OENG";

            Ends = new List<string>();

            Ends.Add(CEG);
            Ends.Add(CENG);
            Ends.Add(OEG);
            Ends.Add(OENG);
        }
    }
}
