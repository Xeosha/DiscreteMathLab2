using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteMathLab2
{
    internal class Options
    {
        internal string text { get; set; }

        internal Action action { get; set; }

        public Options(string text, Action action)
        {
            this.text = text;
            this.action = action;
        }
    }
    internal class Menu
    {

        Options[] _options;
        string _message;

        public Menu(Options[] options)
        {
            this._options = options;
        }

        public Menu(Options[] options, string message)
        {
            _options = options;
            _message = message;
        }

        private void ShowTextMenu(int index)
        {
            Console.Clear();
            if (_message != null)
                Console.WriteLine($"\t{_message}");

            for (int i = 0; i < _options.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(">> ");
                }
                Console.WriteLine(_options[i].text);
                Console.ResetColor();

            }
            Console.WriteLine();
        }

        public void ShowMenu()
        {
            bool isContinue = true;
            int index = 0;

            while (isContinue)
            {
                ShowTextMenu(index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < _options.Length - 1)
                            index++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine($"Выбран пункт {_options[index].text}");
                        _options[index].action();
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.Escape:
                        isContinue = false;
                        break;

                }

            }
        }

    }
}
