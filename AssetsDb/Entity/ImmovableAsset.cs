using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsDb.Entity
{
    public class ImmovableAsset:Asset
    {
        /// <summary>
        /// Начальная балансовая стоимость
        /// </summary>
        public int Initial_val { get; set; }
        /// <summary>
        /// Остаточная балансовая стоимость
        /// </summary>
        public int Residual_val { get; set; }
        /// <summary>
        /// Оценочная стоимость
        /// </summary>
        public int Assessed_val { get; set; }
        /// <summary>
        /// Адрес (координаты)
        /// </summary>
        public string Address { get; set; }
    }
}
