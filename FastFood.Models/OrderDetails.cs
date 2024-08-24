using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Models
{
    public class OrderDetails //it is related to product like cousomer orders details like drinks,food items
    {
        public  int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public Orderheader Orderheader { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

    }
}
