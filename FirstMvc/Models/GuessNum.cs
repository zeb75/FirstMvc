using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvc.Models
{
    public class GuessNum
    {
        public int Num { get; set; }
        public string Msg { get; set; }
        public int Answer { get; set; }

        public void CompareNum()
        {

            if (Num == Answer)
            {
                Msg = "Correct answer!";
            }

            else if (Num < Answer)
            {
                Msg = "Too low!";
            }

            else if (Num > Answer)
            {
                Msg = "Too high!";
            }
        }
    }
}
