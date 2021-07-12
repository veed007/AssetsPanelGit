using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AssetsDb.Entity;

namespace AssetsPanel.Converters
{
    public class AssetTemplateSelector: DataTemplateSelector
    {
        public DataTemplate AssetTemplate { get; set; }
        public DataTemplate MovableAssetTemplate { get; set; }
        public DataTemplate ImmovableAssetTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            string s = item.GetType().ToString().Split('_')[0];
            switch (s)
            {
                case "AssetsDb.Entity.MovablesAsset":
                    return MovableAssetTemplate;
                case "AssetsDb.Entity.ImmovableAsset":
                    return ImmovableAssetTemplate;
                case "AssetsDb.Entity.Asset":
                    return AssetTemplate;
                case "System.Data.Entity.DynamicProxies.MovablesAsset":
                    return MovableAssetTemplate;
                case "System.Data.Entity.DynamicProxies.ImmovableAsset":
                    return ImmovableAssetTemplate;
                case "System.Data.Entity.DynamicProxies.Asset":
                    return AssetTemplate;
                default:
                    return null;
            }
        }
    }
}
