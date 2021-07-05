using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_2.Dominio
{
    public class Sector
    {
        private static short UltimoId = 0;
        private string _nombre;
        private int _CantidadAsientos;
        private string[,] matriz;
        

        public short Id
        {
            get;
            set;
        }
        public string[,] Matriz
        {
            get { return matriz; }
            set { matriz = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int CantidadAsientos
        {
            get { return _CantidadAsientos; }
            set { _CantidadAsientos = value; }
        }

        public void IncementarId()
        {
            Sector.UltimoId += 1;
            this.Id = Sector.UltimoId;
        }
        public override string ToString()
        {
            return "Id: " + this.Id + " " + "Nombre: " + this.Nombre + " " + "Cantidad Asientos: " + this.CantidadAsientos;
        }

        public Sector(string pNombre, int pCantidadAsientos)
        {
            this.Id = Sector.UltimoId;
            this.Nombre = pNombre;
            this.CantidadAsientos = pCantidadAsientos;
            this.InizializarMatriz(pCantidadAsientos);
        }

        public void InizializarMatriz(int pCantidad)
        {
            int numero = pCantidad;
            int CantidadFilas = 0;
            int CantidadColumnas = 0;

            if (numero <= 50)
            {
                CantidadFilas = 2;
            }
            else if (numero > 50 && numero <= 100)
            {
                CantidadFilas = 5;
            }
            else
            {
                CantidadFilas = 20;
            }
            CantidadColumnas = numero / CantidadFilas;

            matriz = new string[CantidadFilas, CantidadColumnas];

            for (int i = 0; i < CantidadFilas; i++)
            {
                for (int j = 0; j < CantidadColumnas; j++)
                {
                    matriz[i, j] = "V";
                }

            }
        }



    }
}