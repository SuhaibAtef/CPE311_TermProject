using System;
using System.Collections.Generic;
using System.Text;

namespace CPE311_TermProject
{
    class Employee
    {
        private string fname;
        private string lname;
        private int id;
        private string username;
        private string password;
        public Employee(string fname, string lname, int id, string username, string password)
        {
            this.fname = fname;
            this.lname = lname;
            this.id = id;
            this.username = username;
            this.password = password;

        }
     
       // public static void SignUp(string fname, string lname, int id, string username, string password)
        //{
        //}
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

            Employee ew = new Employee("suhib", "atef", 1234, un, up); //instead of finding the employee info

            Employee.employeescreen(ew);
            
        }
        public static void employeescreen(Employee e)
        {
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
                    
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    System.Login();
                    break;
                default:
                    C.WriteLine("\nWRONG INPUT CHOICE");
                    employeescreen(e);
                    break;

            }


        }

    }
}
