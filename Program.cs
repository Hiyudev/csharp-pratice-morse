using System;
using Spectre.Console;

namespace MorseGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the morse game");
            Loop();
        }

        static void Loop()
        {
            bool willContinue = User.Continue("Want to play it?");

            if (willContinue)
            {
                string difficulty = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What [red]difficulty[/] you want to play it?")
                        .PageSize(3)
                        .AddChoices(new[] {
                            "Easy", "Normal", "Hard"
                        }));

                switch (difficulty)
                {
                    case "Easy":
                        Game.ChangeDifficulty(Game.difficulties.EASY);
                        break;
                    case "Normal":
                    default:
                        Game.ChangeDifficulty(Game.difficulties.NORMAL);
                        break;
                    case "Hard":
                        Game.ChangeDifficulty(Game.difficulties.HARD);
                        break;
                }

                Game.Start();
                Loop();
            }
            else
            {
                Console.WriteLine($"Thanks for playing. You played {Game.timesPlayed} times.");
            }
        }
    }
}