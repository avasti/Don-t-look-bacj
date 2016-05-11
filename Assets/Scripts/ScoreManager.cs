using Newtonsoft.Json;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    class ScoreManager
    {
        public static Score ScoreObj;
        public static int score = 0;

        private static string file = "./Assets/score.json";
        public static void LoadScore()
        {
            string json = File.ReadAllText(file);
            ScoreObj = JsonConvert.DeserializeObject<Score>(json);
        }

		public static void SaveScore()
        {
            string json = JsonConvert.SerializeObject(ScoreObj);
            Debug.Log(json);
            File.WriteAllText(file, json);
        }
    }
}
