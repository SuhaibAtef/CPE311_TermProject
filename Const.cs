using System;
using System.Collections.Generic;
using System.Text;

namespace CPE311_TermProject
{
    static class C
    {
        public static string indent1  = new String(' ', 4);
        public static String indent2 = C.indent1 + C.indent1 + C.indent1 + C.indent1 + C.indent1;
        public static string stars = new String('*', 66);
        public static string stars2 = new String('*', 18);
        public static string stars3 = new String('*', 19);
        public static string stars4 = new String('*', 10);

        public static void WriteLine(string str)
        {
            Console.WriteLine(C.indent1 + str);
        }
    }
}
