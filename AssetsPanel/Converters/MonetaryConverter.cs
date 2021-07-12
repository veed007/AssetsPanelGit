using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AssetsPanel.Converters
{
    public class MonetaryConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value!=null)
            {
                string s = value.GetType().ToString().Split('_')[0];
                switch (s)
                {
                    case "AssetsDb.Entity.MovablesAsset":
                        return "Движимое имущество";
                    case "AssetsDb.Entity.ImmovableAsset":
                        return "Недвижимость";
                    case "AssetsDb.Entity.Asset":
                        return "Денежный";
                    case "System.Data.Entity.DynamicProxies.MovablesAsset":
                        return "Движимое имущество";
                    case "System.Data.Entity.DynamicProxies.ImmovableAsset":
                        return "Недвижимость";
                    case "System.Data.Entity.DynamicProxies.Asset":
                        return "Денежный";
                    default:
                        return null;
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
