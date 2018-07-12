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
using Trin.OnTour.Business;

namespace Trin.OnTour
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ListarApoderados().ShowDialog();
        }

        private void BTN_BC_Click(object sender, RoutedEventArgs e)
        {
            new BuscarContrato().ShowDialog();
        }

        private void BTN_NA_Click(object sender, RoutedEventArgs e)
        {
            new AgregarCurso().ShowDialog();
        }

        private void BTN_RP_Click(object sender, RoutedEventArgs e)
        {
            new AgregarApoderado().ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new NuevoContrato().ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new Window1().ShowDialog();
        }
    }
}
