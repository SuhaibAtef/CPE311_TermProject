using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
                C.WriteLine(new String(' ', 29) + "Manager");
                C.WriteLine("1. Create warehouse");
                C.WriteLine("2. Add item to warehouse");
                C.WriteLine("3. View warehouses");
                C.WriteLine("4. View supply documents");
                C.WriteLine("5. Delete old supply Documents");
                C.WriteLine("6. Exit");
                C.WriteLine(C.stars);
                C.WriteLine(C.stars);
                Console.Write(C.indent1 + "Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                        //Create Warehouse
                        Create_Warehouse();
                        Thread.Sleep(2000);
                        Console.Clear();
                        

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
                        if (System.warehouseCounter == 0)
                        {
                            C.WriteLine("There's No Warehouses to view.");
                        }else
                        {
                           System.viewWarehouses();
                        }
                        
                        Thread.Sleep(2000);

                    }
                else if (choice == 4)
                {
                        //
                        //View supply documents();
                        //
                        List<SupplyDocument> deletedSupplyDocs = new List<SupplyDocument>();

                        if(System.supplyDocuments.Count == 0)
                        {
                            C.WriteLine("There's No Supply Documents to View.");
                        }else
                        { 
                        foreach (SupplyDocument supply in System.supplyDocuments)
                        {
                            supply.viewSupply();
                            Console.Write(C.indent1 + "1.Approve  2.Delete  3.Postpone  ");
                            int decision = Convert.ToInt32(Console.ReadLine());
                            switch (decision)
                            {
                                case 1:
                                    supply.approve();
                                    deletedSupplyDocs.Add(supply);
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
                        foreach (SupplyDocument supply in deletedSupplyDocs)
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
                            if(today.Subtract(d).TotalDays > 180)
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
                    Thread.Sleep(2000);
                    System.StoreFiles();
                    Console.Clear();
                    System.Login();
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
                C.WriteLine(e.Message+" Please try again...");
                ManagerScreen();
            }
        }
        public void Create_Warehouse() 
        {
            Console.WriteLine(new String('-',60));
            Console.Write(C.indent1 + "Enter Warehouse Name:  ");
            string wName = Console.ReadLine();
            
            if (System.isWarehouseExists(wName))
            {
                C.WriteLine("Warehouse already exists.");
                
            }else if(String.IsNullOrWhiteSpace(wName))
            {
                C.WriteLine("You Can't define a warehouse name empty");
            }
            else
            {
                System.warehouses[System.warehouseCounter++] = new Warehouse(wName);
                C.WriteLine("Created Warehouse Successfully");
                System.StoreFiles();
            }


        }
        public void AddItemtoWarehouse()
        {
            
            bool loop = false;
            
            do {
                Console.Write(C.indent1 + "Enter Warehouse Name:  ");
                string wName = Console.ReadLine();
                
                int i = 0;

                if (!System.isWarehouseExists(wName))
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
                    for (int j = 0; j < System.warehouseCounter; j++)
                    {
                        if (System.warehouses[j].getName() == wName)
                        {
                            i = j;
                            break;
                        }
                    }
                S:
                    try
                    {
                        Console.Write(C.indent1 + "Enter item's Name:  ");
                        string Iname = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(Iname))
                        {
                            throw new FormatException();
                        }
                        Console.Write(C.indent1 + "Enter item's Price:  ");
                        double price = Convert.ToDouble(Console.ReadLine());
                        if (price < 0)
                        {
                            throw new FormatException();
                        }
                        Console.Write(C.indent1 + "Enter item's Code:  ");
                        UInt64 Code = Convert.ToUInt64(Console.ReadLine());
                        Console.Write(C.indent1 + "Enter item's Quantity:  ");
                        UInt64 IQuantity = Convert.ToUInt64(Console.ReadLine());
                        if (IQuantity == 0)
                        {
                            throw new FormatException();
                        }
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

            
        }
        
    }
}
