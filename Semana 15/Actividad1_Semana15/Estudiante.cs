using System;
using System.Diagnostics.Contracts;
using System.Globalization;

public class Estudiante
{
    string Nombre;
    int Edad;
    string Carrera;
    string Carnet;
    int NotaAdmision; //propiedad clase Pascal Case 

    public static void Main()
    {
        Console.WriteLine("Ingrese su nombre");
        string nombreIngresado = Console.ReadLine();

        Console.WriteLine("Ingrese su edad");
        int edadIngresada = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese su carrera");
        string carreraIngresada = Console.ReadLine();

        Console.WriteLine("Ingrese su carnet");
        string carnetIngresado = Console.ReadLine();

        Console.WriteLine("Ingrese su nota de admisión");
        int NotaAdmision = Convert.ToInt32(Console.ReadLine());

        Estudiante objetoEstudiante = new Estudiante(nombreIngresado, edadIngresada, carreraIngresada, carnetIngresado, NotaAdmision);
        objetoEstudiante.show();

        if (objetoEstudiante.puedeMatricularse()){
            Console.WriteLine("El estudiante puede matricularse"); 
        } else {
            Console.WriteLine("El estudiante no puede matricularse"); 
        }
        
    }

    Estudiante(string Nombre, int Edad, string Carrera, string Carnet, int NotaAdmision){
        this.Nombre = Nombre;
        this.Edad = Edad;
        this.Carrera = Carrera;
        this.Carnet = Carnet;
        this.NotaAdmision = NotaAdmision;
    }

    void show(){
        Console.WriteLine("Datos del estudiante");
        Console.Write("Nombre: ");
        Console.WriteLine(this.Nombre);
        Console.Write("Edad: ");
        Console.WriteLine(this.Edad);
        Console.Write("Carrera: ");
        Console.WriteLine(this.Carrera);
        Console.Write("Carnet: ");
        Console.WriteLine(this.Carnet);
        Console.Write("Nota de Admisión: ");
        Console.WriteLine(this.NotaAdmision);
    }

    public bool puedeMatricularse()
    {
        return NotaAdmision >= 75 && Carnet.EndsWith("2025");
    }

}