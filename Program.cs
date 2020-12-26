using System;
using System.IO;

namespace CPE311_TermProject
{
    class System
    {   
        static public void Login()
        {
            int choice;

            Console.WriteLine("*****************************************************");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("\tLogin to Central Supply Unit System");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Employee");
            Console.WriteLine("3. Employee Sign up");
            Console.WriteLine("4. Exit");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("Choice:");
            choice = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (choice == 1) { //managerSignIn(); 
                }
                if (choice == 2) { //employeeSignIn();
                }
                if (choice == 3) { //managerSignUp();
                }
                if (choice == 4) { break; }
            }
        }
        static void Main(string[] args)
           
        {
            Login();
            
        }
    }
}
