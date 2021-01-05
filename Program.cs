using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CPE311_TermProject
{
    class System
    {
        public static Warehouse[] warehouses = new Warehouse[100];
        public static UInt32 warehouseCounter = 0;
        static public Employee[] employees = new Employee[100];
        public static UInt32 employeeCounter = 0;
        static public void Login(object m)
        {
            try
            {
                
            
            int choice;
            while (true)
            {
                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                C.WriteLine( C.indent1 + C.indent1 + "Login to Central Supply Unit System");
                C.WriteLine( "1. Manager");
                C.WriteLine( "2. Employee");
                C.WriteLine( "3. Employee Sign up");
                C.WriteLine( "4. Exit");
                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                Console.Write(C.indent1 + "Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
               
                if (choice == 1)
                {
                    ((Manager)m).SignIn(); //managerSignIn(); 
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
                            employees[0] = new Employee(fn, ln, id, un, ps);
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
                Login(m);
            }

        }

        static public void SignIn() 
        {
            C.WriteLine( C.stars);
            C.WriteLine( C.stars);
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

        static public void loadFiles()
        {
            FileStream warehouse_file;
            FileStream employee_file;
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists("Warehouses.txt"))
            {
                warehouse_file = new FileStream("Warehouses.txt", FileMode.Open, FileAccess.Read);
                while (warehouse_file.Position < warehouse_file.Length)
                {
                    warehouses[warehouseCounter++] = (Warehouse)formatter.Deserialize(warehouse_file);
                }
            }
            else
            {
                    warehouse_file = new FileStream("Warehouses.txt", FileMode.Create);
            }
            warehouse_file.Close();
            if (File.Exists("Employees.txt"))
            {
                employee_file = new FileStream("Employees.txt", FileMode.Open, FileAccess.Read);
                while (employee_file.Position < employee_file.Length)
                {
                    employees[employeeCounter++] = (Employee)formatter.Deserialize(employee_file);
                }
                
            }
            else
            {
                employee_file = new FileStream("Employees.txt", FileMode.Create);
            }
            employee_file.Close();
        }

        static public void StoreFiles()
        {
            FileStream warehouse_file = new FileStream("Warehouses.txt", FileMode.Create, FileAccess.Write);
            FileStream employee_file = new FileStream("Employees.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(warehouse_file, warehouses);
            formatter.Serialize(employee_file, employees);
            warehouse_file.Close();
            employee_file.Close();
        }
        static void Main(string[] args)
           
        {
            Manager m = new Manager("Manager", "Manager");
            loadFiles();
            Login(m);
            //
            //Idea:::   Using the manager object to call functions;;
            //
        }
    }
}
