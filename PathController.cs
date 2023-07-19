using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace rainbow_rename
{
    internal class PathController {
        public List<String> seperatePath(string path)
        {
            string[] returnPre = path.Split('/');
            List<String> returnAft = new List<String>();
            foreach (string split in returnPre)
            {
                returnAft.Add(split);
            }
            return returnAft;
        }

        public string generatePath(string folder, string file)
        {
            string returnStr = folder + "/" + "file";

            return returnStr;
        }
    }
}





