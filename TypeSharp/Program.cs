namespace TypeSharp;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        //Muestra el mensaje de bienvenida
        Console.Write(Menu.InicioV2());
        ConsoleKeyInfo entradaUsuario = Menu.RecibirTecla();
        //Inicia el juego
        Juego.IniciarJuego(entradaUsuario);
    }
}
