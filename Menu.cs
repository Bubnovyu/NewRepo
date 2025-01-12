using System;

namespace FirstTaskProject
{
    public static class Menu
    {
        public static void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Главное меню:");
                Console.WriteLine("1. Создать словарь");
                Console.WriteLine("2. Добавить слово и перевод");
                Console.WriteLine("3. Заменить слово или перевод");
                Console.WriteLine("4. Удалить слово или перевод");
                Console.WriteLine("5. Искать перевод слова");
                Console.WriteLine("6. Экспортировать данные");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт меню: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DictionaryManager.CreateDictionary();
                        break;
                    case "2":
                        DictionaryManager.AddWord();
                        break;
                    case "3":
                        DictionaryManager.ReplaceWordOrTranslation();
                        break;
                    case "4":
                        DictionaryManager.DeleteWordOrTranslation();
                        break;
                    case "5":
                        DictionaryManager.SearchWord();
                        break;
                    case "6":
                        DictionaryManager.ExportData();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
