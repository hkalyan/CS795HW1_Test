using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CS795HW1_Test
{
    public class DsecApp
    {
        Hashtable roles = new Hashtable();
        HashSet<string> usernames = new HashSet<string>();
        /*
         * Initialize the roles and
         * Usernames here 
         */
        public DsecApp()
        {
            Add_Roles();
            Add_Usernames();
        }

        private void Add_Usernames()
        {
            usernames.Add("hkalyan");
            usernames.Add("mukka");
            usernames.Add("admin");
            usernames.Add("browser");
            usernames.Add("buyer");
            usernames.Add("seller");
        }

        private void Add_Roles()
        {
            roles.Add(12, "Browser");
            roles.Add(13, "Buyer");
            roles.Add(14, "Seller");
            roles.Add(15, "Administrator");
        }
        
        public bool Check_Username(String uname)
        {
            bool special_character_notpresent = Checkfor_Special_Characters(uname);
            if (uname.Length == 0)
                return false;
            else if (special_character_notpresent)
            {
                if (usernames.Contains(uname))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private static bool Checkfor_Special_Characters(String uname)
        {
            Regex objAlphaPattern = new Regex("^[a-zA-Z0-9 ]*$"); ;
            bool special_character_notpresent = objAlphaPattern.IsMatch(uname);
            return special_character_notpresent;
        }
      

        internal bool Check_Key(String role_key)
        {
            if (!Checkfor_Numbers(role_key))
                return false;
            if (role_key.Trim().Length == 0)
                return false;
            if (roles.ContainsKey(Int32.Parse(role_key)))
                return true;
            else
                return false;
        }
        private static bool Checkfor_Numbers(String key)
        {
            Regex numberPattern = new Regex("^[0-9]*$"); ;
            bool only_numbers_present = numberPattern.IsMatch(key);
            return only_numbers_present;
        }

    }
 

    
}
