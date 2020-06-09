using LoginRegistro.BLL;
using LoginRegistro.Entidades;
using System;
using System.Windows;

namespace LoginRegistro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Usuarios CuentaActual = new Usuarios();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Borrar()
        {
            this.CuentaActual = new Usuarios();
            this.DataContext = CuentaActual;
            Correo.Text = "";
            pass.Text = "";
        }

        private void Guardar_Boton(object sender, RoutedEventArgs e)
        {
            if (Validar() == true)
            {
                Usuarios nueva = new Usuarios();
                nueva.Correo = Correo.Text;
                nueva.Contraseña = pass.Text;
                CuentasBLL.Guardar(nueva);
            }
            else
            {
                //nada
            }
            
        }

        private void Borrar_Boton(object sender, RoutedEventArgs e)
        {
            int aidi = Int32.Parse(aidixd.Text);
            CuentasBLL.Borrar(aidi);
        }

        private void Buscar_Boton(object sender, RoutedEventArgs e)
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

        private void Nuevo_Boton(object sender, RoutedEventArgs e)
        {
            Borrar();
        }

        private bool Validar()
        {
            bool esValido = true;
            if(Correo.Text.Length == 0 && pass.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Los campos estan vacio.");
            }
            return esValido;
        }
    }
}
