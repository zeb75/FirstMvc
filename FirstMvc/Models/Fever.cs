using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvc.Models
{
    public class Fever
    {
        public double Temp { get; set; }
        public string Msg { get; set; }

        public Fever(double temp)
        {
            Temp = temp;
            CalcTemp();
        }

        void CalcTemp()
        {
            if (Temp > 37)
            {
                Msg = "Fever";
            }
            else if (Temp < 35)
            {
                Msg = "Hypothermia";
            }
            else 
            {
                Msg = "Normal";
            }
        }

    }
}