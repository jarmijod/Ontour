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
    /// Lógica de interacción para ConfirmarPago.xaml
    /// </summary>
    public partial class ConfirmarPago : Window
    {
        AdministracionViajes Viajes { get; }

        string RutApoderado;
        int Monto;
        long Contrato;

        public ConfirmarPago(string rutAp, int monto, long contrato)
        {
            InitializeComponent();
            Viajes = new AdministracionViajes();
            RutApoderado = rutAp;
            Monto = monto;
            Contrato = contrato;
        }

        private async void BtnContinuar_Click(object sender, RoutedEventArgs e)
        {
            var ct = Viajes.RegistrarDeposito(
                RutApoderado,
                Monto,
                Contrato,
                TXT_EntadadB.Text,
                TXT_Comprobante.Text);

            MessageBox.Show((await ct).msg);
        }
    }
}
