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
using Trin.OnTour.Business;

namespace Trin.OnTour
{
    /// <summary>
    /// Lógica de interacción para ListarApoderados.xaml
    /// </summary>
    public partial class ListarApoderados : Window
    {
        AdministracionClientes Clientes { get; }

        public ListarApoderados()
        {
            InitializeComponent();
            Clientes = new AdministracionClientes();
        }

        private void TXT_COD_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DtgClientes.ItemsSource = Clientes.GetAllApoderados();
        }
    }
}
