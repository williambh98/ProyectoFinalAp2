using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Metodo
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }


        // Calcular Ganancia
        public static double Ganancia (double Costo, double Precio)
        {
            double Ganancia = 0;
            Ganancia = Precio - Costo;
            Ganancia = Ganancia / Costo;
            Ganancia *= 100;

            return Ganancia;
        }
        
    }
}
