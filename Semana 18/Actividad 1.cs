using System;
namespace Actividad1Semana18
{

    class Program
    {
        static void Main()
        {
            const int cantidadEstudiantes = 10;
            const int cantidadNotas = 10;

            Estudiante[] estudiantes = new Estudiante[cantidadEstudiantes];

            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                Console.WriteLine($"Ingrese el nombre del estudiante #{i + 1}:");
                string nombre = Console.ReadLine();

                int[] notas = new int[cantidadNotas];

                for (int j = 0; j < cantidadNotas; j++)
                {
                    notas[j] = LeerNotaValida(i + 1, j + 1);
                }
                estudiantes[i] = new Estudiante(nombre, notas);
            }
            
            while (true)
            {
                Console.WriteLine("Seleccione una opción");
                Console.WriteLine("1) Mostrar nombre y notas aprobadas de cada alumno");
                Console.WriteLine("2) Mostrar nombre y notas no aprobadas de cada alumno");
                Console.WriteLine("3) Mostrar el promedio de notas del grupo");
                Console.WriteLine("4) Salir del programa");

                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Notas aprobadas: ");
                        for (int i = 0; i < estudiantes.Length; i++)
                        {
                            estudiantes[i].MostrarNotas(true);
                        }
                        break;

                    case 2:
                        Console.WriteLine("Notas reprobadas");
                        for (int i = 0; i < estudiantes.Length; i++)
                        {
                            estudiantes[i].MostrarNotas(false);
                        }
                        break;
                    case 3:
                        double promedio = CalcularPromedioGeneral(estudiantes);
                        Console.WriteLine("Promedio general del grupo: " + promedio.ToString("F2"));
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente");
                        break;
                }
            }
        }
        
        static int LeerNotaValida(int numeroEstudiante, int numeroNota)
        {
            while (true)
            {
                Console.Write("Ingrese la nota #" + numeroNota + " del estudiante #" + numeroEstudiante + " (0-100)");
                string entrada = Console.ReadLine();

                int nota;
                if (int.TryParse(entrada, out nota))
                {
                    if (nota >= 0 && nota <= 100)
                    {
                        return nota;
                    }
                }
                
                Console.WriteLine("Entrada inválida. Ingrese un número entre 0 y 100.");
            }
        }
    
        static double CalcularPromedioGeneral(Estudiante[] estudiantes)
        {
            int suma = 0;
            int totalNotas = 0;

            for (int i = 0; i < estudiantes.Length; i++)
            {
                for (int j = 0; j < estudiantes[i].Notas.Length;)
                {
                    suma += estudiantes[i].Notas[j];
                    totalNotas++;
                }
            }
            return (double)suma / totalNotas;
        }
    }

        class Estudiante
        {
            public string Nombre;
            public int[] Notas;
            const int NotaMinimaAprobada = 65;
            
            public Estudiante(string nombre, int[] notas)
            {
                Nombre = nombre;
                Notas = notas;
            }
            
            public void MostrarNotas(bool aprobadas)
            {
                int contador = 0;

                for (int i = 0; i < Notas.Length; i++)
                {
                    int nota = Notas[i];
                    if (aprobadas && nota >= NotaMinimaAprobada)
                    {
                        contador++;
                    } else if (!aprobadas && nota < NotaMinimaAprobada)
                    { 
                        contador++;    
                    }

                }
                string tipo = aprobadas ? " aprobadas" : " reprobadas";
                Console.WriteLine(Nombre + " - " + contador + " notas(s)" + tipo);
            }
    
        }
}
