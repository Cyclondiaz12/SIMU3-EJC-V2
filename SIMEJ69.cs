using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace Simulación_U3
{
    internal class EJ69
    {
        static void Main()
        {
            Console.WriteLine("Ingrese la concentración media de NH3 en sangre venosa de individuos normales (en microgramos por mililitro): ");
            double med = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el límite inferior de la concentración de NH3 para el 99% de los individuos (en microgramos por mililitro): ");
            double valinf = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el límite superior de la concentración de NH3 para el 99% de los individuos (en microgramos por mililitro): ");
            double valsup = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el porcentaje de intervalo deseado (por ejemplo, 0.70 para el 70%): ");
            double porcint = double.Parse(Console.ReadLine());

            double desv = (valsup - med) / 2.575;

            // Límites del porcentaje de intervalo deseado
            double m = Normal.InvCDF(0, 1, 1 - (1 - porcint) / 2); // P(Z < k) = 1 - (1 - porcint) / 2

            double liminf = med - desv * m;
            double limsup = med + desv * m;

            // Porcentajes 
            double porcsup135 = 1 - Normal.CDF(med, desv, valsup);
            double porcinf95 = Normal.CDF(med, desv, 95);
            double porc90125 = Normal.CDF(med, desv, 125) - Normal.CDF(med, desv, 90);
            double porc85100 = Normal.CDF(med, desv, 100) - Normal.CDF(med, desv, 85);

            Console.WriteLine("Desviación estándar: " + desv);
            Console.WriteLine("");
            Console.WriteLine("Intervalo del " + porcint * 100 + "% de los valores: [" + liminf + ", " + limsup + "]");
            Console.WriteLine("");
            Console.WriteLine("a) Población con más de " + valsup + " microgramos por mililitro: " + porcsup135 * 100 + "%");
            Console.WriteLine("");
            Console.WriteLine("b) Población con menos de 9 microgramos por mililitro: " + porcinf95 * 100 + "%");
            Console.WriteLine("");
            Console.WriteLine("c) Población con entre 90 y 125 microgramos por mililitro: " + porc90125 * 100 + "%");
            Console.WriteLine("");
            Console.WriteLine("d) Población con entre 85 y 100 microgramos por mililitro: " + porc85100 * 100 + "%");
        }
    }
}