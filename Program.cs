using System;
using System.IO;

namespace FirstTaskProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string dictionariesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dictionaries");

            if (!Directory.Exists(dictionariesPath))
            {
                Directory.CreateDirectory(dictionariesPath);
            }

            Console.WriteLine("Добро пожаловать в приложение \"Словари\"!");
            Menu.ShowMainMenu();
        }
    }
}
