using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    class ScoreManager
    {
        public static int Score;
        public static int score = 0;

        private static string file = "./Assets/score.txt";
        public static void LoadScore()
        {
            if (!File.Exists(file))
            {
                File.Create(file);
                File.WriteAllText(file, "0");
            }
            string sc = File.ReadAllText(file);
            Score = int.Parse(sc);
        }

		public static void SaveScore()
        {
            Score += score;
            score = 0;
            File.WriteAllText(file, string.Format("{0}", Score));
        }
    }
}
