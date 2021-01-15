using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CPE311_TermProject
{
    static class C
    {
        public static string indent1  = new String(' ', 4);
        public static String indent2 = C.indent1 + C.indent1 + C.indent1 + C.indent1 + C.indent1;
        public static string stars = new String('*', 66);
        public static string stars2 = new String('*', 18);
        public static string stars3 = new String('*', 25);
        public static string stars4 = new String('*', 10);
        public static string stars5= new String('*', 5);
        public static string dashes = new string('-', 66);
        public static void WriteLine(string str)
        {
            Console.WriteLine(C.indent1 + str);
        }

        public static void RURObot()
        {
            C.WriteLine("&                                            /////%%%%%  %                ");
            C.WriteLine("&                                            /////  %%%%%%           ");
            C.WriteLine("&                                          ////      %%%%%        ");
            C.WriteLine("&                                         ,,,,                           ");
            C.WriteLine("&                                        ,,,,,,     ,,,          ");
            C.WriteLine("&                                            ,,,,,,,,");
            C.WriteLine("&                                              ,,,");
            C.WriteLine("&                                                           ");
            C.WriteLine("&                                           reCAPTCHA");
            C.WriteLine("&                . . . . . . . . . . . . . . . . . . . . . . . . . . . . . ");
            C.WriteLine("&                .                                                       . ");
            C.WriteLine("&                .          ____                                         . ");
            C.WriteLine("&                .         |    |      Are You a ROBOT?                  . ");
            C.WriteLine("&                .         |____|                                        . ");
            C.WriteLine("&                .                                                       . ");
            C.WriteLine("&                . . . . . . . . . . . . . . . . . . . . . . . . . . . . .  ");
        }
        public static void RURObotNOO()
        {
            C.WriteLine("&                                            /////%%%%%  %                ");
            C.WriteLine("&                                            /////  %%%%%%           ");
            C.WriteLine("&                                          ////      %%%%%        ");
            C.WriteLine("&                                         ,,,,                           ");
            C.WriteLine("&                                        ,,,,,,     ,,,          ");
            C.WriteLine("&                                            ,,,,,,,,");
            C.WriteLine("&                                              ,,,");
            C.WriteLine("&                                                           ");
            C.WriteLine("&                                           reCAPTCHA");
            C.WriteLine("&                . . . . . . . . . . . . . . . . . . . . . . . . . . . . . ");
            C.WriteLine("&                .                                                       . ");
            C.WriteLine("&                .          ____                                         . ");
            C.WriteLine("&                .         | \\/ |      Are You a ROBOT?                  . ");
            C.WriteLine("&                .         |_/\\_|                                        . ");
            C.WriteLine("&                .                                                       . ");
            C.WriteLine("&                . . . . . . . . . . . . . . . . . . . . . . . . . . . . .  ");
        }
        public static void rURobot()
        {
            Console.Clear();
            Thread.Sleep(500);
            RURObot();
            Thread.Sleep(2000);
            Console.Clear();
            RURObotNOO();
            Thread.Sleep(3000);
            Console.Clear();
        }

    }
}
