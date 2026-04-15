using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TypeSharp
{
    public class Juego
    {
        private static int _aciertos = 0;
        private static int _fallos = 0;
        //Lógica del juego
        #region Lógica
        private static void Jugando()
        {
            Console.Clear();
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
                _aciertos++;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("¡Incorrecto! La palabra correcta era: " + palabraActual);
                _fallos++;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //Método el cual ejecuta la lógica y la mantiene en un bucle hasta que se cierre
        public static void IniciarJuego(ConsoleKeyInfo tecla)
        {
            if (tecla.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                while (true)
                {
                Jugando();
                Console.WriteLine("Presiona [ENTER] para la siguiente palabra o [ESC] para salir.");
                    if (Menu.RecibirTecla().Key == ConsoleKey.Escape)
                    {
                        Console.Write(Despedida());
                        break;    
                    }
                    
                }
            }
        }
        #endregion

        //Método el cúal contiene el mensaje de despedida y la puntuación
        private static string Despedida()
        {
            Console.Clear();
            return $"\n¡Gracias por jugar!\n\nTus resultados:\n \u25AAPalabras correctas   {_aciertos} \u2713\n \u25AAPalabras erróneas   {_fallos} \u2717";
        }
    }
}