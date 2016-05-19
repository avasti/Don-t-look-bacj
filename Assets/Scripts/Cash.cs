using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;

public class Cash : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "$" + ScoreManager.Score;     
	}
}
