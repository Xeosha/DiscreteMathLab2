using System;
using System.Collections.Generic;
using MenuOpt;

namespace DiscreteMathLab2
{
    class Program
    {
        static string filename = "matrix.txt";
        static void Main(string[] args)
        {
            var options = new[]
            {
                new Options("Вывести содержимое файла на экран: ", PrintFile),
                new Options("Вывести хар-ки на экран: ", Show)
            };

            Menu menu = new Menu(options);
            menu.ShowMenu();
        }

        static void PrintFile() => DataFile.PrintFile(filename);

        static void Show()
        {
            Work obj = new Work(6);
            obj.StringToInt(DataFile.OutPutFile(filename));
            obj.Show();
        }

    }
}
