using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MorseGame
{
    static class Game
    {
        private static string[] words = getWords();
        public static int timesPlayed = 0;
        public enum difficulties
        {
            EASY,
            NORMAL,
            HARD
        }
        public static difficulties difficulty = difficulties.NORMAL;
        public static void Start()
        {
            string randomWord = getRandomWord();
            User.Comment("Please listen carefully...");
            PlaySound(randomWord);
            
            string userWord = User.Ask<string>("What was the word?");

            if(randomWord == userWord)
                User.CorrectAnswer();
            else
                User.WrongAnswer();

            timesPlayed++;
        }
        public static void PlaySound(string word)
        {
            List<string> codes = MorseCode.decode(word);

            foreach (string code in codes)
            {
                char[] states = code.ToCharArray();

                foreach (char state in states)
                {
                    PlayStateSound(state);
                }
            }
        }
        private static void PlayStateSound(char state)
        {
            int dotbeepDuration = 0;
            int dashbeepDuration = 0;
            int intervalDuration = 0;

            switch (difficulty)
            {
                case difficulties.EASY:
                    dotbeepDuration = 400;
                    dashbeepDuration = 800;
                    intervalDuration = 500;
                    break;
                default:
                case difficulties.NORMAL:
                    dotbeepDuration = 300;
                    dashbeepDuration = 600;
                    intervalDuration = 325;
                    break;
                case difficulties.HARD:
                    dotbeepDuration = 200;
                    dashbeepDuration = 400;
                    intervalDuration = 250;
                    break;
            }

            switch(state)
            {
                case '.':
                    Console.Beep(800, dotbeepDuration);
                    break;
                case '-':
                    Console.Beep(800, dashbeepDuration);
                    break;
                default:
                    Thread.Sleep(intervalDuration);
                    break;
            }
        }
        private static string getRandomWord()
        {
            Random random = new Random();
            int randomInteger = random.Next(0, words.Length);
            string randomWord = words[randomInteger];
            return randomWord;
        }
        public static void ChangeDifficulty(difficulties diff)
        {
            string strDiff = "";
            switch ((int)diff)
            {
                case 0:
                    strDiff = "easy";
                    break;
                case 1:
                default:
                    strDiff = "normal";
                    break;
                case 2:
                    strDiff = "hard";
                    break;
            }

            Console.WriteLine($"Was selected the difficulty: {strDiff} mode.");
            difficulty = diff;
        }
        public static string[] getWords()
        {
            List<string> words = new List<string>();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\", "Words.txt");

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("mango");
                    sw.WriteLine("banana");
                    sw.WriteLine("watermelon");
                }
            }

            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    words.Add(s);
                }
            }

            return words.ToArray();
        }
    }
}