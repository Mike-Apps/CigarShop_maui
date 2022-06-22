using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CigarShop_maui.Model
{
    public class CigarModel
    {
            public string Name { get; set; }
            public string Location { get; set; }
            public string Details { get; set; }
            public string Image { get; set; }
            public string Cost { get; set; }
            public int Inventory { get; set; }
            public float Latitude { get; set; }
            public float Longitude { get; set; }
    }
}
