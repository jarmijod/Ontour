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
    /// Lógica de interacción para AgregarApoderado.xaml
    /// </summary>
    public partial class AgregarApoderado : Window
    {
        AdministracionClientes Clientes { get; }

        public AgregarApoderado()
        {
            InitializeComponent();
            Clientes = new AdministracionClientes();
        }

        private void CbEstablecimiento_TextChanged(object sender, TextChangedEventArgs e)
        {
            CbCurso.ItemsSource = Clientes.GetAllCursos(CbEstablecimiento.Text);
        }

        private async void BTN_ingresarA_Click(object sender, RoutedEventArgs e)
        {
            if(Representante.IsChecked.Value)
            {
                var ct = Clientes.CrearRepresentanteAsync(
                    TXT_rutAP.Text, TXT_nombreAP.Text, TXT_correoE.Text, Clientes.GetIdCurso(CbCurso.SelectedItem),
                    TXT_numeroT.Text);

                MessageBox.Show((await ct).msg);
            }
            else
            {
                var ct = Clientes.CrearApoderadoAsync(
                    TXT_rutAP.Text, TXT_nombreAP.Text, TXT_correoE.Text, Clientes.GetIdCurso(CbCurso.SelectedItem),
                    TXT_rutAL.Text, TXT_numeroT.Text);

                MessageBox.Show((await ct).msg);
            }
        }
    }
}
