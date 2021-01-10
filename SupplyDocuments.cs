using System;
using System.Collections.Generic;
using System.Text;

namespace CPE311_TermProject
{
    [Serializable]
    class SupplyDocuments
    {
        private string warehouseName;
        private string itemName;
        private UInt64 itemCode;
        private UInt64 itemQuantity;
        private int type;
        DateTime date;
        private string senderUsername;
        private string recieverUsername;
        private int receiverId;

        public SupplyDocuments(int type, string itemName, UInt64 itemCode, UInt64 itemQuantity, string senderUsername, string warehouseName="", string recieverUsername="", int receiverId=0)
        {
            this.itemName = itemName;
            this.itemCode = itemCode;
            this.itemQuantity = itemQuantity;
            this.senderUsername = senderUsername;
            this.date = DateTime.Now;
            this.type = type;

            if (type == 1 || type == 3)
            {

                this.warehouseName = warehouseName; 
            }
            else
            {
                this.recieverUsername = recieverUsername;
                this.receiverId = receiverId;
            }
            

        }
       public DateTime getDate()
        {
            return date;
        }
        public void viewSupply()
        {
            //
            //Add code to view Supply Document
            //
            C.WriteLine(C.stars);
            C.WriteLine("For store : "+warehouseName);
            C.WriteLine(C.stars);
            C.WriteLine("To user:");
            int i = 0;
            string fname ="";
            string lname="";
            for (; i < System.employeeCounter; i++)
            {
                if (System.employees[i].getUsername() == senderUsername)
                {
                    fname = System.employees[i].getFname();
                    lname = System.employees[i].getLname();
                    break;
                }
            }
            C.WriteLine("Name: " + fname + "   " + lname + "---- username:" + senderUsername);
            C.WriteLine(C.stars);
            C.WriteLine("Item: " + itemName + "  Quantity: " + itemQuantity + "  Date: " + date.ToString());
            C.WriteLine(C.dashes);

        }

        public void approve()
        {
            //
            //code if the supply document is Approved
            //
            switch (type)
            {   
                //Requeste from warehouse to employee 
                case 1:
                    
                    int i;
                    for (i = 0; i < System.warehouseCounter; i++)
                    {
                        if (System.warehouses[i].getName() == warehouseName)
                        {
                            break;
                        }
                    }
                    Item empItem = new Item(itemName, System.warehouses[i].returnItem(itemCode).getPrice(), itemCode, itemQuantity);
                    System.warehouses[i].reduceItemOrDelete(empItem);
                    i = 0;
                    for (; i < System.employeeCounter; i++)
                    {
                        if (System.employees[i].getUsername() == senderUsername)
                        {
                            break;
                        }
                    }
                    System.employees[i].addItem(empItem);

                    break;
                //transfer from employee to employee 
                case 2:
                    int j=0;
                    for (; j < System.employeeCounter; j++)
                    {
                        if (System.employees[j].getUsername() == senderUsername)
                        {
                            break;
                        }
                    }
                    Item empItem2 = new Item(itemName, System.employees[j].returnItem(itemCode).getPrice(), itemCode, itemQuantity);
                    System.employees[j].reduceItemOrDelete(empItem2);
                    j = 0;
                    for (; j < System.employeeCounter; j++)
                    {
                        if (System.employees[j].getUsername() == recieverUsername)
                        {
                            break;
                        }
                    }
                    System.employees[j].addItem(empItem2);


                    break;
                //return from employee to warehouse 
                case 3:
                    int k = 0;
                    for (; k < System.employeeCounter; k++)
                    {
                        if (System.employees[k].getUsername() == senderUsername)
                        {
                            break;
                        }
                    }
                    Item empItem3 = new Item(itemName, System.employees[k].returnItem(itemCode).getPrice(), itemCode, itemQuantity);
                    System.employees[k].reduceItemOrDelete(empItem3);
                    k=0;
                    for (k = 0; k < System.warehouseCounter; k++)
                    {
                        if (System.warehouses[k].getName() == warehouseName)
                        {
                            break;
                        }
                    }
                    System.warehouses[k].addItem(empItem3);
                    break;

            }

        }
        /// <summary>
        /// for debuging, I added this function to increase the days that a supply document has , so we would be able to delete them 
        /// </summary>
        public void changeTime(int x)
        {
            date = date.AddDays(x);
        } 

    }
   


}
