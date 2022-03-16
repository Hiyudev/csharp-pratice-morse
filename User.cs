using System;
using Spectre.Console;

namespace MorseGame
{
    static class User
    {
        public static bool Continue(string question)
        {
            return AnsiConsole.Confirm(question);
        }
        public static T Ask<T>(string question)
        {
            bool correctAnswer = false;
            dynamic returnAnswer = null;

            while (!correctAnswer)
            {
                Console.WriteLine(question);
                string answer = Console.ReadLine();
            
                try
                {
                    returnAnswer = (T)Convert.ChangeType(answer, typeof(T));
                    correctAnswer = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return returnAnswer;
        }
        public static void CorrectAnswer()
        {
            AnsiConsole.Markup("[default on green]Congratulations[/], you answered correctly!");
        }
        public static void WrongAnswer()
        {
            AnsiConsole.Markup("[default on red]Ops[/] ! Looks like you put wrong answer!");
        }
        public static void Comment(string comment)
        {
            Console.WriteLine(comment);
        }
    }
}
