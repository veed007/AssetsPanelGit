using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AssetsPanel.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditLocationWindow.xaml
    /// </summary>
    public partial class EditLocationWindow : Window
    {
        public EditLocationWindow()
        {
            InitializeComponent();
        }

       

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
