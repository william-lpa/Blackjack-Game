using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo21TrabalhoDeRedes.Jogo
{
    public enum Suit {CLUB, SPADE, HEART, DIAMOND};
    struct Card
    {
        private string name;
        public string Name { get { return name; }
            set
            {
                if (value == "A")
                {
                    Valor = 1;
                }
                else if (value == "J" || value == "Q" || value == "K")
                {
                    Valor = 10;
                }
                else
                {
                    Valor = int.Parse(value);
                }
                name = value;
            }
        }
        public int Valor { get; set; }
        public  Suit Suit{ get; set; }

        public override string ToString()
        {
            return Name + "-" + Suit.ToString();
        }
    }
}
