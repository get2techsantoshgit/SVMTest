using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINestedCol.Model
{
    public class Shop
    {
        public Shop()
        {
            accounts = new HashSet<Account>();
        }
        public int id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public ICollection<Account> accounts { get; set; }
    }
}
