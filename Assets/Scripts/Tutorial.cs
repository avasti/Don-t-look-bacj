using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
    float time = 2000;
    string[] lines;
    int lineCount = 0;
	void Start () {
        GetComponent<Text>().text = lines[0];
	}

	void Update () {
        time -= Time.deltaTime;
        if (time <= 0 && lineCount < lines.Length - 1)
        {
            ++lineCount;
            GetComponent<Text>().text = lines[lineCount];
            time += 2000;
        }
        if (time <= 0 && lineCount == lines.Length)
        {
            enabled = false;
        }
	}
}
