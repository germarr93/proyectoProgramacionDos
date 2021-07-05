using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_2.Dominio
{
    public class Validacion
    {

        public bool ValidarCedula(int pCedula)
        {


            string cl = pCedula.ToString();
            if (cl.Length == 8)
            {
                // string[] cedula = cl.Split(new char[] { ' ' });
                int Posicion = 0;
                int OctavoDigito = 0;

                int[] NumerosDividios = new int[8];

                foreach (Char PorCadaCaracter in cl)
                {
                    for (int i = 0; i < NumerosDividios.Length; i++)
                    {

                        if (i == Posicion)
                        {
                            NumerosDividios[i] = int.Parse(PorCadaCaracter.ToString());
                            Posicion++;
                            break;

                        }
                    }
                }
                NumerosDividios[0] = NumerosDividios[0] * 2 % 10;
                NumerosDividios[1] = NumerosDividios[1] * 9 % 10;
                NumerosDividios[2] = NumerosDividios[2] * 8 % 10;
                NumerosDividios[3] = NumerosDividios[3] * 7 % 10;
                NumerosDividios[4] = NumerosDividios[4] * 6 % 10;
                NumerosDividios[5] = NumerosDividios[5] * 3 % 10;
                NumerosDividios[6] = NumerosDividios[6] * 4 % 10;
                OctavoDigito = NumerosDividios[7];


                int ResultadoSuma = NumerosDividios[0] + NumerosDividios[1] + NumerosDividios[2] +

                     NumerosDividios[3] + NumerosDividios[4] + NumerosDividios[5] + NumerosDividios[6];
                ResultadoSuma = ResultadoSuma % 10;
                ResultadoSuma = 10 - ResultadoSuma;
                if (OctavoDigito == ResultadoSuma)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        
    }
}
