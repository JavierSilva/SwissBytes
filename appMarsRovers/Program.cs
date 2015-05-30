using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace appMarsRovers
{
    class Program
    {   
        //Autor         : Javier Silva Sierra
        //Fecha inicio  : 29/05/2015
        //Fecha fin     : 29/05/2015
                  
        static void Main(string[] pUbicacionArchivo)
        {
            try
            {
                if (pUbicacionArchivo.Length == 0)
                    throw new Exception("No se suministro la ruta de un archivo .txt para comenzar el programa");

                IList<string> infoInicial = new List<string>();

                using (StreamReader sr = File.OpenText(pUbicacionArchivo.GetValue(0).ToString()))
                {
                    string s = "";

                    while ((s = sr.ReadLine()) != null)
                        infoInicial.Add(s);
                }

                if ((Convert.ToDecimal(infoInicial.Count) % 2) == 0)
                    throw new Exception("Datos incompletos en el archivo");

                string limiteMatriz = infoInicial[0].ToString().Trim();
                
                if (limiteMatriz.Length != 3)
                    throw new Exception("Datos incorrectos en el tamaño de la matriz");

                int limiteX;
                int limiteY;

                if (Char.IsNumber(limiteMatriz[0]) && Char.IsNumber(limiteMatriz[2]))
                {
                    limiteX = Convert.ToInt32(limiteMatriz[0].ToString());
                    limiteY = Convert.ToInt32(limiteMatriz[2].ToString());
                }               
                else
                    throw new Exception("Datos incorrectos en el tamaño de la matriz");

                IList<RoverBE> listaDeRovers = new List<RoverBE>();
                MesetaMarteBE meseta = new MesetaMarteBE(limiteX, limiteY);

                for (int i = 1; i <= infoInicial.Count - 1; i = i + 2)
                    listaDeRovers.Add(new RoverBE(meseta, infoInicial[i], infoInicial[i + 1]));

                int total = 0;

                foreach (RoverBE rover in listaDeRovers)
                {
                    total++;

                    foreach (char instruccion in rover.InstruccionesMovimiento)
                    {
                        if (instruccion == 'M')
                            rover.Mover();

                        if (instruccion == 'L' || instruccion == 'R')
                            rover.Girar(instruccion);
                    }

                    Console.WriteLine("Posicion final Rover {0} : {1}", total.ToString(), rover.ObtenerPosicionFinal());
                }

                Console.WriteLine("Proceso terminado...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
            }            
        }
    }
}
