using System;
using System.IO;

namespace CPE311_TermProject
{
    class System
    {   

       static public void Login()
        {
            int choice;



            while (true)
            {
                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                Console.WriteLine(C.indent1 + "\tLogin to Central Supply Unit System");
                Console.WriteLine(C.indent1 + "1. Manager");
                Console.WriteLine(C.indent1 + "2. Employee");
                Console.WriteLine(C.indent1 + "3. Employee Sign up");
                Console.WriteLine(C.indent1 + "4. Exit");
                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                Console.Write(C.indent1 + "Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Manager.SignIn(); //managerSignIn(); 
                    break;
                } 
                else if (choice == 2)
                {
                    SignIn(); //employeeSignIn(); 
                    break;
                }
                else if (choice == 3)
                {
                    Console.WriteLine("EmployeeSignUp");//EmployeeSignUp();
                }
                else if (choice == 4) { break; }
                else
                {
                    Console.Write("Incorrect Choice, Please try again...");
                }
            }

        }

        static public void SignIn() 
        {
            Console.WriteLine(C.indent1 + C.stars);
            Console.WriteLine(C.indent1 + C.stars);
            Console.Write(C.indent1 + "Enter Username:  ");
            String username = Console.ReadLine();
            Console.Write(C.indent1 + "Enter Password:  ");
            String password = Console.ReadLine();
            if (username == "Manager" && password == "Manager") 
            {
                Console.WriteLine("Manager Signed In Correctly");
            }
            else 
            {
                Console.WriteLine("Wrong Login information try again or sign up if you are not");
            }
        
        }
        static void Main(string[] args)
           
        {
            Manager m = new Manager("Manager", "Manager");
            Login();
        }
    }
}
