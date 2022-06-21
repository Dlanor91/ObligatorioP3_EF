using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dominio.EntidadesVivero;
using Dominio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositorios
{
    public class RepositorioPlantaEF : IRepositorioPlantas
    {
        
        public ViveroContext Contexto { get; set; }
        public RepositorioPlantaEF(ViveroContext cont) 
        {
            Contexto = cont;
        }

        public bool Add(Planta obj)
        {
            Contexto.Plantas.Add(obj);
            return Contexto.SaveChanges() >=1;
        }

        public IEnumerable<Planta> buscarPlantasTipoAmbiente(int tipoAmbiente)
        {
            return Contexto.Plantas.Where(pl => pl.TipoAmbiente.Id == tipoAmbiente).ToList();
        }

        public IEnumerable<Planta> buscarPlantaMayorAlt(decimal altura)
        {
            return Contexto.Plantas.Where(pl => pl.AlturaMax >= altura).ToList();
        }

        public IEnumerable<Planta> buscarPlantaMenorAlt(decimal altura)
        {
            return Contexto.Plantas.Where(pl => pl.AlturaMax < altura).ToList();
        }

        public IEnumerable<Planta> buscarPlantaNombre(string nombreBusqPlanta)
        {
            return Contexto.Plantas.Where(pl => pl.NombreCientifico.Contains(nombreBusqPlanta) || pl.NombresVulgares.Contains(nombreBusqPlanta)).ToList();
        }

        public IEnumerable<Planta> buscarTipoPlanta(int TipoPlanta)
        {
            return Contexto.Plantas.Where(pl => pl.TipoPlanta.Id == TipoPlanta).ToList();
        }

        public IEnumerable<Planta> FindAll()
        {
            return Contexto.Plantas.ToList()                           
                           .OrderBy(tp => tp.NombreCientifico);
        }
        
        public Planta FindById(int id)
        {
            return Contexto.Plantas.Find(id);
        }


        public bool Remove(int id)
        {
            Contexto.Plantas.Remove(new Planta() { Id = id });
            return Contexto.SaveChanges() >=1;
        }

        public bool Update(Planta obj)
        {
            throw new NotImplementedException();
        }

        public bool existeNombre(string nombreCPlanta)
        {
            bool plantaBuscada = false;

            Planta existe = Contexto.Plantas.Where(pl => pl.NombreCientifico == nombreCPlanta).SingleOrDefault();

            if (existe != null) plantaBuscada = true;

            return plantaBuscada;
        }
    }
}
