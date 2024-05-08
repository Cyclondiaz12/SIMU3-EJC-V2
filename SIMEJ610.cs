using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace Simulación_U3
{
    internal class EJ610
    {
        static void Main()
        {
            Console.WriteLine("Ingrese la probabilidad de que el índice sea menor que 165 (porcentaje): ");
            double probA = double.Parse(Console.ReadLine()) / 100; // Convertir a decimal

            Console.WriteLine("Ingrese la probabilidad de que el índice esté entre 165 y 180 (porcentaje): ");
            double probB = double.Parse(Console.ReadLine()) / 100; // Convertir a decimal

            Console.WriteLine("Ingrese el límite inferior del rango (en centigramos): ");
            double limInf = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el límite superior del rango (en centigramos): ");
            double limSup = double.Parse(Console.ReadLine());

            // Z
            var distribucionNormal = new Normal(0, 1);

            //Inf y Sup
            double zInferior = distribucionNormal.InverseCumulativeDistribution(probA);
            double zSuperior = distribucionNormal.InverseCumulativeDistribution(probA + probB);

            // Desviación estándar y media
            double desv2 = (limSup - limInf) / (zSuperior - zInferior);
            double media2 = limInf - zInferior * desv2;

            Console.WriteLine("a) ");
            Console.WriteLine($"Media: {media2:F2}");
            Console.WriteLine(" ");
            Console.WriteLine($"Desviación típica: {desv2:F2}");
            Console.WriteLine(" ");
            Console.WriteLine("b) ");

            double limTratamiento = 183;


            double zTratamiento = (limTratamiento - media2) / desv2;  // Z en límite de tratamiento


            double probTratamiento = 1 - distribucionNormal.CumulativeDistribution(zTratamiento);  // Probabilidad de tratamiento


            int poblacionTotal = 100000; // Población


            int personasTratamiento = (int)(poblacionTotal * probTratamiento); //Personas que necesitan tratamiento


            // Resultados finales
            Console.WriteLine($"Probabilidad de tener un índice mayor a 183: {probTratamiento:P2}");
            Console.WriteLine(" ");
            Console.WriteLine($"Número de personas a tratar en una población de 100000 individuos: {personasTratamiento}");
        }
    }
}