using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Dominio.InterfacesRepositorio;
using Dominio.EntidadesVivero;
using System.Data;
using System.Linq;

namespace Repositorios
{
    public class ViveroContext : DbContext
    {
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<TipoPlanta> TipoPlantas { get; set; }
        public DbSet<TipoAmbiente> TipoAmbientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Plaza> Plazas { get; set; }
        public DbSet<Importacion> Importaciones { get; set; }
        public DbSet<Iluminacion> Iluminaciones { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Item> Items { get; set; }
        public ViveroContext(DbContextOptions<ViveroContext> opciones) : base(opciones) //aqui configuro el sistema para que inyecte al context
        {
        }
    }
}
