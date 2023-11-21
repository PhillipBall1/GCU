using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneGUI
{
    internal class Products
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public float RetailPrice { get; set; }
        public float WholesalePrice { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int VendorID { get; set; }
    }
}
