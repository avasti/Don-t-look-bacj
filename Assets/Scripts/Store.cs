﻿using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;

public class Store : MonoBehaviour {
    public UnityEngine.UI.Button[] buttons = new UnityEngine.UI.Button[3];

	void Start () {
        
	    for (int i = 0; i < 3; ++i)
        {
            if (ScoreManager.Unlocks[i])
            {
                buttons[i].GetComponentInChildren<Text>().text = "Purchased";
                buttons[i].enabled = false;
            }                
        }
	}
	

    public void ButtonPressed(string buttonName)
    {
        if (buttonName == "Back")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }

    public void Buy(string level)
    {
        int cost = int.Parse(level) * 2000;
        int currentMoney = ScoreManager.Score;
        if (currentMoney > cost)
        {
            ScoreManager.Score -= cost;
            switch (level)
            {
                case "1":
                    ScoreManager.Unlocks[0] = true;
                    break;
                case "2":
                    ScoreManager.Unlocks[1] = true;
                    break;
                case "3":
                    ScoreManager.Unlocks[2] = true;
                    break;
            }
            ScoreManager.SaveScore();
            UnityEngine.SceneManagement.SceneManager.LoadScene("Store");
        }
    }

    public void Reset()
    {
        ScoreManager.DeleteScore();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
