using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Relational;
using Proyecto23cvExample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto23cvExample.Context
{
    public class ApplicarionDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server=localhost; Database=23cvproyecto; User=root; Password=; ";
            optionsBuilder.UseMySQL(connection);
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

    }
}
