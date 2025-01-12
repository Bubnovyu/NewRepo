using System;
using System.IO;

namespace FirstTaskProject
{
    public static class DictionaryManager
    {
        private static string dictionariesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dictionaries");

        public static void CreateDictionary()
        {
            try
            {
                if (!Directory.Exists(dictionariesPath))
                {
                    Directory.CreateDirectory(dictionariesPath);
                }

                Console.Write("Введите название нового словаря (например, Eng-Rus): ");
                string dictionaryName = Console.ReadLine();
                string filePath = Path.Combine(dictionariesPath, $"{dictionaryName}.txt");

                if (File.Exists(filePath))
                {
                    Console.WriteLine("Словарь с таким названием уже существует.");
                }
                else
                {
                    File.Create(filePath).Close();
                    Console.WriteLine($"Словарь \"{dictionaryName}\" успешно создан.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        public static void AddWord()
        {
            Console.Write("Введите название словаря: ");
            string dictionaryName = Console.ReadLine();
            string filePath = Path.Combine(dictionariesPath, $"{dictionaryName}.txt");

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Словарь не найден.");
            }
            else
            {
                Console.Write("Введите слово: ");
                string word = Console.ReadLine();
                Console.Write("Введите перевод: ");
                string translation = Console.ReadLine();

                File.AppendAllText(filePath, $"{word}:{translation}{Environment.NewLine}");
                Console.WriteLine("Слово и перевод добавлены.");
            }

            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        public static void ReplaceWordOrTranslation()
        {
            try
            {
                Console.Write("Введите название словаря: ");
                string dictionaryName = Console.ReadLine();
                string filePath = Path.Combine(dictionariesPath, $"{dictionaryName}.txt");

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Словарь не найден.");
                    return;
                }

                Console.Write("Введите слово для замены: ");
                string wordToReplace = Console.ReadLine();

                string[] lines = File.ReadAllLines(filePath);
                bool wordFound = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith(wordToReplace + ":"))
                    {
                        wordFound = true;

                        Console.WriteLine($"Найдено: {lines[i]}");
                        Console.Write("Введите новое слово (или нажмите Enter для пропуска): ");
                        string newWord = Console.ReadLine();

                        Console.Write("Введите новый перевод (или нажмите Enter для пропуска): ");
                        string newTranslation = Console.ReadLine();

                        string[] parts = lines[i].Split(':');
                        string currentWord = parts[0];
                        string currentTranslation = parts[1];

                        string updatedWord = string.IsNullOrWhiteSpace(newWord) ? currentWord : newWord;
                        string updatedTranslation = string.IsNullOrWhiteSpace(newTranslation) ? currentTranslation : newTranslation;

                        lines[i] = $"{updatedWord}:{updatedTranslation}";
                        break;
                    }
                }

                if (wordFound)
                {
                    File.WriteAllLines(filePath, lines);
                    Console.WriteLine("Замена выполнена успешно.");
                }
                else
                {
                    Console.WriteLine("Слово не найдено.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        public static void DeleteWordOrTranslation()
        {
            try
            {
                Console.Write("Введите название словаря: ");
                string dictionaryName = Console.ReadLine();
                string filePath = Path.Combine(dictionariesPath, $"{dictionaryName}.txt");

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Словарь не найден.");
                    return;
                }

                Console.Write("Введите слово для удаления: ");
                string wordToDelete = Console.ReadLine();

                string[] lines = File.ReadAllLines(filePath);
                bool wordDeleted = false;


                lines = lines.Where(line =>
                {
                    if (line.StartsWith(wordToDelete + ":"))
                    {
                        wordDeleted = true;
                        return false;
                    }
                    return true;
                }).ToArray();

                if (wordDeleted)
                {
                    File.WriteAllLines(filePath, lines);
                    Console.WriteLine("Слово и его переводы успешно удалены.");
                }
                else
                {
                    Console.WriteLine("Слово не найдено.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }


        public static void SearchWord()
        {
            Console.Write("Введите слово для поиска: ");
            string word = Console.ReadLine();
            Console.Write("Введите название словаря: ");
            string dictionaryName = Console.ReadLine();
            string filePath = Path.Combine(dictionariesPath, $"{dictionaryName}.txt");

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Словарь не найден.");
            }
            else
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (line.StartsWith(word + ":"))
                    {
                        Console.WriteLine($"Перевод: {line.Substring(word.Length + 1)}");
                    }
                }
            }

            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        public static void ExportData()
        {
            try
            {
                Console.Write("Введите название словаря для экспорта: ");
                string dictionaryName = Console.ReadLine();
                string filePath = Path.Combine(dictionariesPath, $"{dictionaryName}.txt");

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Словарь не найден.");
                    return;
                }

                Console.Write("Введите путь для сохранения экспортированного файла: ");
                string exportPath = Console.ReadLine();

                File.Copy(filePath, exportPath, overwrite: true);
                Console.WriteLine($"Словарь \"{dictionaryName}\" успешно экспортирован в {exportPath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
    }
}
