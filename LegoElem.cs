using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickStore
{
//    <Item>
//                                                              <ItemID>52501</ItemID>
//   <ItemTypeID>P</ItemTypeID>
//   <ColorID>85</ColorID>
//                                                              <ItemName>Slope, Inverted 45 6 x 1 Double with 1 x 4 Cutout</ItemName>
//   <ItemTypeName>Part</ItemTypeName>
//                                                              <ColorName>Dark Bluish Gray</ColorName>
//   <CategoryID>32</CategoryID>
//                                                              <CategoryName>Slope, Inverted</CategoryName>
//   <Status>I</Status>
//                                                              <Qty>2</Qty>
//   <Price>0.000</Price>
//   <Condition>N</Condition>
//   <OrigQty>4</OrigQty>
//  </Item>
    internal class LegoElem
    {
        string id;
        string name;
        string category;
        string color;
        int quantity;

        //char itemTypeID;
        //int colorID;
        //string itemTypeName;
        //int categoryID;
        //char status;
        //double price;
        //char condition;
        //int origQty;

        public LegoElem(string id, string name, string categoryName, string colorName, int quantity) {
            this.id = id;
            this.name = name;
            category = categoryName;
            color = colorName;
            this.quantity = quantity;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Color { get => color; set => color = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        //public LegoElem(string id, string name, string category, string color, int quantity, char itemTypeID, int colorID, string itemTypeName, int categoryID, char status, double price, char condition, int origQty)
        //{
        //    this.id = id;
        //    this.name = name;
        //    this.category = category;
        //    this.color = color;
        //    this.quantity = quantity;


        //    this.itemTypeID = itemTypeID;
        //    this.colorID = colorID;
        //    this.itemTypeName = itemTypeName;
        //    this.categoryID = categoryID;
        //    this.status = status;
        //    this.price = price;
        //    this.condition = condition;
        //    this.origQty = origQty;
        //}


    }
}
