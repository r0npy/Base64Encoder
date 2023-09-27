using System;
using System.IO;

namespace Base64Encoder
{
    internal class Program
    {
        private static readonly string ZIPFILE = "FILE.ZIP";
        private static readonly string TXTFILE = "FILE.TXT";

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Ingrese [C] si desea codificar su archivo ZIP o [D] para decodificarlo");

                string action = Console.ReadLine();

                string base64String;
                byte[] fileBytes;

                switch (action.ToUpper())
                {
                    case "D":
                        Console.WriteLine($"En la carpeta de este mismo ejecutable debe copiar el archivo [{TXTFILE}]");

                        base64String = File.ReadAllText(TXTFILE);
                        fileBytes = Convert.FromBase64String(base64String);

                        File.WriteAllBytes(ZIPFILE, fileBytes);

                        break;
                    case "C":
                        Console.WriteLine($"En la carpeta de este mismo ejecutable debe copiar el archivo [{ZIPFILE}]");

                        fileBytes = File.ReadAllBytes(ZIPFILE);
                        base64String = Convert.ToBase64String(fileBytes);
                        File.WriteAllText(TXTFILE, base64String);

                        break;
                    default:
                        Console.WriteLine("Solo está admitido [C] y [D], vuelta a abrir el programa si desea continuar");
                        Console.ReadLine();
                        break;
                }

                Console.WriteLine($"Proceso finalizado correctamente");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                Console.ReadLine();
            }
        }
    }
}
