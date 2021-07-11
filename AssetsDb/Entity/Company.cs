using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsDb.Entity
{
    /// <summary>
    /// Модель предприятия
    /// </summary>
    public class Company
    {   
        [Key]
        public int CompanyId { get; set; }
        /// <summary>
        /// Наименование предприятия
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список активов предприятия
        /// </summary>
        public virtual ICollection<Asset> Assets { get; set; }

        public Company()
        {
            Assets = new List<Asset>();
        }
    }
}
