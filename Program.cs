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
                C.StarPrint();
                C.StarPrint();
                C.StarPrint();
                Console.WriteLine("\tLogin to Central Supply Unit System");
                Console.WriteLine("1. Manager");
                Console.WriteLine("2. Employee");
                Console.WriteLine("3. Employee Sign up");
                Console.WriteLine("4. Exit");
                C.StarPrint();
                C.StarPrint();
                Console.Write("Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1 || choice == 2) {
                    SignIn(); //managerSignIn(); 
                    break;
                }else if (choice == 3) {
                    Console.WriteLine("EmployeeSignUp");//EmployeeSignUp();
                }
                else if (choice == 4) { break; }
                else
                {
                    Console.Write("Incorrect Choice, Please try again...");
                    Login();
                }
            }
        }

        static public void SignIn() 
        {
            C.StarPrint();
            C.StarPrint();
            Console.Write("Enter Username:  ");
            String username = Console.ReadLine();
            Console.Write("Enter Password:  ");
            String password = Console.ReadLine();
            if (username == "Manager" && password == "Manager") 
            {
                Console.WriteLine("Manager Signed In Correctly");
            }
            else if (username == "Manager" && password == "Manager")
            {
                Console.WriteLine("Manager Signed In Correctly");
            }
            else {
                Console.WriteLine("Wrong Login information try again or sign up if you are not");
            }
        
        }
        static void Main(string[] args)
           
        {
            Login();
            
        }
    }
}
