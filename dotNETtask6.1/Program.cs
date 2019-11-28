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
            string userCommand = "";
            bool userDone = false;
            bool english = false;
            Console.WriteLine("***** Добро пожаловать! *****");
            try
            {
                ShowInstruction(english);
                do
                {
                    if (english)
                        Console.Write("Plese enter a command:\n>");
                    else
                        Console.Write("Пожалуйста, введите команду:\n>");
                    userCommand = Console.ReadLine();
                    Console.WriteLine();
                    if (english)
                    {
                        switch (userCommand.ToUpper())
                        {
                            case "A":
                                Console.WriteLine("Adding new word to dictionary. Please enter new word:");
                                break;
                            case "D":
                                Console.WriteLine("Please enter a word you want to delete:");
                                break;
                            case "S":
                                Console.WriteLine("Please enter a word to search:");
                                break;
                            case "H":
                                ShowInstruction(english);
                                break;
                            case "R":
                                Console.WriteLine("Меню теперь будет на русском языке");
                                english = false;
                                break;
                            case "Q":
                                Console.WriteLine("Thank you for using my dictionary, good-bye!");
                                userDone = true;
                                break;
                            default:
                                Console.WriteLine("Bad data! Try again. Type \"H\" for help");
                                break;
                        }
                    }
                    else
                    {
                        switch (userCommand.ToUpper())
                        {
                            case "Д":
                                Console.WriteLine("Добавляем новое слово. Пожалуйста, введите новое слово:");
                                break;
                            case "У":
                                Console.WriteLine("Пожалуйста, введите слово, которое хотите удалить:");
                                break;
                            case "Н":
                                Console.WriteLine("Введите слово, которое хотите найти:");
                                break;
                            case "А":
                                Console.WriteLine("Now menu is in English!");
                                english = true;
                                break;
                            case "П":
                                ShowInstruction(english);
                                break;
                            case "В":
                                Console.WriteLine("Спасибо за пользование моим словарём. До свидания!");
                                userDone = true;
                                break;
                            default:
                                Console.WriteLine("Вы ввели что-то не то, попробуйте снова! (\"П\" - помощь)");
                                break;
                        }
                    }
                    
                } while (!userDone);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        //add translation
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
                Console.WriteLine("Н: Найти слово в словаре.");
                Console.WriteLine("А: Translate menu to English");
                Console.WriteLine("П: Помощь");
                Console.WriteLine("В: Выйти из программы.");
            }
            
        }
    }
}
