using Proyecto23cvExample.Entities;
using Proyecto23cvExample.Services;
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

namespace Proyecto23cvExample.VistaWPF
{
    /// <summary>
    /// Lógica de interacción para Sistema.xaml
    /// </summary>
    public partial class Sistema : Window
    {
        public Sistema()
        {
            this.InitializeComponent();
            ActualizarTabla();
        }
        UsuarioService services = new UsuarioService();
        Usuario usuario = new Usuario();

        public void ActualizarTabla()
        {
            var solicitudes = services.VerUsuarios();
            DataGridUserTable.ItemsSource = solicitudes;
        }
        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if(TxtNombre.Text == ""||TxtUsuario.Text == ""||TxtContraseña.Text == "")
            {
                MessageBox.Show("Llena Todos Los Campos Necesarios...");
            }
            else
            {
                usuario.Nombre = TxtNombre.Text;
                usuario.UserName = TxtUsuario.Text;
                usuario.Password = TxtContraseña.Text;
                var validacion = services.ValidarAgregarUsuario(usuario);
                if(validacion != "1")
                {
                    services.AgregarUsuario(usuario);
                    MessageBox.Show("Datos Agregados :)");
                    TxtNombre.Clear();
                    TxtUsuario.Clear();
                    TxtContraseña.Clear();
                    ActualizarTabla();
                }
                else
                {
                    MessageBox.Show("Este Usuario Ya Existe :/");
                }
            }
        }
        private void BtnEditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var usuarios = (Usuario)button.DataContext;
            SistemaEditar view1 = new SistemaEditar(usuarios);
            view1.Show();
            Close();
            ActualizarTabla();
        }
        private void BtnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var usuarios = (Usuario)button.DataContext;
            services.Eliminar(usuarios);
            ActualizarTabla();
            MessageBox.Show("Los Datos Se Han Eliminado :)");
        }
    }
}
