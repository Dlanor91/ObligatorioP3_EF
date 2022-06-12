using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositorios
{
    public class RepositorioUsuarioEF : IRepositorioUsuario

    {
        public ViveroContext Contexto { get; set; }
        public RepositorioUsuarioEF(ViveroContext cont)
        {
            Contexto = cont;
        }

        public bool Add(Usuario nuevoUsuario)
        {
            Contexto.Usuarios.Add(nuevoUsuario);
            return Contexto.SaveChanges() >= 1;
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios.ToList();
        }

        public Usuario FindById(int id)
        {
            return Contexto.Usuarios.Find(id);
        }

        public Usuario Ingreso(string email, string contrasenia)
        {
            return Contexto.Usuarios.Where(us => us.Email == email && us.Contrasenia == contrasenia).SingleOrDefault();
        }

        public bool Remove(int id)
        {
            Contexto.Usuarios.Remove(new Usuario() { Id = id });
            return Contexto.SaveChanges() >= 1;
        }

        public bool Update(Usuario obj)
        {
            Contexto.Usuarios.Update(obj);
            return Contexto.SaveChanges() >= 1;
        }
    }
}
