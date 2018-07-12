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
    /// Lógica de interacción para NuevoContrato.xaml
    /// </summary>
    public partial class NuevoContrato : Window
    {
        AdministracionViajes Viajes { get; }
        public NuevoContrato()
        {
            InitializeComponent();
            Viajes = new AdministracionViajes();
        }

        private async void BtnContinuar_Click(object sender, RoutedEventArgs e)
        {
            var ct = Viajes.RegistrarContrato(Int32.Parse(TXT_CantDias.Text), TXT_RutEjecutivo.Text,
                Int64.Parse(TXT_CodCurso.Text), TXT_CodPaquete.Text);

            MessageBox.Show((await ct).msg);
        }
    }
}
