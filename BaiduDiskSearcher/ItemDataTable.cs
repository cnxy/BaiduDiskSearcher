using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BaiduDiskSearcher
{
    class ItemDataTable
    {
        DataTable dataTable;
        public ItemDataTable()
        {
            dataTable = new DataTable("ItemDatatable");
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("FileName", typeof(string));
            dataTable.Columns.Add("FileNameExt", typeof(string));
            dataTable.Columns.Add("Type", typeof(string));
            dataTable.Columns.Add("Time", typeof(string));
            dataTable.Columns.Add("Size", typeof(string));
            dataTable.Columns.Add("Sharer", typeof(string));
            dataTable.Columns.Add("Site", typeof(string));
            dataTable.Columns.Add("Item", typeof(Item));
        }
        int count;
        public int Add(Item item)
        {
            dataTable.Rows.Add(++count, item.FileName, item.FileNameExt, item.Type, item.Time, item.Size, item.Sharer, item.Site,item);
            return count;
        }

        public DataTable GetItems()
        {
            return this.dataTable;
        }

        public Item[] GetItems(out int[] counts)
        {
            List<int> countList = new List<int>();
            List<Item> itemList = new List<Item>();
            foreach (DataRow row in dataTable.Rows)
            {
                countList.Add((int)row["ID"]);
                itemList.Add((Item)row["Item"]);
            }
            counts = countList.ToArray();
            return itemList.ToArray();
        }

    }
}
