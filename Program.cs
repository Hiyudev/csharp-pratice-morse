using System;

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
            bool willContinue = User.Continue("Want to play it? ( Y/N )");

            if (willContinue)
            {
                int difficulty = User.Ask<int>("What difficulty you want to play it? \n0 - EASY\n1 - NORMAL\n2 - HARD");

                switch (difficulty)
                {
                    case 0:
                        Game.ChangeDifficulty(Game.difficulties.EASY);
                        break;
                    case 1:
                    default:
                        Game.ChangeDifficulty(Game.difficulties.NORMAL);
                        break;
                    case 2:
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