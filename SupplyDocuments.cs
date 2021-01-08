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
        private int itemCode;
        private int itemQuantity;
        private int type;
        DateTime date;
        private string senderUsername;
        private string recieverUsername;
        private int receiverId;

        public SupplyDocuments(int type, string itemName, int itemCode, int itemQuantity, string senderUsername, string warehouseName="", string recieverUsername="", int receiverId=0)
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
