using System;
using System.Collections.Generic;
using System.Text;

namespace appMarsRovers
{
    public class RoverBE
    {
        private MesetaMarteBE meseta;
        public MesetaMarteBE Meseta
        {
            get
            {
                return meseta;
            }
            set
            {
                meseta = value;
            }
        }

        private string posInicial;
        public string PosicionInicial
        {
            get
            {
                return posInicial;
            }
            set
            {
                posInicial = value;
            }
        }              

        private string instrucMovimiento;
        public string InstruccionesMovimiento
        {
            get
            {
                return instrucMovimiento;
            }
            set
            {
                instrucMovimiento = value;
            }
        }

        private int posicionX;      
        private int posicionY;
        private char orientacion;

        public RoverBE(MesetaMarteBE pMeseta, string pPosicionInicial, string pInstruccionesMovimiento)
        {
            meseta = pMeseta;
            posInicial = pPosicionInicial.Trim();
            instrucMovimiento = pInstruccionesMovimiento.Trim();

            if (PosicionCorrecta(posInicial))
            {
                posicionX = Convert.ToInt32(posInicial[0].ToString());
                posicionY = Convert.ToInt32(posInicial[2].ToString());
                orientacion = posInicial[4];
            }
            else
                throw new Exception("Datos incorrectos en la posicion del Rover");            
        }

        private bool PosicionCorrecta(string pPosicionInicial)
        {
            if (pPosicionInicial.Length != 5)
                return false;

            return Char.IsNumber(pPosicionInicial[0]) && Char.IsNumber(pPosicionInicial[2]) && Char.IsLetter(pPosicionInicial[4]);
        }

        public void Girar(char direccion)
        {
            if (direccion == 'L' && orientacion == 'N')
            {
                orientacion = 'W';
                return;
            }

            if (direccion == 'L' && orientacion == 'S')
            {
                orientacion = 'E';
                return;
            }

            if (direccion == 'L' && orientacion == 'E')
            {
                orientacion = 'N';
                return;
            }

            if (direccion == 'L' && orientacion == 'W')
            {
                orientacion = 'S';
                return;
            }

            if (direccion == 'R' && orientacion == 'N')
            {
                orientacion = 'E';
                return;
            }

            if (direccion == 'R' && orientacion == 'S')
            {
                orientacion = 'W';
                return;
            }

            if (direccion == 'R' && orientacion == 'E')
            {
                orientacion = 'S';
                return;
            }

            if (direccion == 'R' && orientacion == 'W')
            {
                orientacion = 'N';
                return;
            }
        }

        public void Mover()
        {   
            switch (orientacion)
            {
                case 'N':      
                    if (!meseta.ValorY_FueraDeRango(posicionY + 1))
                        posicionY++;

                    break;

                case 'S':
                    if (!meseta.ValorY_FueraDeRango(posicionY - 1))
                        posicionY--;

                    break;

                case 'E':
                    if (!meseta.ValorX_FueraDeRango(posicionX + 1))
                        posicionX++;                                    

                    break;

                case 'W':
                    if (!meseta.ValorX_FueraDeRango(posicionX - 1))
                        posicionX--;

                    break;
            }
        }

        public string ObtenerPosicionFinal()
        {
            return posicionX.ToString() + " " + posicionY.ToString() + " " + orientacion.ToString();
        }
    }
}
