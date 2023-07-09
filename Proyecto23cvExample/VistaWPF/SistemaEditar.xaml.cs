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
    /// Lógica de interacción para SistemaEditar.xaml
    /// </summary>
    public partial class SistemaEditar : Window
    {
        public SistemaEditar(Usuario request)
        {
            InitializeComponent();
            x = request.PkUsuario;
            TxtNombre.Text = request.Nombre;
            TxtUsuario.Text = request.UserName;
            TxtContraseña.Text = request.Password;
        }
        Usuario usuario = new Usuario();
        UsuarioService services = new UsuarioService();
        Sistema view1 = new Sistema();
        private int x;

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Sistema view1 = new Sistema();
            view1.Show();
            Close();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if(TxtNombre.Text==""||TxtUsuario.Text==""||TxtContraseña.Text=="")
            {
                MessageBox.Show("No Puedes Dejar Campos Vacios :|");
            }
            else
            {
                usuario.PkUsuario = x;
                usuario.Nombre = TxtNombre.Text;
                usuario.UserName = TxtUsuario.Text;
                usuario.Password = TxtContraseña.Text;
                services.EditarUsuario(usuario);
                MessageBox.Show("Se Han Modificado Los Datos :)");
                
            }
        }
    }
}
