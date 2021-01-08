using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace CPE311_TermProject
{
    class System
    {   //
        // Main System / Screen 
        //
        public static Warehouse[] warehouses = new Warehouse[100];
        public static UInt32 warehouseCounter = 0;
        public static Employee[] employees = new Employee[100];
        public static UInt32 employeeCounter = 0;
        public static List<SupplyDocuments> supplyDocuments = new List<SupplyDocuments>();
        static public void Login()
        {
            Manager m = new Manager("Manager", "Manager");
            try
            {
                
            
            int choice;
            while (true)
            {


                Console.Clear();
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
                    //
                    // ManagerSignIn
                    //

                    m.SignIn(); 
                    break;
                } 
                else if (choice == 2)
                {
                        //
                        // EmployeeSignIn
                        //

                        Console.Clear();
                        Employee.SignIn();  
                        break;
                }
                else if (choice == 3)
                {
                        //
                        // EmployeeSignUP
                        //

                        Console.Clear();
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
                            employees[employeeCounter++] = new Employee(fn, ln, id, un, ps);
                            StoreFiles();

                            //
                            // open the file and dump the object
                            //

                        }
                        catch (Exception e)
                        {
                            C.WriteLine("an error has occured please try again " + e.Message +"\n");
                        }
                }
                else if (choice == 4) 
                {
                        //
                        // Exiting the Loop and the program;
                        //             
                        break; 
                }
                else
                {
                    C.WriteLine("Incorrect Choice, Please try again...");
                }
            }
            }
            catch (Exception e)
            {   //
                // Retry Login  if the user failed 
                //
                C.WriteLine(e.Message + " Please try again...");
                Login();
            }

        }
        //
        //Loading all the files
        //when (opening the program) / restoring the data
        //
        static public void loadFiles()
        {
            FileStream warehouse_file;
            FileStream employee_file;
            FileStream supplyDocuments_file;

            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists("Warehouses.txt"))
            {
                warehouse_file = new FileStream("Warehouses.txt", FileMode.Open, FileAccess.Read);
                warehouseCounter = 0;
                while (warehouse_file.Position < warehouse_file.Length)
                {
                    warehouses[warehouseCounter++] = (Warehouse)(formatter.Deserialize(warehouse_file));
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
                employeeCounter = 0;
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


            if (File.Exists("SupplyDocuments.txt"))
            {
                supplyDocuments_file = new FileStream("SupplyDocuments.txt", FileMode.Open, FileAccess.Read);
                int supplyDocumentsCounter = 0;
                while (supplyDocuments_file.Position < supplyDocuments_file.Length)
                {
                    supplyDocuments.Add((SupplyDocuments)formatter.Deserialize(supplyDocuments_file));
                }

            }
            else
            {
                supplyDocuments_file = new FileStream("SupplyDocuments.txt", FileMode.Create);
            }
            supplyDocuments_file.Close();
        }
        //
        //Updating the whole data when any change to the data happens.
        //
        static public void StoreFiles()
        {
            FileStream warehouse_file = new FileStream("Warehouses.txt", FileMode.Create, FileAccess.Write);
            FileStream employee_file = new FileStream("Employees.txt", FileMode.Create, FileAccess.Write);
            FileStream supplyDocuments_file = new FileStream("SupplyDocuments.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            for(int i =0; i < warehouseCounter; i++)
            {
                formatter.Serialize(warehouse_file, warehouses[i]);
            }
            for (int i = 0; i < employeeCounter; i++)
            {
                formatter.Serialize(employee_file, employees[i]);
            }
            for (int i = 0; i < supplyDocuments.Count; i++)
            {
                formatter.Serialize(supplyDocuments_file, supplyDocuments[i]);
            }
            
            warehouse_file.Close();
            employee_file.Close();
            supplyDocuments_file.Close();
        }
        static void Main(string[] args)
           
        {
            /// <summary>
            /// for debuging, I added this function to increase the days that a supply document has , so we would be able to delete them 
            /// </summary>
            supplyDocuments.Add(new SupplyDocuments(1, "something", 25, 30, "suhaib", "h"));
            supplyDocuments[0].changeTime(181);
            
            loadFiles();
            Login();
        }
    }
}
