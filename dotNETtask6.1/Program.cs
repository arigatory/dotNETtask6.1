using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dotNETtask6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            EnRuDictionary dictionary = new EnRuDictionary();

            string userCommand = "";
            bool userDone = false;
            bool english = false;
            Console.WriteLine("***** Добро пожаловать! *****");
            try
            {
                ShowInstruction(english);
                do
                {
                    userCommand = AskForCommand(english);
                    switch (userCommand)
                    {
                        case "A":
                        case "А":
                        case "Д":
                            AddWord(dictionary,english);
                            break;
                        case "D":
                        case "У":
                            DeleteWord(dictionary, english);
                            break;
                        case "H":
                        case "Н":
                        case "К":
                        case "K":
                            ShowInstruction(english);
                            break;
                        case "R":
                            Console.WriteLine("Меню теперь будет на русском языке");
                            english = false;
                            ShowInstruction(english);
                            break;
                        case "Q":
                            Console.WriteLine("Thank you for using my dictionary, good-bye!");
                            userDone = true;
                            break;
                        case "П":
                        case "S":
                            Search(dictionary, english);
                            break;
                        case "E":
                        case "Е":
                            Console.WriteLine("Now menu is in English!");
                            english = true;
                            ShowInstruction(english);
                            break;
                        case "В":
                            Console.WriteLine("Спасибо за пользование моим словарём. До свидания!");
                            userDone = true;
                            break;
                        default:
                            if (english)
                                Console.WriteLine("Bad data! Try again. Type \"H\" for help");
                            else
                                Console.WriteLine("Вы ввели что-то не то, попробуйте снова! (\"К\" - команды (список))");
                            break;
                    }

                } while (!userDone);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        private static void DeleteWord(EnRuDictionary dictionary, bool english)
        {
            if (english)
            {
                Console.Write("Please enter a word you want to delete\n>");
            }
            else
            {
                Console.Write("Введите слово для удаления\n>");
            }
            string inputWord = Console.ReadLine()?.Trim().ToLower();
            
            if (inputWord is null)
            {
                Console.WriteLine("Error: bad input! Ошибка ввода!");
            }
            else
            {
                dictionary.Delete(inputWord);
                if (english)
                {
                    Console.WriteLine($"The word {inputWord} deleted!");
                }
                else
                {
                    Console.WriteLine($"Слово {inputWord} удалено!");
                }
            }
        }

        private static string AskForCommand(bool english)
        {
            Console.WriteLine();
            if (english)
                Console.Write("Plese enter a command:\n>");
            else
                Console.Write("Пожалуйста, введите команду:\n>");
            string temp = Console.ReadLine();
            return temp?.Trim()?.ToUpper() ?? "";
        }

        private static void Search(EnRuDictionary dictionary, bool english)
        {
            if (english)
            {
                Console.Write("Enter a word to search:\n>");
            }
            else
            {
                Console.Write("Введите слово для поиска:\n>");
            }
            string input = Console.ReadLine().Trim().ToLower();
            List<string> translations =  dictionary.GetTranslations(input);
            if (translations.Count == 0)
            {
                if (english)
                    Console.WriteLine($"No such word in the dictionary:{input}");
                else
                    Console.WriteLine($"Слово {input} отсутствует в словаре!");
            }
            else
            {
                foreach (string s in translations)
                {
                    Console.WriteLine(" "+s);
                }
            }
        }


        private static void AddWord(EnRuDictionary dictionary, bool english)
        {
            if (english)
            {
                Console.Write("Please enter a word\n>");
            }
            else
            {
                Console.Write("Введите слово\n>");
            }
            string inputWord = Console.ReadLine()?.Trim().ToLower();
            if (english)
            {
                Console.Write("Please enter a translation for the word. You can use comma for several variants\n>");
            }
            else
            {
                Console.Write("Введите перевод для данного слова (можно ввести несколько вариантов через запятую)\n>");
            }
            string inputTranslation = Console.ReadLine();
            List<string> translationlList = inputTranslation?.ToLower().Split(',').Select(s => s.Trim()).ToList();
            if (inputWord is null || translationlList is null)
            {
                Console.WriteLine("Error: bad input! Ошибка ввода!");
            }
            else
            {
                dictionary.Add(inputWord, translationlList);
                if (english)
                {
                    Console.WriteLine($"The word {inputWord} added!");
                }
                else
                {
                    Console.WriteLine($"Слово {inputWord} добавлено!");
                }
            }
        }

        private static void ShowInstruction(bool english)
        {
            if (english)
            {
                Console.WriteLine("A: Add new word to dictionary.");
                Console.WriteLine("D: Delete word from dictionary.");
                Console.WriteLine("L: Look up word in dictionary.");
                Console.WriteLine("R: Перевести на русский язык меню");
                Console.WriteLine("H: Help");
                Console.WriteLine("Q: Quit program.");
            }
            else
            {
                Console.WriteLine("Д: Добавить новое слово в словарь.");
                Console.WriteLine("У: Удалить слово из словаря.");
                Console.WriteLine("П: Поиск слова в словаре.");
                Console.WriteLine("E: Translate menu to English");
                Console.WriteLine("К: Команды (список)");
                Console.WriteLine("В: Выйти из программы.");
            }
        }
    }
}
