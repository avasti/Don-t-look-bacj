using System.IO;

namespace Assets.Scripts
{
    class ScoreManager
    {
        public static int MaxScore = 0;
        public static int Score = 0;

        private static string file = "./Assets/score.txt";
        public static void LoadScore()
        {            
			if (!File.Exists(file))
            {
                File.Create(file);
            }
            string score = File.ReadAllText(file);
            MaxScore = int.Parse(score);
        }

		public static void SaveScore()
        {
            File.WriteAllText(file, string.Format("{0}", Score + MaxScore));
        }
    }
}
