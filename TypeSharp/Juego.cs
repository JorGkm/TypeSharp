using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TypeSharp
{
    public class Juego
    {
        //Inicio del programa con la bienvenida
        public static string Inicio()
        {
            string bienvenida = "¡Binvenid@ a TypeSharp!\nPresiona [ENTER] para comenzar.";
            return bienvenida;
        }
        public static int aciertos = 0;
        public static int fallos = 0;
        //Lógica del juego
        #region Lógica
            public static void Jugando()
            {
            Random azar = new Random();
            int indice = azar.Next(0, Palabras.palabras.Length);
            string palabraActual = Palabras.palabras[indice];
            Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.WriteLine(palabraActual);
            Console.ForegroundColor = ConsoleColor.White;
            string palabraUsuario = Console.ReadLine() ?? "";
            if (palabraUsuario == null)
            {
                return;
            }
            else if (palabraUsuario == palabraActual)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("¡Correcto!");
                aciertos++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("¡Incorrecto! La palabra correcta era: " + palabraActual);
                fallos++;
            }
        }
        //Método el cual ejecuta la lógica y la mantiene en un bucle hasta que se cierre
        public static void IniciarJuego()
        {
            while (true)
            {
                Juego.Jugando();
                Console.WriteLine("Presiona [ENTER] para la siguiente palabra o [Q] para salir.");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    break;
                }
            }
            Console.Clear();
        }
        #endregion

        //Método el cúal contiene el mensaje de despedida y la puntuación
        public static string despedida()
        {
            return $"\n¡Gracias por jugar!\n\nTus resultados:\nPalabras correctas   {aciertos}\nPalabras erróneas   {fallos}";
        } 
    }
}