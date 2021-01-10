﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CPE311_TermProject
{
    [Serializable]
    class Employee
    {
        private string fname;
        private string lname;
        private int id;
        private string username;
        private string password;
        private List<Item> EmpItems = new List<Item>();
        
        public Employee(string fname, string lname, int id, string username, string password)
        {
            this.fname = fname;
            this.lname = lname;
            this.id = id;
            this.username = username;
            this.password = password;
        }
        public string getUsername()
        {
            return username;
        }
        public string getFname()
        {
            return fname;
        }
        public string getLname()
        {
            return lname;
        }

        public void printEmpItems()
        {
            if (EmpItems.Count == 0)
            {
                C.WriteLine("There is no items ");
            }
            else
            {
                for (int i = 0; i < this.EmpItems.Count; i++)
                    this.EmpItems[i].print();

            }
        }
        public bool checkItem(UInt64 code, UInt64 quantity)
        {
            if (quantity == 0)
            {
                return false;
            }
            int i = 0;
            while (i < EmpItems.Count)
            {
                if (EmpItems[i].getCode() == code && EmpItems[i].getQuantity() >= quantity)
                {
                    return true;
                }
                i++;
            }
            return false;
        }
        public static  void SignIn()
        {

            Console.WriteLine(C.indent1 + C.stars);
            Console.WriteLine(C.indent1 + C.stars);
            Console.Write(C.indent1 + "Enter Username:  ");
            string un = Console.ReadLine();
            Console.Write(C.indent1 + "Enter Password:  ");
            string up = Console.ReadLine();
            //
            // check if information are correct
            //
            //if they are correct move to emp screen with the object informations and return an employee object
            //
            bool exist = false;
            int i = 0;
            while (i < System.employeeCounter)
            {
                if (System.employees[i].username == un && System.employees[i].password == up)
                {
                    exist = true;
                    break;
                }
                i++;
            }

            if (exist)
            {
                System.employees[i].employeescreen();
            }
            else
            {
                C.WriteLine("username or password was wrong...  Try Agin?(y,n)");
                char again = (char)Console.ReadLine()[0];
                if (again == 'y' || again == 'Y')
                    SignIn();
                else
                    System.Login();
            }
            
        }
        public void employeescreen()
        {
            sure:
            Console.WriteLine(C.indent1 + C.stars);
            Console.WriteLine(C.indent1 + C.stars);
            Console.WriteLine(C.indent1 + C.indent1 + C.indent1 + "\t\tWELCOME "+this.fname+" "+ this.lname);
            Console.WriteLine(C.indent1 + C.stars);
            int ch;
            C.WriteLine("1- Create Supply Document To request An Item from Warehouse");
            C.WriteLine("2- Create Supply Document To Transfer An Item to another employee");
            C.WriteLine("3- Create Supply Document To return An Item To Warehouse");
            C.WriteLine("4- Exit");
            Console.WriteLine(C.indent1 + C.stars);
            Console.WriteLine(C.indent1 + C.stars);
            Console.Write(C.indent1+"choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            int q = (66 - (this.fname + " " + this.lname + "       userName: " + this.username + "    ID: " + this.id).Length) / 6;
            Console.Clear();
            C.WriteLine(C.stars);
            C.WriteLine(new string('*', q) + new string(' ', q) + this.fname + " " + this.lname + new string(' ', q) + "      userName: " + this.username + new string(' ', q) + "    ID:  " + this.id + new string(' ', q) + new string('*', q));
            C.WriteLine(C.stars);
            C.WriteLine("items" + C.indent1 + C.indent1 + "Code" + C.indent1 + C.indent1 + "Price" + C.indent1 + C.indent1 + "Quantity");
            C.WriteLine(C.stars);
            printEmpItems();

            switch (ch)
            {
                case 1:
                   
                    Console.WriteLine("\n\n");
                    System.viewWarehouses();
                    C.WriteLine("--------------------------------------------------------");
                    bool flag = true;

                    while (flag)
                    {

                        Console.Write(C.indent1 + "Enter warehouse name :");
                        string wn = Console.ReadLine();
                        if (!System.isWarehouseExists(wn))
                        {
                            C.WriteLine("No warehouse with that name");
                            break;
                        }
                        Warehouse warehouse = System.returnWarehouse(wn);
                        Console.Write(C.indent1 + "Enter Item name :");
                        string In = Console.ReadLine();
                        Console.Write(C.indent1 + "Enter item code :");
                        UInt64 Ic = Convert.ToUInt64(Console.ReadLine());
                        Console.Write(C.indent1 + "Enter  Quantity :");
                        UInt64 Iq = Convert.ToUInt64(Console.ReadLine());
                        
                        if (!warehouse.checkItem(Ic,Iq))
                        {
                            C.WriteLine("No Item with that name or quantity");
                            break;
                        }
                        Console.Write(C.indent1 + "Are you sure Y/N : ");
                        char s = Convert.ToChar(Console.ReadLine());

                        switch (s)
                        {
                            case 'Y':
                            case 'y':
                                string d = DateTime.Now.ToString();
                                SupplyDocuments supply = new SupplyDocuments(1, In, Ic, Iq, this.username, wn);
                                System.supplyDocuments.Add(supply);
                                C.WriteLine("Supply document created ");
                                Thread.Sleep(2000);
                                Console.Clear();
                                //goto sure;
                                flag = false;
                                break;
                            case 'n':
                            case 'N':
                                C.WriteLine("1- Enter information again?");
                                C.WriteLine("2- Exist to your main screen");
                                Console.Write(C.indent1 + "ENTER YOU CHOICE : ");
                                int c = Convert.ToInt32(Console.ReadLine());
                                if (c == 1)
                                    continue;
                                else
                                    Console.Clear();
                                break;

                        }
                    }
                    employeescreen();
                    break;
                case 2:

                    C.WriteLine("--------------------------------------------------------");
                    if (EmpItems.Count == 0)
                    {
                        C.WriteLine("You dont have any items ");
                        employeescreen();
                    }

                    bool flag2 = true;

                    while (flag2)
                    {
                        

                        Console.Write(C.indent1 + "Enter Item name :");
                        string Iname = Console.ReadLine();
                        Console.Write(C.indent1 + "Enter code Number :");
                        UInt64 Icode = Convert.ToUInt64(Console.ReadLine());
                        Console.Write(C.indent1 + "Enter  Quantity :");
                        UInt64 Iquantity = Convert.ToUInt64(Console.ReadLine());

                        //
                        // Check item is in Items Employee 
                        //
                        if (!checkItem(Icode,Iquantity))
                        {
                            C.WriteLine("Item does not exist");
                            break;
                        }
                        Console.Write(C.indent1 + "Enter Username of the employee :");
                        string un = Console.ReadLine();
                        Console.Write(C.indent1 + "Enter employee Id :");
                        int Id = Convert.ToInt32(Console.ReadLine());

                        //
                        // Check emplyee exists using (isEmployeeExists) 
                        //
                        if (!System.isEmployeeExists(un))
                        {
                            C.WriteLine("No Employee with that Username");
                            break;
                        }
                        Console.Write(C.indent1 + "Are you sure Y/N :");
                        char check = Convert.ToChar(Console.ReadLine());

                        switch (check)
                        {
                            case 'Y':
                            case 'y':
                                string d = DateTime.Now.ToString();
                                SupplyDocuments supply2 = new SupplyDocuments(2,Iname,Icode,Iquantity,this.username," ",un,Id);
                                System.supplyDocuments.Add(supply2);
                                C.WriteLine("Supply document created ");
                                Thread.Sleep(2000);
                                Console.Clear();
                                flag2 = false;
                                break;
                            case 'n':
                            case 'N':
                                Console.Write(C.indent1 + "1- Enter information again? :");
                                Console.Write(C.indent1 + "2- Exist to your main screen :");
                                Console.Write(C.indent1 + "ENTER YOU CHOICE :");
                                int c = Convert.ToInt32(Console.ReadLine());
                                if (c == 1)
                                    continue;
                                else
                                    Console.Clear();
                                employeescreen();
                                break;

                        }

                    }
                    employeescreen();
                    break;
                   case 3:
                    
                    Console.WriteLine("\n\n");
                    if(EmpItems.Count == 0)
                     {
                        C.WriteLine("You dont have any items ");
                        employeescreen();  
                    }
                    System.viewWarehouses();
                    C.WriteLine("--------------------------------------------------------");

                    bool flag3 = true;

                    while (flag3)
                    {
                       
                            Console.Write(C.indent1 + "Enter warehouse name :");
                        string wn2 = Console.ReadLine();
                        //
                        //Check warehouse exists using (isWarehouseExists)
                        //
                        if (!System.isWarehouseExists(wn2))
                        {
                            C.WriteLine("No warehouse with that name");
                            break;
                        }
                        Console.Write(C.indent1 + "Enter Item name :");
                        string In2 = Console.ReadLine();
                        Console.Write(C.indent1 + "Enter code Number :");
                        UInt64 Ic2 = Convert.ToUInt64(Console.ReadLine());
                        Console.Write(C.indent1 + "Enter  Quantity : ");
                        UInt64 Iq2 = Convert.ToUInt64(Console.ReadLine());
                        //
                        //Check item exists in employees items
                        //
                        if (!checkItem(Ic2, Iq2))
                        {
                            C.WriteLine("Item does not exist");
                            break;
                        }
                        Console.Write(C.indent1 + "Are you sure Y/N :");
                        char check = Convert.ToChar(Console.ReadLine());

                        switch (check)
                        {
                            case 'Y':
                            case 'y':
                                string d = DateTime.Now.ToString();
                                SupplyDocuments supply2 = new SupplyDocuments(3,In2,Ic2,Iq2,this.username,wn2);
                                //
                                // ADD THE SUPPLY DOCUMENT
                                //
                                System.supplyDocuments.Add(supply2);
                                C.WriteLine("Supply document created ");
                                Thread.Sleep(2000);
                                Console.Clear();
                                flag3=false;
                                break;
                                
                            case 'n':
                            case 'N':
                                Console.Write(C.indent1 + "1- Enter information again? :");
                                Console.Write(C.indent1 + "2- Exist to your main screen :");
                                Console.Write(C.indent1 + "ENTER YOU CHOICE :");
                                int c = Convert.ToInt32(Console.ReadLine());
                                if (c == 1)
                                    continue;
                                else
                                    Console.Clear();
                                employeescreen();
                                break;

                        }
                       
                    }
                    employeescreen();
                    break;
                case 4:
                    C.WriteLine("Logging Out...");
                    Thread.Sleep(2000);
                    System.StoreFiles();
                    Console.Clear();
                    System.Login();
                    break;

                default:
                    C.WriteLine("\nWRONG INPUT CHOICE");
                    employeescreen();
                    break;

            }


        }
        

    }
}
