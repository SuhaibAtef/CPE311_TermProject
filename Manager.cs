using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace CPE311_TermProject
{

    class Manager 
    {
        private string username;
        private string password;

        public Manager(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void SignIn()
        {
            Console.WriteLine(C.indent1 + C.stars);
            Console.WriteLine(C.indent1 + C.stars);
            Console.Write(C.indent1 + "Enter Username:  ");
            string uname = Console.ReadLine();
            Console.Write(C.indent1 + "Enter Password:  ");
            string upass = Console.ReadLine();
            if (uname == "Manager" && upass == "Manager")
            {
                ManagerScreen(this); /// Manager Main Screen
            }
            else
            {
                C.WriteLine("Wrong Login information try again");
                System.Login(this);
            }
        }

        public void ManagerScreen(Manager m)
        {
            try
            {
            int choice;
            while (true)
            {
                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                C.WriteLine(C.indent2 + "Manager");
                C.WriteLine("1. Create warehouse");
                C.WriteLine("2. Add item to warehouse");
                C.WriteLine("3. View warehouses");
                C.WriteLine("4. View supply documents");
                C.WriteLine("5. Delete old supply Documents");
                C.WriteLine("6. Exit");
                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                Console.Write(C.indent1 + "Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                        //Create Warehouse
                        Create_Warehouse();

                }
                    else if (choice == 2)
                {
                        //Add item warehouse(); 
                        C.WriteLine(C.stars+"\n");
                        bool loop = false;
                        char again; 
                        do
                        {
                            AddItemtoWarehouse();

                            //again = 'y';
                            //while(again != 'Y'&& again != 'y'|| again != 'N'|| again != 'n') { 

                            C.WriteLine("Enter another Item (Y/N): ");
                            again = (char)Console.Read();
                            
                            if (again == 'Y' || again == 'y')
                            {
                                loop = true;
                            }
                            else /*if (again == 'N' || again == 'n')*/ 
                            {
                                loop = false;
                            }
                            /*else
                            {
                                C.WriteLine("Wrong Input\n");
                            }*/

                            //}

                        } while (loop);
                        
                }
                else if (choice == 3)
                {
                        //
                        //View warehouses();
                        //
                }
                else if (choice == 4)
                {
                        //
                        //View supply documents();
                        //
                }
                else if (choice == 5)
                {
                        //
                        //Delete old supply Documents();
                        //
                }
                else if (choice == 6)
                {
                        //
                        //exit();
                        //
                    C.WriteLine("Logging Out...");
                    System.Login(m);
                    break;
                }
                    else
                {
                    Console.WriteLine("Incorrect Choice, Please try again...");
                }
            }
            }
            catch (Exception e)
            {
                C.WriteLine(e.Message+" Please try again...");
                ManagerScreen(m);
            }
        }
        public void Create_Warehouse() 
        {
            Console.WriteLine(new String('-',60));
            Console.Write(C.indent1 + "Enter Warehouse Name:  ");
            string wName = Console.ReadLine();
            
            FileStream warehouse_file=new FileStream("Warehouses.txt",FileMode.OpenOrCreate,FileAccess.Read);
            BinaryFormatter warehouse_formatter= new BinaryFormatter();
            Warehouse[] warehouse = new Warehouse[100];
            int i=0;
            bool Flag=false;
            while(warehouse_file.Position<warehouse_file.Length){
              warehouse[i]=(Warehouse)warehouse_formatter.Deserialize(warehouse_file);
                if (warehouse[i].getName()==wName){
                    Flag=true;
                }
                i++;
            }
            warehouse_file.Close();
            if (Flag)
            {
                C.WriteLine(C.indent1+"Warehouse already exists.");
                
            }
            else
            {
                //append
                System.warehouses[System.warehouseCounter] = new Warehouse(wName);
                System.warehouseCounter++;
                warehouse_file =new FileStream("Warehouses.txt",FileMode.Append,FileAccess.Write);
                warehouse[System.warehouseCounter].setName(wName);
                warehouse_formatter.Serialize(warehouse_file,warehouse);
                warehouse_file.Close();
            }
            
            
        }

        public void AddItemtoWarehouse()
        {
       
            Console.Write(C.indent1 + "Enter Warehouse Name:  ");
            string wName = Console.ReadLine();

            //
            // TO-DO:check if warehouse exists
            FileStream warehouse_file = new FileStream("Warehouses.txt", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter warehouse_formatter = new BinaryFormatter();
            Warehouse[] warehouse = new Warehouse[100];
            int i = 0;
            int ind=0;
            bool exist = false;
            while (warehouse_file.Position < warehouse_file.Length)
            {
                warehouse[i] = (Warehouse)warehouse_formatter.Deserialize(warehouse_file);
                if (warehouse[i].getName() == wName)
                {
                    exist = true;
                    ind = i;
                }
                i++;
            }
            warehouse_file.Close();

            if (exist == false)
            {
                C.WriteLine(C.indent1 + "Warehouse doesn't exist.");
                Console.Write(C.indent1 + "Do you want try again? (y,n)");
                char again = (char)Console.Read();
                if (again == 'y' || again == 'Y')
                    AddItemtoWarehouse();
                else if (again == 'n' || again == 'N')
                    ManagerScreen();
                else
                {
                    C.WriteLine(C.indent1 + "Wrong Input...");
                    ManagerScreen();
                }
            }
            else {

                S:
                    try {
                        Console.Write(C.indent1 + "Enter item's Name:  ");
                        string Iname = Console.ReadLine();
                        Console.Write(C.indent1 + "Enter item's Price:  ");
                        double price = Convert.ToDouble(Console.ReadLine());
                        if (price < 0)
                        {
                            throw new FormatException();
                        }
                        Console.Write(C.indent1 + "Enter item's Code:  ");
                        UInt64 Code = Convert.ToUInt64(Console.ReadLine());//previous --> Int64 Code =Convert.ToInt64(Console.ReadLine())---> so it made some errors with item constructor so I changed it
                        Console.Write(C.indent1 + "Enter item's Quantity:  ");
                        UInt64 IQuantity = Convert.ToUInt64(Console.ReadLine());
                        
                        Item newItem = new Item(Iname, price, Code, IQuantity);
                    warehouse[ind].addItem(newItem);
                }
                    catch
                    {
                        C.WriteLine("Wrong Input,Try Again...");
                        goto S;
                    }
                
                    //
                    //
                    //if item already exist in the warehouse 
                    //adds the quantity to the existing item 
                    //else creates a new item and inserts it to the warehouse 
                    //
            }
        }
    }
}
