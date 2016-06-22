using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Animatica : MonoBehaviour {
#if UNITY_STANDALONE || UNITY_EDITOR
    public MovieTexture animatica;
	void Start () {
        GetComponent<RawImage>().texture = animatica;
        animatica.Play();
	}
	
	void Update () {
	    if (!animatica.isPlaying)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
	}
#elif UNITY_ANDROID
    public string animatica;
    void Start() {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        Handheld.PlayFullScreenMovie(animatica);
        yield return new WaitForEndOfFrame();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }    
#else
    void Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
#endif
}
