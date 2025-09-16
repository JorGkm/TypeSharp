namespace TypeSharp;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        //Muestra el mensaje de bienvenida
        System.Console.WriteLine(Juego.Inicio());
        Console.ReadLine();
        Console.Clear();
        //Inicia el juego
        Juego.IniciarJuego();
        System.Console.WriteLine(Juego.despedida());
        //Termina el juego
        Console.ReadKey();
    }
}
