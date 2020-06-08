using LoginRegistro.BLL;
using LoginRegistro.Entidades;
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

namespace LoginRegistro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cuenta CuentaActual = new Cuenta();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Borrar()
        {
            this.CuentaActual = new Cuenta();
            this.DataContext = CuentaActual;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cuenta nueva = new Cuenta();
            nueva.Correo = Correo.Text;
            nueva.Contraseña = pass.Text;
            CuentasBLL.Guardar(nueva);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int aidi = Int32.Parse(aidixd.Text);
            CuentasBLL.Borrar(aidi);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int aidi = Int32.Parse(aidixd.Text);
            this.CuentaActual = CuentasBLL.Buscar(aidi);
            if(CuentaActual != null)
            {
                Correo.Text = CuentaActual.Correo;
                pass.Text = CuentaActual.Contraseña;
                CuentaActual = null;
            }
            else
            {
                MessageBox.Show("No se encontro informacion.");
            }
        }
    }
}
