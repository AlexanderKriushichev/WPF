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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int maxRange = 0;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Bar bar = new Bar();
            bar.name.Content = nameBox.Text;
            bar.dataBar.Value = Convert.ToInt32(valueBox.Text);
            if (maxRange < Math.Abs(Convert.ToInt32(valueBox.Text)))
                maxRange = Math.Abs(Convert.ToInt32(valueBox.Text));
            bar.dataBar.Range = maxRange;
            foreach (UIElement child in stackPanel.Children)
            {
                (child as Bar).dataBar.Range = maxRange;
            }
            stackPanel.Children.Add(bar);
            stackPanel.Height += 100;
            scrollViewer.Content = stackPanel;
        }
    }
}
