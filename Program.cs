using System;
using System.IO;

namespace CPE311_TermProject
{
    class System
    {
        public static Warehouse[] warehouses = new Warehouse[100];
        public static UInt32 warehouseCounter = 0;
        static public Employee[] arr = new Employee[100];

        static public void Login()
        {
            try
            {
                
            
            int choice;
            while (true)
            {
                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                Console.WriteLine(C.indent1 + C.indent1 + C.indent1 + "Login to Central Supply Unit System");
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
                        Employee.SignIn(); //employeeSignIn(); 
                        break;
                }
                else if (choice == 3)
                {
                        try
                        {
                            
                            // declare variables
                            string fn, ln, un, ps;
                            int id;
                            //print the screen
                            C.WriteLine(C.stars);
                            C.WriteLine(C.stars2 + "Employee Sign Up" + C.stars3);
                            C.WriteLine(C.stars);
                            Console.Write(C.indent1 + "Enter First Name: ");
                            fn = Console.ReadLine();
                            Console.Write(C.indent1 + "Enter Last Name: ");
                            ln = Console.ReadLine();
                            Console.Write(C.indent1 + "Enter ID: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            Console.Write(C.indent1 + "Enter Username: ");
                            un = Console.ReadLine();
                            Console.Write(C.indent1 + "Enter Password: ");
                            ps = Console.ReadLine();
                            arr[0] = new Employee(fn, ln, id, un, ps);
                            // open the file and dump the object
                            

                        }
                        catch (Exception e)
                        {
                            C.WriteLine("an error has occured please try again " + e.Message +"\n");
                        }
                }
                else if (choice == 4) 
                {
                    
                    break; 
                }
                else
                {
                    C.WriteLine("Incorrect Choice, Please try again...");
                }
            }
            }
            catch (Exception e)
            {
                C.WriteLine(e.Message + " Please try again...");
                Login();
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
            //
            //Idea:::   Using the manager object to call functions;;
            //
        }
    }
}
