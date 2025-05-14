namespace Actividad1Semana18;

class Program
{
    const int NumeroEstudiantes = 10;
    const int NumeroNotas = 10;
    const int NotaAprobar = 65;
    static void Main()
    {

        string[] nombreEstudiantes = new string[NumeroEstudiantes];
        int[,] notas = new int[NumeroEstudiantes, NumeroNotas];

        for(int i = 0; i < NumeroEstudiantes; i++)
        {
            Console.WriteLine($"Nombre del estudiante #{i + 1}:");
            nombreEstudiantes[i] = Console.ReadLine();

            for (int j = 0; j < NumeroNotas; j++)
            {
                notas[i, j] = LeerNotaValida(i + 1, j + 1);
            }
        }

        while(true)
        {
            Console.WriteLine("Seleccione alguna de las siguientes opciones: ");
            Console.WriteLine("1) Mostrar nombre y notas aprobadas pde cada alumno");
            Console.WriteLine("2) Mostrar nombre y notas no aprobadas de cada alumno");
            Console.WriteLine("3) Mostrar el promedio de notas del grupo");
            Console.WriteLine("4) Salir del programa");
            string opcion = Console.ReadLine();
            
            switch (opcion)
            {
                case "1":
                    MostrarNotas(nombreEstudiantes, notas, true);
                    break;
                case "2":
                    MostrarNotas(nombreEstudiantes, notas, false);
                    break;
                case "3":
                    Console.WriteLine($"Promedio del grupo: {MostrarPromedioGeneral(notas)}");
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }

        static int LeerNotaValida(int numeroEstudiante, int notaEstudiante)
        {
            while(true)
            {
                Console.Write($"Nota del estudiante No. {numeroEstudiante}: {notaEstudiante} (0-100): ");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int nota))
                {
                    if (nota >= 0 && nota <= 100)
                    { 
                    return nota;
                    }
                }

                Console.WriteLine("Entrada inválida. Ingrese un número entre 0 y 100.");
            }
        }

        static void MostrarNotas(string[] nombres, int[,] notas, bool aprobadas)
        {
            if (aprobadas)
                Console.WriteLine("\nAprobados:");
            else
                Console.WriteLine("\nReprobados:");

            for (int i = 0; i < NumeroEstudiantes; i++)
            {
                int contador = 0;

                for (int j = 0; j < NumeroNotas; j++)
                {
                    bool Aprobada = notas[i, j] >= NotaAprobar;

                    if (Aprobada == aprobadas)
                    {
                        contador++;
                    }
                }

                string tipo;
                if (aprobadas)
                {
                    tipo = "aprobadas";
                }
                else
                {
                    tipo = "reprobadas";
                }

                Console.WriteLine($"{nombres[i]} - {contador} nota(s) {tipo}");


        }

        static void MostrarPromedioGeneral(int[,] notas)
        {
            int suma = 0;
            int total = NumeroEstudiantes * NumeroNotas;

            for (int i = 0; i < NumeroEstudiantes; i++)
            {
                for (int j = 0; j < NumeroNotas; j++)
                {
                    suma += notas[i, j];
                }
            }

            double promedio = (double)suma / total;
            Console.WriteLine($"\nPromedio general del grupo: {promedio:F2}");

        }

}
}
}
