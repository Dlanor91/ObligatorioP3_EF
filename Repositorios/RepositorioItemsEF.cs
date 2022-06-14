using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositorios
{
    public class RepositorioItemsEF : IRepositorioItems
    {
        public ViveroContext Contexto { get; set; }

        public RepositorioItemsEF(ViveroContext cont)
        {
            Contexto = cont;
        }

        public bool Add(Item obj)
        {
            Contexto.Items.Add(obj);
            return Contexto.SaveChanges() >=1;
        }

        public IEnumerable<Item> FindAll()
        {
            return Contexto.Items.ToList();
        }

        public Item FindById(int id)
        {
            return Contexto.Items.Find(id);
        }

        public bool Remove(int id)
        {
            Contexto.Items.Remove(new Item() { Id = id });
            return Contexto.SaveChanges() >=1;
        }

        public bool Update(Item obj)
        {
            Contexto.Items.Update(obj);
            return Contexto.SaveChanges()>=1;
        }
    }
}
