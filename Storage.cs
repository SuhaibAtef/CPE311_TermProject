using System;
using System.Collections.Generic;
using System.Text;

namespace CPE311_TermProject
{
    [Serializable]
    class Item
    {
        private string name;
        private double price;
        private UInt64 code;
        private UInt64 quantity;

        public Item(string name, double price, ulong code, ulong quantity)
        {
            this.name = name;
            this.price = price;
            this.code = code;
            this.quantity = quantity;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public UInt64 getCode()
        {
            return this.code;
        }
        public double getPrice()
        {
            return this.price;
        }
        public UInt64 getQuantity()
        {
            return this.quantity;
        }
        public void changeQuantity(UInt64 value)
        {
            this.quantity += value;
        }
        public void reduceQuantity(UInt64 value)
        {
            this.quantity -= value;
        }
        public void print()
        {
            C.WriteLine(name+new string(' ',28-name.Length)+ code + "\t"+ price + "\t"+ quantity);
        }
    }
    [Serializable]
    class Warehouse
    {
        private string name;
        
        private List<Item> items = new List<Item>();

        public Warehouse(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name= name;
        }
        public void addItem(Item item)
        {
            bool found=false;
            int i = 0;
            while (i < items.Count)
            {
                if (items[i].getCode() == item.getCode())
                {   
                    items[i].changeQuantity(item.getQuantity());
                    found = true;
                    break;
                }
                i++;
            }
            if (!found)
            {
                items.Add(item);
            }
        }
        public bool reduceItemOrDelete(Item item)
        {
            Item oldItem = returnItem(item.getCode());
            if (oldItem.getQuantity() == item.getQuantity()) { 
                items.Remove(oldItem);
                return true;
            }
                
            else if (oldItem.getQuantity() < item.getQuantity())
            {
                C.WriteLine("Not enough quantity");
                return false;
            }
            else
            {

                int i = 0;
                while (i < items.Count)
                {
                    if (items[i].getCode() == item.getCode())
                    {
                        break;
                    }
                    i++;
                }
                
                items[i].reduceQuantity(item.getQuantity());
                return true;
            }
        }
        public void viewWarehouse()
        {
            C.WriteLine(C.stars);
            C.WriteLine(C.stars4+new string(' ',(37-name.Length)/2)+"Warhouse "+name+ new string(' ', (37 - name.Length) / 2) + C.stars4);
            C.WriteLine(C.stars);
            C.WriteLine("Title\t\t\tCode\tPrice\tQuantity");
            int i = 0;
            
            while (i < items.Count)
            {
                items[i].print();
                i++;
            }
        }
        public bool checkItem(UInt64 code, UInt64 quantity)
        {
            if (quantity == 0)
            {
                return false;
            }
            int i = 0;
            while (i < items.Count)
            {
                if (items[i].getCode() == code && items[i].getQuantity() >= quantity)
                {
                    return true;
                }
                i++;
            }
            return false;
        }
        public Item returnItem(UInt64 code)
        {
            int i = 0;
            while (i < items.Count)
            {
                if (items[i].getCode() == code)
                {
                    break;
                }
                i++;
                
            }
            return items[i];

        }
    }

    
}
