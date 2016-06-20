using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MenuSelector : MonoBehaviour {
    public void GoToLevel(string level)
    {
        switch (level)
        {
            case "Level 1":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Scene");
                break;
            case "Level 2":
                if (ScoreManager.Unlocks[0])
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
                break;
            case "Level 3":
                if (ScoreManager.Unlocks[1])
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Beach");
                break;
            case "Level 4":
                if (ScoreManager.Unlocks[2])
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Scene");
                break;
            case "Tuto":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
                break;
        }
    }
}
