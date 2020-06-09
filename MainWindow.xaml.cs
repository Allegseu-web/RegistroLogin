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
            Caja_Usuario.Text = "";
            Caja_Contraseña.Password = "";
            Caja_Confirmar.Password = "";
        }

        private void Guardar_Boton(object sender, RoutedEventArgs e)
        {
            if (Validar() == true && Confirmar() == true)
            {
                Usuarios nueva = new Usuarios();
                nueva.NombreUsuario = Caja_Usuario.Text;
                nueva.Contraseña = Caja_Contraseña.Password;
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
                Caja_Usuario.Text = CuentaActual.NombreUsuario;
                Caja_Contraseña.Password = CuentaActual.Contraseña;
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
            if(Caja_Usuario.Text.Length == 0 && Caja_Contraseña.Password.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Los campos estan vacio.");
            }
            return esValido;
        }
        private bool Confirmar()
        {
            bool confirm = false;
            if (Caja_Contraseña.Equals(Caja_Confirmar)){
                return confirm = true;
            }
            return confirm;
        }
    }
}
