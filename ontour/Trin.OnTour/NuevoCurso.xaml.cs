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
    /// Lógica de interacción para AgregarCurso.xaml
    /// </summary>
    public partial class AgregarCurso : Window
    {
        AdministracionClientes Clientes { get; }

        public AgregarCurso()
        {
            InitializeComponent();
            Clientes = new AdministracionClientes();
        }

        private async void BTN_ConFirmar_Click(object sender, RoutedEventArgs e)
        {
            var ct = Clientes.CrearCursoAsync(TXT_Curso.Text, Int32.Parse(TXT_cantidadAL.Text),
                TXT_institucion.Text, TXT_rutR.Text);

            MessageBox.Show((await ct).msg);
        }
    }
}
