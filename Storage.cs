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
            items.Add(item);
        }
        public void deleteItem(Item item)
        {
            items.Remove(item);
        }
    }
}
