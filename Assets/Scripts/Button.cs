using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {
	public void OnClick () {
        switch (transform.gameObject.name)
        {
            case "Start":
                SceneManager.LoadScene("SelectLevel");
                break;

            case "Lvl 01":
                SceneManager.LoadScene("Scene");
                break;

            case "Exit":
                Application.Quit();
                break;
        }
	}
}
