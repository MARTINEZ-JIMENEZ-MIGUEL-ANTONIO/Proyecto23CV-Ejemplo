using Proyecto23cvExample.Context;
using Proyecto23cvExample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto23cvExample.Services
{
    public class UsuarioService
    {
        public void AgregarUsuario(Usuario request)
        {
			try
			{
				using(var _context = new ApplicarionDBContext())
				{
					Usuario usuario = new Usuario()
					{
						Nombre = request.Nombre,
						UserName = request.UserName,
						Password = request.Password,
					};
					_context.Usuarios.Add(usuario);
					_context.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw new Exception("Error:",ex);
			}
        }
		public List<Usuario> VerUsuarios()
		{
			try
			{
				var _context = new ApplicarionDBContext();
				var versolicitudes = _context.Usuarios.ToList();
				return versolicitudes;
			}
			catch (Exception ex)
			{
				throw new Exception("Error:",ex);
			}
		}
		public void EditarUsuario(Usuario request)
		{
			try
			{
				using(var _context = new ApplicarionDBContext())
				{
					var editarsolicitud = _context.Usuarios.Where(s => s.PkUsuario == request.PkUsuario).First<Usuario>();
					editarsolicitud.Nombre = request.Nombre;
					editarsolicitud.UserName = request.UserName;
					editarsolicitud.Password = request.Password;
					_context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Error:",ex);
			}
		}
		public void Eliminar(Usuario request)
		{
			try
			{
				using(var _context = new ApplicarionDBContext())
				{
					var eliminarsolicitud = _context.Usuarios.FirstOrDefault(s=>s.PkUsuario == request.PkUsuario);
					_context.Usuarios.Remove(eliminarsolicitud);
					_context.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw new Exception("Error:",ex);
			}
		}
		public string ValidarAgregarUsuario(Usuario request)
		{
			try
			{
				var _context = new ApplicarionDBContext();
				var validarusuario = _context.Usuarios.Where(s=>s.UserName == request.UserName).ToList();
				return validarusuario.Count.ToString();
			}
			catch (Exception ex)
			{
				throw new Exception("Error:",ex);
			}
		}
    }
}
