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
        public static List<SupplyDocument> supplyDocuments = new List<SupplyDocument>();
        static public void Login()
        {
            Manager m = new Manager("Manager", "Manager");
            try
            {
                
            
            int choice;
            while (true)
            {

                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                C.WriteLine( C.indent1 + C.indent1 + C.indent1 + "Login to Central Supply Unit System");
                C.WriteLine( "1. Manager");
                C.WriteLine( "2. Employee");
                C.WriteLine( "3. Employee Sign up");
                C.WriteLine( "4. Exit");
                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                Console.Write(C.indent1 + "Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                //
                // ManagerSignIn
                //
                if (choice == 1)
                {
                    

                    m.SignIn(); 
                    break;
                } 

                //
                // EmployeeSignIn
                //
                else if (choice == 2)
                {
                        

                        Console.Clear();
                        Employee.SignIn();  
                        break;
                }
                //
                // EmployeeSignUP
                //
                else if (choice == 3)
                {

                        Console.Clear();
                        try
                        {
                            string fn, ln, un, ps;
                            int id;
                            C.WriteLine(C.stars);
                            C.WriteLine(C.stars3 + "Employee Sign Up" + C.stars3);
                            C.WriteLine(C.stars);
                            Console.Write(C.indent1 + "Enter First Name: ");
                            fn = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(fn))
                            {
                                throw new FormatException();

                            }
                            Console.Write(C.indent1 + "Enter Last Name: ");
                            ln = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(ln))
                            {
                                throw new FormatException();
                            }
                            Console.Write(C.indent1 + "Enter ID: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            Console.Write(C.indent1 + "Enter Username: ");
                            un = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(un))
                            {
                                throw new FormatException();
                            }
                            Console.Write(C.indent1 + "Enter Password: ");
                            ps = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(ps))
                            {
                                throw new FormatException();
                            }
                            if (!isEmployeeExists(un))
                            {
                                employees[employeeCounter++] = new Employee(fn, ln, id, un, ps);
                                StoreFiles();
                                Console.Clear();
                            }
                            else
                            {
                                C.WriteLine("Username already Exists");
                            }


                        }
                        catch (Exception e)
                        {
                            C.WriteLine("an error has occured please try again " + e.Message +"\n");
                        }
                }

                //
                // Exiting the Loop and the program;
                //
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
            //
            // Retry Login  if the user failed 
            //
            catch (Exception e)
            {   
                C.WriteLine(e.Message + " Please try again...");
                Login();
            }

        }
        //
        //viewWarehouses
        //
        static public void viewWarehouses()
        {
            for (int i = 0; i < System.warehouseCounter; i++)
            {
                System.warehouses[i].viewWarehouse();
            }
        }
        static public void viewEmployees()
        {
            for (int i = 0; i < System.employeeCounter; i++)
            {
                System.employees[i].viewEmployee();
            }
        }
        //
        //CheckEmployeeExists
        //
        static public bool isEmployeeExists(string username)
        {
            
            for(int i = 0; i< employeeCounter; i++)
            {
                if(employees[i].getUsername()== username)
                {
                    return true; 
                }
            }
            return false;
        }
        //
        //CheckEmployeeExists
        //
        static public bool isWarehouseExists(string warehouseName)
        {

            for (int i = 0; i < warehouseCounter; i++)
            {
                if (warehouses[i].getName() == warehouseName)
                {
                    return true;
                }
            }
            return false;
        }
        //
        //return warehouse from the system using the warehouse name 
        //
        static public Warehouse returnWarehouse(string warehouseName)
        {
            int i;
            for (i = 0; i < warehouseCounter; i++)
            {
                if (warehouses[i].getName() == warehouseName)
                {
                    break;
                }
            }
            return warehouses[i];
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
                //int supplyDocumentsCounter = 0;
                while (supplyDocuments_file.Position < supplyDocuments_file.Length)
                {
                    supplyDocuments.Add((SupplyDocument)formatter.Deserialize(supplyDocuments_file));
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
            warehouse_file.Close();

            for (int i = 0; i < employeeCounter; i++)
            {
                formatter.Serialize(employee_file, employees[i]);
            }
            employee_file.Close();

            for (int i = 0; i < supplyDocuments.Count; i++)
            {
                formatter.Serialize(supplyDocuments_file, supplyDocuments[i]);
            }
            supplyDocuments_file.Close();



        }


        static void Main(string[] args)
        {
            /// <summary>
            /// for debuging, I added this function to increase the days that a supply document has , so we would be able to delete them 
            /// supplyDocuments.Add(new SupplyDocument(1, "something", 25, 30, "suhaib", "h"));
            /// supplyDocuments[0].changeTime(181);
            /// </summary>


            loadFiles();
            Login();
        }
    }
}
