using System;
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
        private Item[] items;
        public Employee(string fname, string lname, int id, string username, string password)
        {
            this.fname = fname;
            this.lname = lname;
            this.id = id;
            this.username = username;
            this.password = password;

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
            }
            if (exist)
            {
                employeescreen(System.employees[i]);
            }
            else
            {
                C.WriteLine("username or password was wrong...");
            }
           // Employee ew = new Employee("suhib", "atef", 1234, un, up); //instead of finding the employee info
           // System.employees[System.employeeCounter++] = ew;
           // employeescreen(ew);
            
        }
        public static void employeescreen(Employee e)
        {
            sure:
            Console.WriteLine(C.indent1 + C.stars);
            Console.WriteLine(C.indent1 + C.stars);
            Console.WriteLine(C.indent1 + C.indent1 + C.indent1 + "\t\tWELCOME "+e.fname+" "+e.lname);
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

            switch (ch)
            {
                case 1:
                    Console.Clear();
                    C.WriteLine(C.stars);
                    C.WriteLine(C.stars5 +C.indent1+ e.fname + " " + e.lname + C.indent1+"      userName: " + e.username + C.indent1+"    ID: " + e.id+C.indent1 + C.stars5);
                    C.WriteLine(C.stars);
                    C.WriteLine("items" + C.indent1 + C.indent1 + "Code" + C.indent1 + C.indent1 + "Price" + C.indent1 + C.indent1 + "Quantity");
                    C.WriteLine(C.stars);
                    //foreach(Item i in e.items)
                    //{
                        //
                        //print the items for the employee
                        //
                    //} 
                    Console.WriteLine("\n\n\n");
                    //
                    // print all warehaouses and items in it
                    //
                    C.WriteLine("--------------------------------------------------------");
                    bool flag = true;
                    
                    while (flag)
                    {
                        
                        Console.Write(C.indent1+"Enter warhouse name :");
                        string wn = Console.ReadLine();
                        Console.Write(C.indent1 + "Enter Item name :");
                        string In = Console.ReadLine();
                        Console.Write(C.indent1 + "Enter item code :");
                        int Ic = Convert.ToInt32(Console.ReadLine());
                        Console.Write(C.indent1 + "Enter  Quantity :");
                        int Iq = Convert.ToInt32(Console.ReadLine());
                        Console.Write(C.indent1 + "Are you sure Y/N : ");
                        char s = Convert.ToChar(Console.ReadLine());

                        switch (s)
                        {
                            case 'Y':
                            case 'y':
                                string d = DateTime.Now.ToString();
                                SupplyDocuments supply = new SupplyDocuments(1,In,Ic,Iq,e.username,wn);
                                //
                                // ADD THE SUPPLY DOCUMENT
                                //
                                C.WriteLine("Supply document created ");
                                Thread.Sleep(5000);
                                Console.Clear();
                                goto sure;
                                
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
                                    employeescreen(e);
                                break;

                        }
                    }
                    break;
                case 2:
                    Console.Clear();
                    C.WriteLine(C.stars);
                    C.WriteLine(C.stars5 + C.indent1 + e.fname + " " + e.lname + C.indent1 + "      userName: " + e.username + C.indent1 + "    ID: " + e.id + C.indent1 + C.stars5);
                    C.WriteLine(C.stars);
                    C.WriteLine("items" + C.indent1 + C.indent1 + "Code" + C.indent1 + C.indent1 + "Price" + C.indent1 + C.indent1 + "Quantity");
                    C.WriteLine(C.stars);
                    //foreach(Item i in e.items)
                    //{
                    //
                    //print the items for the employee
                    //
                    //} 
                    Console.WriteLine("\n\n\n");
                    //
                    // print all warehaouses and items in it
                    //
                    C.WriteLine("--------------------------------------------------------");
                 
                    bool flag2 = true;

                    while (flag2)
                    {

                        Console.Write(C.indent1 + "Enter Item name :");
                        string Iname = Console.ReadLine();
                        Console.Write(C.indent1 + "Enter code Number :");
                        int Icode = Convert.ToInt32(Console.ReadLine());
                        Console.Write(C.indent1 + "Enter  Quantity :");
                        int Iquantity = Convert.ToInt32(Console.ReadLine());
                        Console.Write(C.indent1 + "Enter Username of the employee :");
                        string un = Console.ReadLine();
                        Console.Write(C.indent1 + "Enter employee Id :");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        Console.Write(C.indent1 + "Are you sure Y/N :");
                        char check = Convert.ToChar(Console.ReadLine());

                        switch (check)
                        {
                            case 'Y':
                            case 'y':
                                string d = DateTime.Now.ToString();
                                SupplyDocuments supply2 = new SupplyDocuments(2,Iname,Icode,Iquantity,e.username,"ebl3",un,Id);
                                //
                                // ADD THE SUPPLY DOCUMENT
                                //
                                C.WriteLine("Supply document created ");
                                Thread.Sleep(5000);
                                Console.Clear();
                                goto sure;
                                
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
                                employeescreen(e);
                                break;

                        }



                    }

                        break;
                   case 3:
                    Console.Clear();
                    C.WriteLine(C.stars);
                    C.WriteLine(C.stars5 + C.indent1 + e.fname + " " + e.lname + C.indent1 + "      userName: " + e.username + C.indent1 + "    ID: " + e.id + C.indent1 + C.stars5);
                    C.WriteLine(C.stars);
                    C.WriteLine("items" + C.indent1 + C.indent1 + "Code" + C.indent1 + C.indent1 + "Price" + C.indent1 + C.indent1 + "Quantity");
                    C.WriteLine(C.stars);
                    //foreach(Item i in e.items)
                    //{
                    //
                    //print the items for the employee
                    //
                    //} 
                    Console.WriteLine("\n\n\n");
                    //
                    // print all warehaouses and items in it
                    //
                    C.WriteLine("--------------------------------------------------------");

                    bool flag3 = true;

                    while (flag3)
                    {
                        Console.Write(C.indent1 + "Enter warhouse name :");
                        string wn2 = Console.ReadLine();
                        Console.Write(C.indent1 + "Enter Item name :");
                        string In2 = Console.ReadLine();
                        Console.Write(C.indent1 + "Enter code Number :");
                        int Ic2 = Convert.ToInt32(Console.ReadLine());
                        Console.Write(C.indent1 + "Enter  Quantity : ");
                        int Iq2 = Convert.ToInt32(Console.ReadLine());
                        Console.Write(C.indent1 + "Are you sure Y/N :");
                        char check = Convert.ToChar(Console.ReadLine());

                        switch (check)
                        {
                            case 'Y':
                            case 'y':
                                string d = DateTime.Now.ToString();
                                SupplyDocuments supply2 = new SupplyDocuments(3,In2,Ic2,Iq2,e.username,wn2);
                                //
                                // ADD THE SUPPLY DOCUMENT
                                //
                                C.WriteLine("Supply document created ");
                                Thread.Sleep(5000);
                                Console.Clear();
                                goto sure;
                                
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
                                employeescreen(e);
                                break;

                        }
                       
                    }
                    break;
                case 4:
                    System.Login(e);
                    break;
                default:
                    C.WriteLine("\nWRONG INPUT CHOICE");
                    employeescreen(e);
                    break;

            }


        }

    }
}
