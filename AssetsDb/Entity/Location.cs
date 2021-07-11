using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsDb.Entity
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Info { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }

        public Location()
        {
            Assets = new List<Asset>();
        }
    }
}
