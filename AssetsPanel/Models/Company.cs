using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsPanel.Models
{
    /// <summary>
    /// Модель предприятия
    /// </summary>
    public class Company
    {
        public int CompanyId { get; set; }
        /// <summary>
        /// Наименование предприятия
        /// </summary>
        [Required]
        public string Name { get; set; }
       
        
    }
}
