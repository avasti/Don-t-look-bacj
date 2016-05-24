using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    class ScoreManager
    {
        public static int Score;
        public static bool[] Unlocks = new bool[4];
        public static int score = 0;

        private static string file = "./Assets/score.txt";
        public static void LoadScore()
        {
            if (!File.Exists(file))
            {
                string f = "0";
                for (int i = 0; i < 4; ++i)
                {
                    f += "\n" + Unlocks[i];
                }
                File.WriteAllText(file, f);
            }
            string[] sc = File.ReadAllLines(file);
            Score = int.Parse(sc[0]);
            for (int i = 0; i < 4; ++i)
            {
                Unlocks[i] = bool.Parse(sc[i + 1]);
            }
        }

		public static void SaveScore()
        {
            Score += score;
            score = 0;
            string f = "" + Score;
            for (int i = 0; i < 4; ++i)
            {
                f += "\n" + Unlocks[i];
            }
            File.WriteAllText(file, f);
        }

        public static void DeleteScore()
        {
            for (int i = 0; i < Unlocks.Length; ++i)
                Unlocks[i] = false;
            File.Delete(file);
            LoadScore();
        }
    }
}
