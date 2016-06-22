using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tuto : MonoBehaviour {

    double time = 0.5;
    bool showText = false;
	void Start () {
        GetComponent<Text>().text = "";
	}
	
	
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0 && !showText)
        {
            GetComponent<Text>().text = "Press Space to Jump...";
            time = 3;
            showText = true;
        }
        if (time <= 0 && showText)
        {
            GetComponent<Text>().text = "";
        }
	}
}
