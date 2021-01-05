using System;
using System.Collections.Generic;
using System.Text;

namespace CPE311_TermProject
{
    class SupplyDocuments
    {
        private string warehouseName;
        private string itemName;
        private int itemCode;
        private int itemQuantity;
        private int type;
        string date;
        private string senderUsername;
        private string recieverUsername;
        private int receiverId;

        public SupplyDocuments(string warehouseNam, string itemName, int itemCode, int itemQuantity, string date, string senderUsername, int type=1)
        {
            
            this.warehouseName = warehouseName;
            this.itemName = itemName;
            this.itemCode = itemCode;
            this.itemQuantity = itemQuantity;
            this.date = date;
            this.senderUsername = senderUsername;
            this.type = type;


        }
        public SupplyDocuments(string itemName, int itemCode, int itemQuantity, string date, string senderUsername,string recieverUsername,int receiverId, int type = 2)
        {
            this.itemName = itemName;
            this.itemCode = itemCode;
            this.itemQuantity = itemQuantity;
            this.date = date;
            this.senderUsername = senderUsername;
            this.type = type;
            this.recieverUsername = recieverUsername;
            this.receiverId = receiverId;

        }




    }
   


}
