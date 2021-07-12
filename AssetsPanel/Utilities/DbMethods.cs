using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsDb;
using AssetsDb.Entity;

namespace AssetsPanel.Utilities
{
    public static class DbMethods
    {
        /// <summary>
        /// Клонирование актив
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        public static Asset Clone(this Asset asset)
        {
            return new Asset
            {
                //Id = asset.Id,
                //Name = asset.Name,
                //Amount = asset.Amount,
                //IsMonetary = asset.IsMonetary,
                //Additional = asset.Additional,
                //Assessed_val = asset.Assessed_val,
                //Residual_val = asset.Residual_val,
                //Unit = asset.Unit,
                //Count = asset.Count,
                //Currency = asset.Currency,
                //LocationId = asset.LocationId,
                //Location = asset.Location
            };
        }
        public static Location Clone(this Location location)
        {
            return new Location
            {
                Id = location.Id,
                Name = location.Name,
                Info = location.Info
            };
        }



    }
}
