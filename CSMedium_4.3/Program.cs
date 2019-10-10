using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMedium
{
    class Program
    {
        private static HandleChooser _handlerChooser;

        static void Main(string[] args)
        {
            _handlerChooser = new HandleChooser();
            while(true)
            {
                var userInput = Console.ReadLine();

                Console.WriteLine(_handlerChooser.Chose(userInput).SymbolProcess(userInput));
            }
        }

        class HandleChooser
        {
            private CommonHandler _commonHandler;
            private SharpHandler _sharpHandler;
            private StarHandler _starHandler;

            public HandleChooser()
            {
                _commonHandler = new CommonHandler();
                _sharpHandler = new SharpHandler();
                _starHandler = new StarHandler();
            }

            public ISymbolHandler Chose(string userInput)
            {
                ISymbolHandler targetHandler = _commonHandler;
                if(userInput.Length == 1 && userInput[0] == '#')
                {
                    targetHandler = new SharpHandler();
                }
                else if(userInput[0] == '*' && userInput[userInput.Length - 1] == ';')
                {
                    int sum = 0;
                    for(int i = 1; i < userInput.Length - 1; i++)
                    {
                        sum += userInput[i];
                    }
                    if(sum % 2 == 0)
                        targetHandler = new StarHandler();
                }

                return targetHandler;
            }
        }

        interface ISymbolHandler
        {
            string SymbolProcess(string symbol);
        }

        class SharpHandler : ISymbolHandler
        {
            public string SymbolProcess(string symbol)
            {
                return symbol + " - обработка символа '#'\n";
            }
        }

        class StarHandler : ISymbolHandler
        {
            public string SymbolProcess(string symbol)
            {
                return symbol + " - обработка символа '*', сумма цифр до ';' чётная\n";
            }
        }

        class CommonHandler : ISymbolHandler
        {
            public string SymbolProcess(string symbol)
            {
                return symbol + " - общая для символов обработка\n";
            }
        }
    }
}
