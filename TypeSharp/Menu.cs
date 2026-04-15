using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace TypeSharp
{
    public class Menu
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
        public static string InicioV2()
        {
            string bienvenida = """
            
              _______                 _____ _
             |__   __|               / ____| |
                | |   _   _ _ __ ___| (___ | |__   __ _ _ __ _ __
                | |  | | | | '_ \ _ \\___ \| '_ \ / _` | '__| '_ \
                | |  | |_| | |_) | __/___) | | | | (_| | |  | |_) |
                |_|   \__, | .__/  \_____/|_| |_|\__,_|_|  | .__/
                       __/ | |                             | |
                      |___/|_|                             |_|
            
            Autor: JorGkm
            
            Presiona [ENTER] para comenzar o [ESC] para salir.
            """;

            return bienvenida;
        }
        public static ConsoleKeyInfo RecibirTecla()
        {
            ConsoleKeyInfo teclaPulsada;
            do
            {
                teclaPulsada = Console.ReadKey(true);
            }while(teclaPulsada.Key != ConsoleKey.Escape && teclaPulsada.Key != ConsoleKey.Enter);
            //Leerá en un bucle, que tecla pulsa el usuario, en caso de que sea el Enter para empezar o Escape para cerrar
            return teclaPulsada;
        }
    }
}