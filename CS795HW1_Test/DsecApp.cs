using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CS795HW1_Test
{
    public class DsecApp
    {

        public bool Check_Username(String uname)
        {
            bool special_character_notpresent = Checkfor_Special_Characters(uname);
            if (uname.Length == 0)
                return false;
            else if (special_character_notpresent)
                return true;
            else
                return false;

        }

        private static bool Checkfor_Special_Characters(String uname)
        {
            Regex objAlphaPattern = new Regex("^[a-zA-Z0-9 ]*$"); ;
            bool special_character_notpresent = objAlphaPattern.IsMatch(uname);
            return special_character_notpresent;
        }


        internal bool Check_Key(string p)
        {
            return false;
        }
    }
 

    
}
