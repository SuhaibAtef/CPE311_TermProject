using System;
using System.Collections.Generic;
using System.Text;

namespace CPE311_TermProject
{
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
        public UInt64 getCode()
        {
            return this.code;
        }
        public UInt64 getQuantity()
        {
            return this.quantity;
        }
        public void changeQuantity(UInt64 value)
        {
            this.quantity += value;
        }
        public void print()
        {
            C.WriteLine(name+"\t\t\t"+ code + "\t"+ price + "\t"+ quantity);
        }
    }

    class Warehouse
    {
        private string name;
        
        private List<Item> items = new List<Item>();

        public Warehouse(string name)
        {
            this.name = name;
        }
        public String getName()
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
        public void deleteItem(Item item)
        {
            items.Remove(item);
        }
        public void viewWarehouse()
        {
            C.WriteLine(C.stars);
            C.WriteLine(C.stars4+"Warhouse "+name+C.stars4);
            C.WriteLine(C.stars);
            C.WriteLine("Title\t\t\tCode\tPrice\tQuantity");
            int i = 0;
            while (i < items.Count)
            {
                items[i].print();
                i++;
            }
        }
    }
}
