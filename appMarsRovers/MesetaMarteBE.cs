using System;
using System.Collections.Generic;
using System.Text;

namespace appMarsRovers
{
    public class MesetaMarteBE
    {
        private int limiteX;
        public int LimiteX
        {
            get
            {
                return limiteX;
            }
            set
            {
                limiteX = value;
            }
        }

        private int limiteY;
        public int LimiteY
        {
            get
            {
                return limiteY;
            }
            set
            {
                limiteY = value;
            }
        }

        public MesetaMarteBE(int pLimiteX, int pLimiteY)
        {
            limiteX = pLimiteX;
            limiteY = pLimiteY;
        }

        public bool ValorX_FueraDeRango(int pValorX)
        {
            return pValorX > limiteX;
        }

        public bool ValorY_FueraDeRango(int pValorY)
        {
            return pValorY > limiteY;
        }

    }
}
