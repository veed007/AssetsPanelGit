using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsDb.Entity
{
    /// <summary>
    /// Модель актива
    /// </summary>
    public class Asset
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Наименование актива
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Общая сумма
        /// </summary>
        public int Amount { get; set; }
        
        /// <summary>
        /// Валюта
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
        public string Additional { get; set; }

        public int? LocationId { get; set; }
        /// <summary>
        /// Место нахождения актива(банк, касса, собственность)
        /// </summary>
        public virtual Location Location { get; set; }
        public int CompanyId { get; set; }
        /// <summary>
        /// Предприятие
        /// </summary>
        public virtual Company Company { get; set; }
    }
}
