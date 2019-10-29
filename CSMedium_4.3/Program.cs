using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMedium
{
    class Program
    {
        private static List<ISymbolHandler> _symbolHandlers;

        static void Main(string[] args)
        {
            _symbolHandlers = new List<ISymbolHandler>() {
                new StarHandler(),
                new SharpHandler(),
                new CommonHandler()
            };
            while(true)
            {
                var userInput = Console.ReadLine();

                foreach(var handler in _symbolHandlers) {
                    if(handler.Processed(userInput))
                        break;
                }
            }
        }
        
        interface ISymbolHandler
        {
            bool Processed(string symbol);
        }

        class SharpHandler : ISymbolHandler
        {
            public bool Processed(string symbol)
            {
                if(symbol == "#")
                {
                    Console.WriteLine(symbol + " - обработка символа '#'");
                    return true;
                }
                return false;
            }
        }

        class StarHandler : ISymbolHandler
        {
            public bool Processed(string symbol)
            {
                if(symbol[0] == '*' && symbol[symbol.Length - 1] == ';')
                {
                    int sum = 0;
                    for(int i = 1; i < symbol.Length - 1; i++)
                    {
                        sum += symbol[i];
                    }
                    if(sum % 2 == 0)
                    {
                        Console.WriteLine(symbol + " - обработка символа '*', сумма цифр до ';' чётная");
                        return true;
                    }
                }
                return false;
            }
        }

        class CommonHandler : ISymbolHandler
        {
            public bool Processed(string symbol)
            {
                Console.WriteLine(symbol + " - общая для символов обработка");
                return true;
            }
        }
    }
}
