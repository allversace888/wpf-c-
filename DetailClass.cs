using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql
{
    public class DetailClass
    {
            public int id_preparation { get; set; }
            public string drug_name { get; set; }
            public int price { get; set; }
            public int amount { get; set; }
            public string total_price { get; set; }
    }
}