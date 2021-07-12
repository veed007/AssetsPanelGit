using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsDb.Entity
{
    public class MovablesAsset:Asset
    {
        /// <summary>
        /// Единица измерения(для неденежных)
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }

    }
}
