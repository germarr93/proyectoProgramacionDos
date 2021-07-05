using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_2.Dominio
{
    public class Espectaculo
    {
        private static short UltimoId = 0;
        private string _nombre;
        private int _precio;
        private string _tipoEspectaculo;
        private Sala _Sala;
        private Auspiciante _Auspiciante;
        private Cartelera _Cartelera;

        public short Id
        {
            get;
            set;
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public string Tipo
        {
            get { return _tipoEspectaculo; }
            set { _tipoEspectaculo = value; }
        }
        public Sala Sala
        {
            get { return _Sala; }
            set { _Sala = value; }
        }

        public Auspiciante Auspiciante
        {
            get { return _Auspiciante; }
            set { _Auspiciante = value; }
        }

        public override string ToString()
        {
            return "Id: " + this.Id + " " + "Nombre: " + this.Nombre + " " + "Precio: " + this.Precio + " " +
                "Tipo: " + this.Tipo + " " + "Sala: " + this.Sala.Id;
        }

        public void IncrementarId()
        {
            Espectaculo.UltimoId += 1;
            this.Id = Espectaculo.UltimoId;
        }

        public Espectaculo(string pNombre, int pPrecio, string pTipo, Sala pSala)
        {
            this.Id = Espectaculo.UltimoId;
            this.Nombre = pNombre;
            this.Precio = pPrecio;
            this.Tipo = pTipo;
            this.Sala = pSala;
        }




        private List<Auspiciante> _listaAuspiciante = new List<Auspiciante>();

        public List<Auspiciante> ListaAuspiciantesEnEspectaculo()
        {
            return _listaAuspiciante;
        }

        public Auspiciante BuscarAuspiciante(short pId)
        {
            foreach (Auspiciante unAuspiciante in _listaAuspiciante)
            {
                if (unAuspiciante.Id == pId)
                {
                    return unAuspiciante;
                }
            }
            return null;
        }

        public void AsignarAuspiciante(Auspiciante pAuspiciante)
        {
            Dominio.Auspiciante unAuspiciante = this.BuscarAuspiciante(pAuspiciante.Id);
            if (unAuspiciante == null)
            {
                _listaAuspiciante.Add(pAuspiciante);
            }
        }

        public void RemoverAuspiciante(Auspiciante pAuspiciante)
        {
            Dominio.Auspiciante unAuspiciante = this.BuscarAuspiciante(pAuspiciante.Id);
            if (unAuspiciante != null)
            {
                _listaAuspiciante.Remove(unAuspiciante);
            }
        }

        public Cartelera Cartelera
        {
            get { return _Cartelera; }
            set { _Cartelera = value; }
        }
        public Cartelera ConsultaCartelera()
        {
            return Cartelera;
        }
    }
}