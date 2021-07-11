using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsPanel.Models
{
    /// <summary>
    /// Модель актива
    /// </summary>
    public class Asset
    {
        
        public int Id { get; set; }
        /// <summary>
        /// Наименование актива
        /// </summary>
        [Required]
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
        /// Единица измерения
        /// </summary>
        public string Unit { get; set; }
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
        public Location Location { get; set; }
        public Company Company { get; set; }
        
        
    }
}
