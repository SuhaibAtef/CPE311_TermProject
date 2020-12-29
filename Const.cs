using System;
using System.Collections.Generic;
using System.Text;

namespace CPE311_TermProject
{
    static class C
    {
        public static string indent1  = new String(' ', 4);
        public static String indent2 = C.indent1 + C.indent1 + C.indent1 + C.indent1 + C.indent1;
        public static string stars = new String('*', 53);
        public static void WriteLine(string str)
        {
            Console.WriteLine(C.indent1 + str);
        }
    }
}
