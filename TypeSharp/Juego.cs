using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TypeSharp
{
    public class Juego
    {
        //Inicio del programa con la bienvenida
        public static string Inicio()
        {
            Console.Title = "TypeSharp";
            string[] Menu = {
                "¡Binvenid@ a TypeSharp!",
                "Autor: JorGkm",
                "",
                "Presiona [ENTER] para comenzar."
            };
            int LongitudMenu = 0;
            int relleno = 4;
            foreach (string linea in Menu)
            {
                if (linea.Length > LongitudMenu)
                {
                    LongitudMenu = linea.Length + relleno;
                }
            }
            //Recorre todas las lineas del menú hasta encontrar la más larga, a partir de ella será nuestro valor de inicio para crear el ancho/
            //largo del menú, finalmente le añadimos X cantidad de padding a cada lado.
            string lineaH = new string('\u2550', LongitudMenu);
            string lineaV = "\u2551";
            char SubEsquinaIZQ = '\u2554';
            char SubEsquinaDER = '\u2557';
            char InfEsquinaIZQ = '\u255A';
            char InfEsquinaDER = '\u255D';

            StringBuilder bienvenida = new StringBuilder();
            bienvenida.AppendLine($"{SubEsquinaIZQ}{lineaH}{SubEsquinaDER}");
            foreach (string linea in Menu)
            {
                string TextoCentrado = linea.PadLeft(linea.Length + ((LongitudMenu - linea.Length) / 2)).PadRight(LongitudMenu);
                bienvenida.AppendLine($"{lineaV}{TextoCentrado}{lineaV}");

            }
            bienvenida.AppendLine($"{InfEsquinaIZQ}{lineaH}{InfEsquinaDER}");
            return bienvenida.ToString();
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
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("¡Incorrecto! La palabra correcta era: " + palabraActual);
                fallos++;
                Console.ForegroundColor = ConsoleColor.White;
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
            return $"\n¡Gracias por jugar!\n\nTus resultados:\n \u25AAPalabras correctas   {aciertos} \u2713\n \u25AAPalabras erróneas   {fallos} \u2717";
        }
    }
}