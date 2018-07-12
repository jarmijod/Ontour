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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        AdministracionViajes Viajes { get; }
        public Window1()
        {
            InitializeComponent();
            Viajes = new AdministracionViajes();
        }

        private async void BtnContinuar_Click(object sender, RoutedEventArgs e)
        {
            var ct = Viajes.RegistrarPago(TXT_RutApoderado.Text, 
                Int32.Parse(TXT_MontoPagado.Text), 
                Int64.Parse(TXT_CodigoContrato.Text));

            MessageBox.Show((await ct).msg);
        }

        private void BtnDeposito_Click(object sender, RoutedEventArgs e)
        {
            var w = new ConfirmarPago(TXT_RutApoderado.Text,
                Int32.Parse(TXT_MontoPagado.Text),
                Int64.Parse(TXT_CodigoContrato.Text));
            w.ShowDialog();
        }
    }
}
