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
        /// Единица измерения(для неденежных)
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// Валюта
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Дополнительная информация
        /// </summary>
        public string Additional { get; set; }
        /// <summary>
        /// Является ли актив денежным
        /// </summary>
        public bool IsMonetary { get; set; }
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
