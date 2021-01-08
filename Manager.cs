using System;
using System.Collections.Generic;
using System.Text;

namespace CPE311_TermProject
{
    [Serializable]
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
                Console.Clear();
                ManagerScreen(); /// Manager Main Screen
            }
            else
            {
                C.WriteLine("Wrong Login information try again");
                System.Login();
            }
        }

        public void ManagerScreen()
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
                        C.WriteLine(C.stars + "\n");
                        AddItemtoWarehouse();
                        System.StoreFiles();

                    }
                    else if (choice == 3)
                {
                        //
                        //View warehouses();
                        //
                        Console.Clear();
                        for (int i = 0; i < System.warehouseCounter; i++)
                        {
                            System.warehouses[i].viewWarehouse();
                        }
                    }
                else if (choice == 4)
                {
                        //
                        //View supply documents();
                        //
                        List<SupplyDocuments> deletedSupplyDocs = new List<SupplyDocuments>();

                        if(System.supplyDocuments.Count == 0)
                        {
                            C.WriteLine("There's No Supply Documents to View.");
                        }else
                        { 
                        foreach (SupplyDocuments supply in System.supplyDocuments)
                        {
                            supply.viewSupply();
                            Console.Write(C.indent1 + "1.Approve  2.Delete  3.Postpone  ");
                            int decision = Convert.ToInt32(Console.ReadLine());
                            switch (decision)
                            {
                                case 1:
                                    supply.approve();
                                    break;
                                case 2:
                                        deletedSupplyDocs.Add(supply);
                                    break;
                                case 3:
                                    continue;
                                default:
                                    C.WriteLine("No decision was made,Posponing the supply document");
                                    break;

                            }

                        }
                        foreach (SupplyDocuments supply in deletedSupplyDocs)
                        {
                                System.supplyDocuments.Remove(supply);
                        }
                                System.StoreFiles();
                        }
                    }
                    else if (choice == 5)
                {
                        //
                        //Delete old supply Documents();
                        //
                        DateTime today = DateTime.Now;
                        bool deleteSupply = false;
                        for(int i = 0; i< System.supplyDocuments.Count;i++)
                        {
                            DateTime d = System.supplyDocuments[i].getDate();
                            if(d.Subtract(today).TotalDays > 180)
                            {
                                deleteSupply = true; 
                                System.supplyDocuments.Remove(System.supplyDocuments[i]);
                            } 
                        }
                        if (!deleteSupply)
                        {
                            C.WriteLine("There is no supply documents to delete");
                        }
                        else
                        {
                            C.WriteLine("all the supply documents that have been created before six months were deleted. ");
                        }
                        //System.StoreFiles();

                    }
                    else if (choice == 6)
                {
                        //
                        //exit();
                        //
                    C.WriteLine("Logging Out...");
                    System.StoreFiles();
                    System.Login();
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
                ManagerScreen();
            }
        }
        public void Create_Warehouse() 
        {
            Console.WriteLine(new String('-',60));
            Console.Write(C.indent1 + "Enter Warehouse Name:  ");
            string wName = Console.ReadLine();

            bool Flag=false;
           for(int i = 0; i < System.warehouseCounter; i++)
            {
                if (System.warehouses[i].getName() == wName)
                {
                    Flag = true;
                    break;
                }
            }
            
            if (Flag)
            {
                C.WriteLine(C.indent1+"Warehouse already exists.");
                
            }
            else
            {
                System.warehouses[System.warehouseCounter++] = new Warehouse(wName);
                System.StoreFiles();
            }


        }

        public void AddItemtoWarehouse()
        {
            
            bool loop = false;
            
            do {
                Console.Write(C.indent1 + "Enter Warehouse Name:  ");
                string wName = Console.ReadLine();
                bool exists = false;
                int i = 0;
                for (; i < System.warehouseCounter; i++)
                {
                    if (System.warehouses[i].getName() == wName)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    C.WriteLine(C.indent1 + "Warehouse doesn't exist.");
                    Console.WriteLine(C.indent1 + "Do you want try again? (y,n)");
                    char again = (char)Console.ReadLine()[0];
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
                else
                {

                S:
                    try
                    {
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

                        System.warehouses[i].addItem(new Item(Iname, price, Code, IQuantity));

                    }
                    catch
                    {
                        C.WriteLine("Wrong Input,Try Again...");
                        goto S;
                    }
                    char again;
                    Console.Write(C.indent1 + "Enter another Item (Y/N):\n" + C.indent1);
                    again = (char)Console.ReadLine()[0];
                    if (again == 'Y' || again == 'y')
                    {
                        AddItemtoWarehouse();
                    }
                    else
                    {
                        loop = false;
                    }
                }
            } while (loop);
            

            //
            // TO-DO:check if warehouse exists
            
                
                    //
                    //
                    //if item already exist in the warehouse 
                    //adds the quantity to the existing item 
                    //else creates a new item and inserts it to the warehouse 
                    //
            
        }
    }
}
