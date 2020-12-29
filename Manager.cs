using System;
using System.Collections.Generic;
using System.Text;

namespace CPE311_TermProject
{
    class Manager 
    {
        string username;
        string password;

        public Manager(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public static void SignIn()
        {
            Console.WriteLine(C.indent1 + C.stars);
            Console.WriteLine(C.indent1 + C.stars);
            Console.Write(C.indent1 + "Enter Username:  ");
            String username = Console.ReadLine();
            Console.Write(C.indent1 + "Enter Password:  ");
            String password = Console.ReadLine();
            if (username == "Manager" && password == "Manager")
            {
                Console.WriteLine("Manager Signed In Correctly"); /// Manager Main Screen
            }
            else
            {
                Console.WriteLine("Wrong Login information try again or sign up if you are not");
            }
        }
    }
}
