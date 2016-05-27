using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    class ScoreManager
    {
        public static int Score;
        public static bool[] Unlocks = new bool[4];
        public static int score = 0;

        public static void LoadScore()
        {
            Score = PlayerPrefs.GetInt("score");
            for (int i = 0; i < 4; ++i)
            {
                Unlocks[i] = PlayerPrefs.GetInt("unlock" + i) == 1;
            }
        }

		public static void SaveScore()
        {
            Score += score;
            score = 0;
            PlayerPrefs.SetInt("score", Score);
            for (int i = 0; i < 4; ++i)
            {
                PlayerPrefs.SetInt("unlock" + i, Unlocks[i] ? 1 : 0);
            }
        }

        public static void DeleteScore()
        {
            for (int i = 0; i < Unlocks.Length; ++i)
                Unlocks[i] = false;
            Score = 0;
            SaveScore();
            LoadScore();
        }
    }
}
